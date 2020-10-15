using System;

namespace CareFusion.Mosaic.DB
{
    /// <summary>
    /// Class which implements the logic to get lookup Parent PIS code from any child article information
    /// </summary>
    public class CommandFilterPISArticlesAscLookup : CommandFilterNestedQuery, CommandFilterWithClause
    {
        #region Members
        private string _childRobotArticleCode;
        private int _childPISArticleID;
        #endregion

        #region Properties
        /// <summary>
        /// Gets the text representation of the filter object.
        /// </summary>
        public string GetWithClauseText()
        {
            string whereClause;
            if (!String.IsNullOrEmpty(_childRobotArticleCode))
            {
                whereClause = "RobotArticleCode = @ChildRobotArticleCode0";
            }
            else
            {
                whereClause = "ID = @ChildPISArticleID0";
            }
            
            // 'level' field in the query is used to limit the deep of the query. in Case of a reference loop, if wouldn't loop forever
            return string.Format(@"with RECURSIVE PISArticlesTree(ParentPisArticleID, ID, code, level) as
                    (Select ParentPisArticleID, ID, code, 0 from PISArticles where {0}
                    UNION ALL
                    Select pisArticleParent.ParentPisArticleID, pisArticleParent.ID, pisArticleParent.code, level + 1 
                        from PISArticles pisArticleParent
                        inner join PISArticlesTree as pisArticleChild on pisArticleChild.ParentPisArticleID = pisArticleParent.id and level < 100
                    group by level)
                    ", whereClause);
        }
        
        /// <summary>
        /// Gets the CommandFilters specific to the 'with' clause.
        /// </summary>
        public CommandFilter[] GetWithClauseCommandFilter()
        {
            return new CommandFilter[2] {
                new CommandFilter("ChildRobotArticleCode", _childRobotArticleCode),
                new CommandFilter("ChildPISArticleID", _childPISArticleID)
            };
        }
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandFilterPISArticlesAscLookup"/> class.
        /// </summary>
        /// <param name="concatType">Concatination type of the group.</param>
        /// <param name="robotArticleCode">robot article code</param>
        public CommandFilterPISArticlesAscLookup(ConcatenationType concatType, string robotArticleCode)
            : base(concatType,
                  "PISArticlesTree",
                  "Code",
                  "Code",
                  new CommandFilter[1] { new CommandFilter("ParentPisArticleID", DBNull.Value, ComparisonType.EqualTo) })
        {
            _childRobotArticleCode = robotArticleCode;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandFilterPISArticlesAscLookup"/> class.
        /// </summary>
        /// <param name="concatType">Concatination type of the group.</param>
        /// <param name="childPISArticleID">child PIS Article ID</param>
        public CommandFilterPISArticlesAscLookup(ConcatenationType concatType, int childPISArticleID)
            : base(concatType,
                  "PISArticlesTree",
                  "Code",
                  "Code",
                  new CommandFilter[1] { new CommandFilter("ParentPisArticleID", DBNull.Value, ComparisonType.EqualTo) })
        {
            _childPISArticleID = childPISArticleID;
        }
    }
}
