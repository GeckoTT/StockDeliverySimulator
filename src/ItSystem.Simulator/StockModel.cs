using CareFusion.Lib.StorageSystem.Output;
using CareFusion.Lib.StorageSystem.Stock;
using System;
using System.Collections.Generic;
using System.Data;

namespace CareFusion.ITSystemSimulator
{
    /// <summary>
    /// Class which contains all relevant information of an article in the stock.
    /// It also provides mutable access to imutable data.
    /// </summary>
    public class StockArticle
    {
        #region Members

        /// <summary>
        /// The referenced imutable article. 
        /// </summary>
        private IArticle _article;

        /// <summary>
        /// The mutable list of packs which belong to this article.
        /// </summary>
        private List<IPack> _packs;

        #endregion

        #region Properties

        public string Id { get { return _article.Id; } }

        public string Name { get { return _article.Name; } }

        public string DosageForm { get { return _article.DosageForm; } }

        public string PackagingUnit { get { return _article.PackagingUnit; } }

        public uint MaxSubItemQuantity { get { return _article.MaxSubItemQuantity; } }

        public int PackCount { get { return _packs.Count; } }

        public IPack[] Packs { get { return _packs.ToArray(); } }

        public string VirtualId { get { return _article.VirtualId; } }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="StockArticle"/> class.
        /// </summary>
        /// <param name="article">The underlying imutable article reference.</param>
        public StockArticle(IArticle article)
        {
            if (article == null)
                throw new ArgumentException(nameof(article));

            _article = article;
            _packs = new List<IPack>();

            if ((_article.Packs != null) && (_article.Packs.Length > 0))
                _packs.AddRange(_article.Packs);
        }

        /// <summary>
        /// Adds the specified packs to the article.
        /// </summary>
        /// <param name="packs">The packs to add.</param>
        public void AddPacks(IPack[] packs)
        {
            if ((packs == null) || (packs.Length == 0))
                return;

            _packs.AddRange(packs);
        }

        /// <summary>
        /// Updates the specified packs of the article.
        /// </summary>
        /// <param name="packs">The packs to update.</param>
        public void UpdatePacks(IPack[] packs)
        {
            if ((packs == null) || (packs.Length == 0))
                return;

            foreach (var pack in packs)
            {
                var stockPackIndex = _packs.FindIndex(p => p.Id == pack.Id);

                if (stockPackIndex >= 0)
                {
                    _packs.Insert(stockPackIndex, pack);
                    _packs.RemoveAt(stockPackIndex + 1);
                }
                else
                {
                    _packs.Add(pack);
                }               
            }
        }
        
        /// <summary>
        /// Removes the specified packs from the article.
        /// </summary>
        /// <param name="packs">The packs to remove.</param>
        public void RemovePacks(IPack[] packs)
        {
            if ((packs == null) || (packs.Length == 0))
                return;

            foreach (var pack in packs)
            {
                var stockPackIndex = _packs.FindIndex(p => p.Id == pack.Id);

                if (stockPackIndex >= 0)
                    _packs.RemoveAt(stockPackIndex);
            }
        }
    }

    /// <summary>
    /// Class which contains the data model of the storage system stock.
    /// </summary>
    public class StockModel
    {
        #region Members

        /// <summary>
        /// Holds the list of articles in stock.
        /// </summary>
        private Dictionary<string, StockArticle> _articles = new Dictionary<string, StockArticle>();
        
        /// <summary>
        /// Holds the prepared article data model.
        /// </summary>
        private DataTable _articleModel = new DataTable();

        /// <summary>
        /// Holds the prepared pack data model.
        /// </summary>
        private DataTable _packModel = new DataTable();

        /// <summary>
        /// Holds the currently active filter which is applied to the data model.
        /// </summary>
        private string _filter = string.Empty;

        /// <summary>
        /// Holds the currently selected article.
        /// </summary>
        private StockArticle _selectedArticle = null;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the data model filter.
        /// </summary>
        public string Filter
        {
            get { return _filter; }
            set { _filter = value; UpdateModel(); }
        }

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

        /// <summary>
        /// Gets the list of currently active article codes.
        /// </summary>
        public string[] ArticleList
        {
            get 
            {
                var index = 0;
                var result = new string[_articles.Count];

                foreach (var articleId in _articles.Keys)
                    result[index++] = articleId;

                return result;
            }
        }

