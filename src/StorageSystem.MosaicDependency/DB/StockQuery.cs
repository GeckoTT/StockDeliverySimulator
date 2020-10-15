using CareFusion.Mosaic.Core.Logging;
using CareFusion.Mosaic.Interfaces.Messages.Stock;
using CareFusion.Mosaic.Interfaces.Types.Articles;
using CareFusion.Mosaic.Interfaces.Types.Packs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Text;

namespace CareFusion.Mosaic.DB
{
    /// <summary>
    /// Class which contains the logic for special case stock query operations
    /// which cannot be expressed via the generic interface of the database.
    /// </summary>
    public class StockQuery
    {
        #region Members

        /// <summary>
        /// The database instance to use for performing the special stock queries.
        /// </summary>
        private Database _database;

        /// <summary>
        /// The tenant identifier to use when performing the special stock queries.
        /// </summary>
        private string _tenantId;

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="StockQuery" /> class.
        /// </summary>
        /// <param name="database">The database instance to use.</param>
        /// <param name="tenantId">The tenant identifier to use.</param>
        public StockQuery(Database database, string tenantId)
        {
            if (database == null)
            {
                throw new ArgumentException("Invalid database specified.");
            }

            if (tenantId == null)
            {
                throw new ArgumentException("Invalid tenantId specified.");
            }

            _database = database;
            _tenantId = tenantId;
        }

        /// <summary>
        /// Gets the current stock level beginning with the specified start article code.
        /// </summary>
        /// <param name="startArticleCode">The article code to start the query from.</param>
        /// <param name="maxCount">The maximum number of results to return.</param>
        /// <returns>Special list of articles which contains the requested stock level information.</returns>
        public List<RobotArticle> GetStockLevel(string startArticleCode, int maxCount)
        {
            List<RobotArticle> resultList = new List<RobotArticle>();

            if ((string.IsNullOrWhiteSpace(startArticleCode) == true) || (maxCount < 1))
            {
                this.Error("Invalid start article code or max count specified.");
                return resultList;
            }

            string CmdText = "SELECT ArticleCode, COUNT(*) as NumPacks, SUM(SubItemQuantity) as NumSubItems FROM Packs " +
                             "WHERE TenantID = @TenantID AND ArticleCode > @StartArticleCode COLLATE ArticleCodeCompare " +
                             "GROUP BY ArticleCode ORDER BY ArticleCode ASC LIMIT @MaxResults;";

            using (SQLiteCommand cmd = new SQLiteCommand(CmdText))
            {
                cmd.Parameters.Add(new SQLiteParameter("@TenantID", _tenantId));
                cmd.Parameters.Add(new SQLiteParameter("@StartArticleCode", startArticleCode));
                cmd.Parameters.Add(new SQLiteParameter("@MaxResults", maxCount));

                using (DataTable tblResult = _database.Execute(cmd))
                {
                    if (tblResult == null)
                    {
                        return resultList;
                    }

                    foreach (DataRow row in tblResult.Rows)
                    {
                        resultList.Add(new RobotArticle() 
                                       { 
                                           Code = (string)row[0], 
                                           PackCount = System.Convert.ToInt32((long)row[1]), 
                                           SubItemCount = System.Convert.ToInt32((long)row[2]) 
                                       });
                    }
                }
            }

            return resultList;
        }

