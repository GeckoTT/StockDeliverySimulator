using CareFusion.Lib.StorageSystem.Output;
using CareFusion.Lib.StorageSystem.Stock;
using System;
using System.Collections.Generic;
using System.Data;

namespace CareFusion.ITSystemSimulator
{
    /// <summary>
    /// Class which contains the data model for task information.
    /// </summary>
    public class TaskModel
    {
        #region Types

        /// <summary>
        /// Small helper class which is used as article stub.
        /// </summary>
        private class ArticleStub : IArticle
        {
            public string Id { get; set; }
            public string DosageForm { get; set;}            
            public string Name { get; set; }
            public uint MaxSubItemQuantity { get; set; }          
            public uint PackCount { get; set; }            
            public string PackagingUnit { get; set; }            
            public IPack[] Packs { get { return PackList.ToArray(); } }
            public string VirtualId { get; set; }

            public List<IPack> PackList = new List<IPack>();
        }

        #endregion

        #region Members

        /// <summary>
        /// Holds the article map.
        /// </summary>
        private Dictionary<string, IArticle> _articleMap = new Dictionary<string, IArticle>();

        /// <summary>
        /// Holds the prepared article data model.
        /// </summary>
        private DataTable _articleModel = new DataTable();

        /// <summary>
        /// Holds the prepared pack data model.
        /// </summary>
        private DataTable _packModel = new DataTable();

        /// <summary>
        /// Holds the currently selected article.
        /// </summary>
        private IArticle _selectedArticle = null;

        #endregion

        #region Properties

        /// <summary>
        /// Gets the currently active article data model.
        /// </summary>
        public DataTable Articles
        {
            get { return _articleModel; }
        }

        /// <summary>
        /// Gets the currently active pack data model.
        /// </summary>
        public DataTable Packs
        {
            get { return _packModel; }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Initializes a new instance of the <see cref="TaskModel"/> class.
        /// </summary>
        public TaskModel()
        {
            DataColumn column = _articleModel.Columns.Add();
            column.DataType = typeof(string);
            column.ColumnName = "ID";

            column = _articleModel.Columns.Add();
            column.DataType = typeof(uint);
            column.ColumnName = "Quantity";

            ////////////////////////////////////

            column = _packModel.Columns.Add();
            column.DataType = typeof(long);
            column.ColumnName = "ID";

            column = _packModel.Columns.Add();
            column.DataType = typeof(string);
            column.ColumnName = "Delivery";

            column = _packModel.Columns.Add();
            column.DataType = typeof(string);
            column.ColumnName = "Batch";

            column = _packModel.Columns.Add();
            column.DataType = typeof(string);
            column.ColumnName = "External ID";

            column = _packModel.Columns.Add();
            column.DataType = typeof(DateTime);
            column.ColumnName = "ExpiryDate";

            column = _packModel.Columns.Add();
            column.DataType = typeof(bool);
            column.ColumnName = "Fridge";

            column = _packModel.Columns.Add();
            column.DataType = typeof(PackShape);
            column.ColumnName = "Shape";

            column = _packModel.Columns.Add();
            column.DataType = typeof(PackState);
            column.ColumnName = "State";

            column = _packModel.Columns.Add();
            column.DataType = typeof(uint);
            column.ColumnName = "SubItems";

            column = _packModel.Columns.Add();
            column.DataType = typeof(int);
            column.ColumnName = "Depth";

            column = _packModel.Columns.Add();
            column.DataType = typeof(int);
            column.ColumnName = "Width";

            column = _packModel.Columns.Add();
            column.DataType = typeof(int);
            column.ColumnName = "Height";

            column = _packModel.Columns.Add();
            column.DataType = typeof(string);
            column.ColumnName = "StockLocation";

            column = _packModel.Columns.Add();
            column.DataType = typeof(string);
            column.ColumnName = "MachineLocation";
        }

        /// <summary>
        /// Clears all articles from the stock model.
        /// </summary>
        public void Clear()
        {
            _articleMap.Clear();
            _selectedArticle = null;

            UpdateModel();
        }

        /// <summary>
        /// Updates the internal task model with the specified article list.
        /// </summary>
        /// <param name="articles">The article list to use.</param>
        public void Update(IArticle[] articles)
        {
            _articleMap.Clear();

            foreach (var article in articles)
            {
                if (_articleMap.ContainsKey(article.Id) == false)
                {
                    _articleMap.Add(article.Id, article);
                }
            }

            _selectedArticle = (articles.Length > 0) ? articles[0] : null;
            UpdateModel();
        }

        /// <summary>
        /// Updates the internal task model with the specified pack list.
        /// </summary>
        /// <param name="articleList">The pack list to use.</param>
        public void Update(IDispensedPack[] packs)
        {
            _articleMap.Clear();

            var dummyArticle = new ArticleStub() { Id = "DUMMY"};
            dummyArticle.PackList.AddRange(packs);
            _articleMap.Add("DUMMY", dummyArticle);
            _selectedArticle = dummyArticle;

            UpdateModel();
        }

        /// <summary>
        /// Clears the article selection.
        /// </summary>
        public void ClearArticleSelection()
        {
            _selectedArticle = null;
            UpdatePackModel();
        }

        /// <summary>
        /// Selects the article with the specified article code.
        /// </summary>
        /// <param name="articleCode">Code of the article to select.</param>
        public void SelectArticle(string articleCode)
        {
            _selectedArticle = _articleMap.ContainsKey(articleCode) ? _articleMap[articleCode] : null;
            UpdatePackModel();
        }

        /// <summary>
        /// Updates the internal data model.
        /// </summary>
        private void UpdateModel()
        {
            _articleModel.Rows.Clear();
            _packModel.Rows.Clear();

            foreach (var articleCode in _articleMap.Keys)
            {
                if (_selectedArticle == null)
                {
                    _selectedArticle = _articleMap[articleCode];
                }

                var article = _articleMap[articleCode];

                DataRow row = _articleModel.NewRow();
                row[0] = articleCode;
                row[1] = article.PackCount;
                _articleModel.Rows.Add(row);
            }

            UpdatePackModel();
        }

        /// <summary>
        /// Updates the pack data model only.
        /// </summary>
        private void UpdatePackModel()
        {
            _packModel.Rows.Clear();

            if (_selectedArticle != null)
            {
                var packList = _selectedArticle.Packs;

                foreach (var pack in packList)
                {
                    DataRow row = _packModel.NewRow();
                    row[0] = pack.Id;
                    row[1] = pack.DeliveryNumber;
                    row[2] = pack.BatchNumber;
                    row[3] = pack.ExternalId;
                    row[4] = pack.ExpiryDate;
                    row[5] = pack.IsInFridge;
                    row[6] = pack.Shape;
                    row[7] = pack.State;
                    row[8] = pack.SubItemQuantity;
                    row[9] = pack.Depth;
                    row[10] = pack.Width;
                    row[11] = pack.Height;
                    row[12] = pack.StockLocationId;
                    row[13] = pack.MachineLocation;
                    _packModel.Rows.Add(row);
                }
            }
        }

        #endregion
    }
}