        /// <summary>
        /// Gets the overview of articles and their pack counts.
        /// </summary>
        public Dictionary<string, List<IPack>> ArticlePacks
        {
            get
            {
                var result = new Dictionary<string, List<IPack>>();

                foreach (var articleId in _articles.Keys)
                    result[articleId] = new List<IPack>(_articles[articleId].Packs);

                return result;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Initializes a new instance of the <see cref="StockModel"/> class.
        /// </summary>
        public StockModel()
        {
            DataColumn column = _articleModel.Columns.Add();
            column.DataType = typeof(string);
            column.ColumnName = "ID";

            column = _articleModel.Columns.Add();
            column.DataType = typeof(string);
            column.ColumnName = "Name";

            column = _articleModel.Columns.Add();
            column.DataType = typeof(string);
            column.ColumnName = "DosageForm";

            column = _articleModel.Columns.Add();
            column.DataType = typeof(string);
            column.ColumnName = "PackagingUnit";

            column = _articleModel.Columns.Add();
            column.DataType = typeof(uint);
            column.ColumnName = "MaxSubItemQuantity";

            column = _articleModel.Columns.Add();
            column.DataType = typeof(int);
            column.ColumnName = "PackCount";

            column = _articleModel.Columns.Add();
            column.DataType = typeof(string);
            column.ColumnName = "Virtual ID";

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
            column.DataType = typeof(DateTime);
            column.ColumnName = "StockInDate";

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
            _articles.Clear();
            _selectedArticle = null;

            UpdateModel();
        }

        /// <summary>
        /// Replaces the internal stock model with the specified article list.
        /// </summary>
        /// <param name="articleList">The article list to use.</param>
        public void Replace(List<IArticle> articleList)
        {
            if (articleList == null)
                throw new ArgumentException(nameof(articleList));

            _articles.Clear();

            foreach (var article in articleList)
                _articles[article.Id] = new StockArticle(article);

            _selectedArticle = (_articles.Count > 0) ? _articles[articleList[0].Id] : null;
            UpdateModel();
        }

        /// <summary>
        /// Updates the internal stock model with the specified article list.
        /// </summary>
        /// <param name="articleList">The article list to use.</param>
        public void Update(IArticle[] articleList)
        {
            if (articleList == null)
                throw new ArgumentException(nameof(articleList));
            
            foreach (var article in articleList)
            {
                var stockArticle = _articles.ContainsKey(article.Id) ? _articles[article.Id] : null;

                if (stockArticle == null)
                {
                    _articles[article.Id] = new StockArticle(article);
                    continue;
                }

                stockArticle.UpdatePacks(article.Packs);
            }

            UpdateModel();
        }

        /// <summary>
        /// Adds the specified list of articles to the stock model.
        /// </summary>
        /// <param name="articleList">List of articles to add.</param>
        public void Add(IArticle[] articleList)
        {
            foreach (var article in articleList)
            {
                var stockArticle = _articles.ContainsKey(article.Id) ? _articles[article.Id] : null;

                if (stockArticle == null)
                {
                    _articles[article.Id] = new StockArticle(article);
                    continue;
                }

                stockArticle.AddPacks(article.Packs);
            }

            UpdateModel();
        }

        /// <summary>
        /// Removes the specified list of articles from the stock model.
        /// </summary>
        /// <param name="articleList">List of articles to remove.</param>
        public void Remove(IArticle[] articleList)
        {
            foreach (var article in articleList)
            {
                var stockArticle = _articles.ContainsKey(article.Id) ? _articles[article.Id] : null;

                if (stockArticle == null)
                    continue;

                stockArticle.RemovePacks(article.Packs);

                if (stockArticle.PackCount == 0)
                    _articles.Remove(article.Id);
            }

            UpdateModel();
        }

        /// <summary>
        /// Removes the specified packs from the internal stock list.
        /// </summary>
        /// <param name="packs">The packs which were dispensed.</param>
        public void Remove(IDispensedPack[] packs)
        {
            if ((packs == null) || (packs.Length == 0))
                return;

            foreach (var dispensedPack in packs)
            {
                var stockArticle = _articles.ContainsKey(dispensedPack.ArticleId) ? _articles[dispensedPack.ArticleId] : null;

                if (stockArticle == null)
                    continue;

                stockArticle.RemovePacks(packs);

                if (stockArticle.PackCount == 0)
                    _articles.Remove(dispensedPack.ArticleId);
            }

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
            _selectedArticle = _articles.ContainsKey(articleCode) ? _articles[articleCode] : null;
            UpdatePackModel();
        }

        /// <summary>
        /// Updates the internal data model.
        /// </summary>
        private void UpdateModel()
        {
            _articleModel.Rows.Clear();
            _packModel.Rows.Clear();

            foreach (var articleCode in _articles.Keys)
            {
                if (string.IsNullOrEmpty(_filter) == false)
                {
                    bool keepArticle = articleCode.Contains(_filter);

                    keepArticle |= !String.IsNullOrEmpty(_articles[articleCode].VirtualId) &&
                                   _articles[articleCode].VirtualId.Contains(_filter);

                    if (!keepArticle)
                    {
                        if ((_selectedArticle != null) &&
                            (_selectedArticle.Id == articleCode))
                        {
                            _selectedArticle = null;
                        }

                        continue;
                    }
                }

                if (_selectedArticle == null)
                {
                    _selectedArticle = _articles[articleCode];
                }

                var article = _articles[articleCode];

                DataRow row = _articleModel.NewRow();
                row[0] = articleCode;
                row[1] = article.Name != null ? article.Name : string.Empty;
                row[2] = article.DosageForm != null ? article.DosageForm : string.Empty;
                row[3] = article.PackagingUnit != null ? article.PackagingUnit : string.Empty;
                row[4] = article.MaxSubItemQuantity;
                row[5] = article.PackCount;
                row[6] = article.VirtualId;
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
                    row[5] = pack.StockInDate;                    
                    row[6] = pack.IsInFridge;
                    row[7] = pack.Shape;
                    row[8] = pack.State;
                    row[9] = pack.SubItemQuantity;
                    row[10] = pack.Depth;
                    row[11] = pack.Width;
                    row[12] = pack.Height;
                    row[13] = pack.StockLocationId;
                    row[14] = pack.MachineLocation;
                    _packModel.Rows.Add(row);
                }
            }
        }

        #endregion
    }
}