        /// <summary>
        /// Gets a list of articles which fit to the specified filter criteria list.
        /// </summary>
        /// <param name="criteriaList">The criteria list to use.</param>
        /// <param name="includeArticleDetails">
        /// if set to <c>true</c> more detailed article information should be returned.
        /// </param>
        /// <returns>
        /// List of articles that match the filter.
        /// </returns>
        public List<RobotArticle> GetArticles(List<StockInfoCriteria> criteriaList, 
                                         bool includeArticleDetails)
        {
            List<RobotArticle> resultList = new List<RobotArticle>();
            StringBuilder cmdBuilder = new StringBuilder();
            cmdBuilder.Append("SELECT RobotArticleCode, ");

            if (includeArticleDetails)
            {
                cmdBuilder.Append("(SELECT Name FROM RobotArticles WHERE ID=RobotArticleID AND RobotArticles.ComponentID=RobotPacks.ComponentID) as Name, ");
                cmdBuilder.Append("(SELECT DosageForm FROM RobotArticles WHERE ID=RobotArticleID AND RobotArticles.ComponentID=RobotPacks.ComponentID) as DosageForm,  ");
                cmdBuilder.Append("(SELECT PackagingUnit FROM RobotArticles WHERE ID=RobotArticleID AND RobotArticles.ComponentID=RobotPacks.ComponentID) as PackagingUnit, ");
                cmdBuilder.Append("(SELECT MaxSubItemQuantity FROM ArticleMaxSubItemQuantitys WHERE ID=RobotArticleCode AND ArticleMaxSubItemQuantitys.TenantID=RobotPacks.TenantID) as MaxSubItemQuantity, ");
            }

            cmdBuilder.Append("COUNT(*) AS NumPacks FROM RobotPacks");
            cmdBuilder.Append(" WHERE TenantID = @TenantID");
            cmdBuilder.Append(criteriaList.Count > 0 ? " AND (" : string.Empty);
            
            for (int i = 0; i < criteriaList.Count; ++i)
            {
                StringBuilder conditionBuilder = new StringBuilder();

                if (string.IsNullOrEmpty(criteriaList[i].RobotArticleCode) == false)
                {
                    conditionBuilder.Append(string.Format("RobotArticleCode=@RobotArticleCode{0}", i));
                }

                if (string.IsNullOrEmpty(criteriaList[i].PISArticleCode) == false)
                {
                    // recursive with to get all PIS article matching the PISArticleCode and all child articles. (safety limit to 100 recursive select.
                    cmdBuilder.Insert(0, string.Format(@"with RECURSIVE PISArticlesTree(ParentPisArticleID, ID, code, RobotArticleCode, level) as
                        (Select null, ID, code, RobotArticleCode, 0 from PISArticles where code = @PISArticleCode{0}
                        UNION ALL
                        Select pisArticleChild.ParentPisArticleID, pisArticleChild.ID, pisArticleChild.code, pisArticleChild.RobotArticleCode, level + 1 
                            from PISArticles pisArticleChild
                            inner join PISArticlesTree as pisArticleParent on pisArticleChild.ParentPisArticleID = pisArticleParent.id and level < 100)
                        ", i));

                    // get stock matching the RobotArticleCode of the PIS articles related to the PISArticleCode
                    conditionBuilder.Append("RobotArticleCode in (Select RobotArticleCode from PISArticlesTree where RobotArticleCode is not null)");
                }

                if (string.IsNullOrEmpty(criteriaList[i].BatchNumber) == false)
                {
                    conditionBuilder.Append(conditionBuilder.Length > 0 ? " AND " : string.Empty);
                    conditionBuilder.Append(string.Format("BatchNumber=@BatchNumber{0}", i));
                }

                if (string.IsNullOrEmpty(criteriaList[i].ExternalID) == false)
                {
                    conditionBuilder.Append(conditionBuilder.Length > 0 ? " AND " : string.Empty);
                    conditionBuilder.Append(string.Format("ExternalID=@ExternalID{0}", i));
                }

                if (string.IsNullOrEmpty(criteriaList[i].StockLocationID) == false)
                {
                    conditionBuilder.Append(conditionBuilder.Length > 0 ? " AND " : string.Empty);
                    conditionBuilder.Append(string.Format("StockLocationID=@StockLocationID{0}", i));
                }

                if (string.IsNullOrEmpty(criteriaList[i].MachineLocation) == false)
                {
                    conditionBuilder.Append(conditionBuilder.Length > 0 ? " AND " : string.Empty);
                    conditionBuilder.Append(string.Format("MachineLocation=@MachineLocation{0}", i));
                }

                if (conditionBuilder.Length == 0)
                {
                    continue;
                }

                cmdBuilder.Append("(");
                cmdBuilder.Append(conditionBuilder);
                conditionBuilder.Clear();
                cmdBuilder.Append(")");                

                if (i < criteriaList.Count - 1)
                {
                    cmdBuilder.Append(" OR ");
                }
            }

            cmdBuilder.Append(criteriaList.Count > 0 ? ")" : string.Empty);
            cmdBuilder.Append(" GROUP BY RobotArticleCode;");

            using (SQLiteCommand cmd = new SQLiteCommand(cmdBuilder.ToString()))
            {
                cmd.Parameters.Add(new SQLiteParameter("@TenantID", _tenantId));

                for (int i = 0; i < criteriaList.Count; ++i)
                {
                    if (string.IsNullOrEmpty(criteriaList[i].RobotArticleCode) == false)
                    {
                        cmd.Parameters.Add(new SQLiteParameter(string.Format("@RobotArticleCode{0}", i), criteriaList[i].RobotArticleCode));
                    }

                    if (string.IsNullOrEmpty(criteriaList[i].PISArticleCode) == false)
                    {
                        cmd.Parameters.Add(new SQLiteParameter(string.Format("@PISArticleCode{0}", i), criteriaList[i].PISArticleCode));
                    }

                    if (string.IsNullOrEmpty(criteriaList[i].BatchNumber) == false)
                    {
                        cmd.Parameters.Add(new SQLiteParameter(string.Format("@BatchNumber{0}", i), criteriaList[i].BatchNumber));
                    }

                    if (string.IsNullOrEmpty(criteriaList[i].ExternalID) == false)
                    {
                        cmd.Parameters.Add(new SQLiteParameter(string.Format("@ExternalID{0}", i), criteriaList[i].ExternalID));
                    }

                    if (string.IsNullOrEmpty(criteriaList[i].StockLocationID) == false)
                    {
                        cmd.Parameters.Add(new SQLiteParameter(string.Format("@StockLocationID{0}", i), criteriaList[i].StockLocationID));
                    }

                    if (string.IsNullOrEmpty(criteriaList[i].MachineLocation) == false)
                    {
                        cmd.Parameters.Add(new SQLiteParameter(string.Format("@MachineLocation{0}", i), criteriaList[i].MachineLocation));
                    }
                }

                using (DataTable tblResult = _database.Execute(cmd))
                {
                    if (tblResult == null)
                    {
                        return resultList;
                    }

                    if (includeArticleDetails)
                    {
                        foreach (DataRow row in tblResult.Rows)
                        {
                            object maxSubItemQuantity = row[4];

                            resultList.Add(new RobotArticle()
                            {
                                Code = (string)row[0],
                                Name = (string)row[1],
                                DosageForm = (string)row[2],
                                PackagingUnit = (string)row[3],
                                MaxSubItemQuantity = (maxSubItemQuantity != DBNull.Value) ? (int)maxSubItemQuantity : 0,
                                PackCount = System.Convert.ToInt32((long)row[5])
                            });
                        }
                    }
                    else
                    {
                        foreach (DataRow row in tblResult.Rows)
                        {
                            resultList.Add(new RobotArticle()
                            {
                                Code = (string)row[0],
                                Name = null,
                                DosageForm = null,
                                PackagingUnit = null,
                                MaxSubItemQuantity = -1,
                                PackCount = System.Convert.ToInt32((long)row[1])
                            });
                        }
                    }
                }
            }

            cmdBuilder.Clear();
            return resultList;
        }

        /// <summary>
        /// Gets a list of packs which fit to the specified filter criteria list.
        /// </summary>
        /// <param name="criteriaList">The criteria list to use.</param>
        /// <returns>List of packs that match the filter.</returns>
        public List<RobotPack> GetPacks(List<StockInfoCriteria> criteriaList)
        {
            List<RobotPack> resultList = new List<RobotPack>();
            StringBuilder cmdBuilder = new StringBuilder();
            cmdBuilder.Append("SELECT * FROM RobotPacks ");
            cmdBuilder.Append(" WHERE TenantID = @TenantID");
            cmdBuilder.Append(criteriaList.Count > 0 ? " AND (" : string.Empty);

            for (int i = 0; i < criteriaList.Count; ++i)
            {
                StringBuilder conditionBuilder = new StringBuilder();

                if (string.IsNullOrEmpty(criteriaList[i].RobotArticleCode) == false)
                {
                    conditionBuilder.Append(string.Format("RobotArticleCode=@RobotArticleCode{0}", i));
                }
                
                if (string.IsNullOrEmpty(criteriaList[i].PISArticleCode) == false)
                {
                    // recursive with to get all PIS article matching the PISArticleCode and all child articles. (safety limit to 100 recursive select.
                    cmdBuilder.Insert(0, string.Format(@"with RECURSIVE PISArticlesTree(ParentPisArticleID, ID, code, RobotArticleCode, level) as
                        (Select null, ID, code, RobotArticleCode, 0 from PISArticles where code = @PISArticleCode{0}
                        UNION ALL
                        Select pisArticleChild.ParentPisArticleID, pisArticleChild.ID, pisArticleChild.code, pisArticleChild.RobotArticleCode, level + 1 
                            from PISArticles pisArticleChild
                            inner join PISArticlesTree as pisArticleParent on pisArticleChild.ParentPisArticleID = pisArticleParent.id and level < 100)
                        ", i));

                    // get stock matching the RobotArticleCode of the PIS articles related to the PISArticleCode
                    conditionBuilder.Append("RobotArticleCode in (Select RobotArticleCode from PISArticlesTree where RobotArticleCode is not null)");
                }

                if (string.IsNullOrEmpty(criteriaList[i].BatchNumber) == false)
                {
                    conditionBuilder.Append(conditionBuilder.Length > 0 ? " AND " : string.Empty);
                    conditionBuilder.Append(string.Format("BatchNumber=@BatchNumber{0}", i));
                }

                if (string.IsNullOrEmpty(criteriaList[i].ExternalID) == false)
                {
                    conditionBuilder.Append(conditionBuilder.Length > 0 ? " AND " : string.Empty);
                    conditionBuilder.Append(string.Format("ExternalID=@ExternalID{0}", i));
                }

                if (string.IsNullOrEmpty(criteriaList[i].StockLocationID) == false)
                {
                    conditionBuilder.Append(conditionBuilder.Length > 0 ? " AND " : string.Empty);
                    conditionBuilder.Append(string.Format("StockLocationID=@StockLocationID{0}", i));
                }

                if (string.IsNullOrEmpty(criteriaList[i].MachineLocation) == false)
                {
                    conditionBuilder.Append(conditionBuilder.Length > 0 ? " AND " : string.Empty);
                    conditionBuilder.Append(string.Format("MachineLocation=@MachineLocation{0}", i));
                }

                if (conditionBuilder.Length == 0)
                {
                    continue;
                }

                cmdBuilder.Append("(");
                cmdBuilder.Append(conditionBuilder);
                conditionBuilder.Clear();
                cmdBuilder.Append(")");

                if (i < criteriaList.Count - 1)
                {
                    cmdBuilder.Append(" OR ");
                }
            }

            cmdBuilder.Append(criteriaList.Count > 0 ? ")" : string.Empty);
            cmdBuilder.Append(";");

            using (SQLiteCommand cmd = new SQLiteCommand(cmdBuilder.ToString()))
            {
                cmd.Parameters.Add(new SQLiteParameter("@TenantID", _tenantId));

                for (int i = 0; i < criteriaList.Count; ++i)
                {
                    if (string.IsNullOrEmpty(criteriaList[i].RobotArticleCode) == false)
                    {
                        cmd.Parameters.Add(new SQLiteParameter(string.Format("@RobotArticleCode{0}", i), criteriaList[i].RobotArticleCode));
                    }

                    if (string.IsNullOrEmpty(criteriaList[i].PISArticleCode) == false)
                    {
                        cmd.Parameters.Add(new SQLiteParameter(string.Format("@PISArticleCode{0}", i), criteriaList[i].PISArticleCode));
                    }

                    if (string.IsNullOrEmpty(criteriaList[i].BatchNumber) == false)
                    {
                        cmd.Parameters.Add(new SQLiteParameter(string.Format("@BatchNumber{0}", i), criteriaList[i].BatchNumber));
                    }

                    if (string.IsNullOrEmpty(criteriaList[i].ExternalID) == false)
                    {
                        cmd.Parameters.Add(new SQLiteParameter(string.Format("@ExternalID{0}", i), criteriaList[i].ExternalID));
                    }

                    if (string.IsNullOrEmpty(criteriaList[i].StockLocationID) == false)
                    {
                        cmd.Parameters.Add(new SQLiteParameter(string.Format("@StockLocationID{0}", i), criteriaList[i].StockLocationID));
                    }

                    if (string.IsNullOrEmpty(criteriaList[i].MachineLocation) == false)
                    {
                        cmd.Parameters.Add(new SQLiteParameter(string.Format("@MachineLocation{0}", i), criteriaList[i].MachineLocation));
                    }
                }

                using (DataTable tblResult = _database.Execute(cmd))
                {
                    if (tblResult == null)
                    {
                        return resultList;
                    }

                    foreach (DataRow row in tblResult.Rows)
                    {
                        RobotPack pack = new RobotPack();
                        pack.Load(row, _database);
                        resultList.Add(pack);
                    }
                }
            }

            cmdBuilder.Clear();
            return resultList;
        }
    }
}
