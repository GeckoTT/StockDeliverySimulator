using System;
using CareFusion.Mosaic.Interfaces.Converters;
using System.Collections.Generic;

namespace CareFusion.Mosaic.Interfaces.Messages.Stock
{
    /// <summary>
    /// Class which implements the ArticleInfoRequest Mosaic message.
    /// This request is used to request the detailed information for an article.
    /// </summary>
    public class ArticleInfoResponse : MosaicMessage
    {
        #region Constants
#warning duplication from PISAttribute, should be shared ?
        /// <summary>
        /// Attribute name for article that require to be stored in a fridge. 
        /// </summary>
        public const string RequiredFridge = "RequiredFridge";
        /// <summary>
        /// Attribute name for article that require 
        /// </summary>
        public const string ControlledDrug = "ControlledDrug";
        #endregion

        #region Members

        /// <summary>
        /// The list of optional additional article code of the requested article.
        /// </summary>
        private List<string> _additionalArticleCodes = new List<string>();

        /// <summary>
        /// The list of attribute of the requested article.
        /// </summary>
        private Dictionary<string, string> _attributes = new Dictionary<string, string>();

        /// <summary>
        /// Defines a list of child Article information.
        /// </summary>
        public List<ArticleInfoResponse> _childArticleInfo = new List<ArticleInfoResponse>();

        #endregion

        #region Properties

        /// <summary>
        /// Defines the Pis code of the requested article.
        /// </summary>
        public string PisArticleCode { get; set; }

        /// <summary>
        /// Defines the robot code of the requested article.
        /// </summary>
        public string RobotArticleCode { get; set; }

        /// <summary>
        /// Defines the name of the requested article.
        /// </summary>
        public string ArticleName { get; set; }

        /// <summary>
        /// Defines the dosage form of the requested article.
        /// </summary>
        public string DosageForm { get; set; }

        /// <summary>
        /// Defines the packaging unit of the requested article.
        /// </summary>
        public string PackagingUnit { get; set; }
        
        /// <summary>
        /// Defines the sub items per pack of the requested article.
        /// </summary>
        public int MaxSubItemQuantity { get; set; }

        /// <summary>
        /// Defines the expiry date of the requested article.
        /// </summary>
        public DateTime ExpiryDate { get; set; }

        /// <summary>
        /// Defines a list of optional additional article code of the requested article.
        /// </summary>
        public List<string> AdditionalArticleCodes { get { return _additionalArticleCodes; } }

        /// <summary>
        /// Defines a list of Attributes of the requested article.
        /// </summary>
        public Dictionary<string, string> Attributes { get { return _attributes; } }

        /// <summary>
        /// Defines a list of child Article information.
        /// </summary>
        public List<ArticleInfoResponse> ChildArticleInfo { get { return _childArticleInfo; } }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="ArticleInfoResponse"/> class.
        /// </summary>
        public ArticleInfoResponse()
            : base(MessageType.ArticleInfoResponse)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ArticleInfoResponse"/> class.
        /// </summary>
        /// <param name="converterStream">The converter stream which created the request.</param>
        public ArticleInfoResponse(IConverterStream converterStream)
            : base(MessageType.ArticleInfoResponse, converterStream)
        {
        }
    }
}
