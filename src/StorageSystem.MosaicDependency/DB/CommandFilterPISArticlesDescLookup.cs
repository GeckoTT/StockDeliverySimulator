using System;

namespace CareFusion.Mosaic.DB
{
    public interface CommandFilterWithClause
    {
        /// <summary>
        /// Gets the text representation of the filter object.
        /// </summary>
        string GetWithClauseText();

        /// <summary>
        /// Gets the CommandFilters specific to the 'with' clause.
        /// </summary>
        CommandFilter[] GetWithClauseCommandFilter();
    }




    /// <summary>
    /// Class which implements the logic to get related Robot article codes of a parent PIS code.
    /// </summary>
    public class CommandFilterPISArticlesDescLookup : CommandFilterNestedQuery, CommandFilterWithClause
    {
        #region Members
        private string _parentPISArticleCode;
        #endregion

        #region Properties
        /// <summary>
        /// Gets the text representation of the filter object.
        /// </summary>
        public string GetWithClauseText()
        {
            // 'level' field in the query is used to limit the deep of the query. in Case of a reference loop, if wouldn't loop forever
            return string.Format(@"with RECURSIVE PISArticlesTree(ParentPisArticleID, ID, code, RobotArticleCode, level) as
                (Select null, ID, code, RobotArticleCode, 0 from PISArticles where code = @ParentPISArticleCode0
                UNION ALL
                Select pisArticleChild.ParentPisArticleID, pisArticleChild.ID, pisArticleChild.code, pisArticleChild.RobotArticleCode, level + 1 
                    from PISArticles pisArticleChild
                    inner join PISArticlesTree as pisArticleParent on pisArticleChild.ParentPisArticleID = pisArticleParent.id and level < 100)
                ");
        }

        /// <summary>
        /// Gets the CommandFilters specific to the 'with' clause.
        /// </summary>
        public CommandFilter[] GetWithClauseCommandFilter()
        {
            return new CommandFilter[1] { new CommandFilter("ParentPISArticleCode", _parentPISArticleCode) };
        }
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandFilterPISArticlesDescLookup"/> class.
        /// </summary>
        /// <param name="concatType">Concatination type of the group.</param>
        /// <param name="parentPISArticleCode">Parent PIS article code</param>
        public CommandFilterPISArticlesDescLookup(ConcatenationType concatType, string parentPISArticleCode)
            : base(concatType,
                  "PISArticlesTree",
                  "RobotArticleCode",
                  "RobotArticleCode",
                  new CommandFilter[1] { new CommandFilter("RobotArticleCode", DBNull.Value, ComparisonType.NotEqualTo) })
        {
            _parentPISArticleCode = parentPISArticleCode;
        }
    }
}
