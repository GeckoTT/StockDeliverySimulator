using CareFusion.Mosaic.Interfaces.Types.Database;
using System.Data;
using System.Xml.Serialization;

namespace CareFusion.Mosaic.Interfaces.Types.Articles
{
    public class PisArticleScanCode : IDatabaseType
    {
        #region Properties

        /// <summary>
        /// Gets or sets the identifier of the related PisArticle.
        /// </summary>
        public int PisArticleID { get; set; }

        /// <summary>
        /// Gets or sets the TenantID of the related PisArticle.
        /// </summary>
        public string TenantID { get; set; }

        /// <summary>
        /// Gets or sets the scan code.
        /// </summary>
        public string ScanCode { get; set; }

        /// <summary>
        /// Gets an array of the property names of this object.
        /// These names are required to serialize this object to the database.
        /// </summary>
        public string[] PropertyNames
        {
            get
            {
                return new string[]
                {
                    "PisArticleID", "TenantID", "ScanCode"
                };
            }
        }

        /// <summary>
        /// Gets an array of the raw property values of this object.
        /// These values are required to serialize this object to the database.
        /// </summary>
        public object[] PropertyValues
        {
            get
            {
                return new object[]
                {
                    this.PisArticleID,
                    this.TenantID,
                    this.ScanCode,
                };
            }
        }

        /// <summary>
        /// Gets an array of the property names which define the unique key of this object.
        /// These names are required to delete this object from the database.
        /// </summary>
        public string[] KeyPropertyNames
        {
            get
            {
                return new string[] { "TenantID", "ScanCode" };
            }
        }

        /// <summary>
        /// Gets an array of the raw property values which define the unique key of this object.
        /// These names are required to delete this object from the database.
        /// </summary>
        public object[] KeyPropertyValues
        {
            get
            {
                return new object[] { this.TenantID, this.ScanCode };
            }
        }

        /// <summary>
        /// Gets an array of dependent database objects according to this object instance.
        /// These dependent objects are also serialized whenever this object instance is serialized.
        /// </summary>
        [XmlIgnore]
        public IDatabaseType[][] Dependencies
        {
            get { return null; }
        }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="PisArticleScanCode"/> class.
        /// </summary>
        public PisArticleScanCode()
        {
            this.ScanCode = string.Empty;
        }

        /// <summary>
        /// Loads the content of the database type from the specified database row object.
        /// </summary>
        /// <param name="dataRow">The database row object to load the database type from.</param>
        /// <param name="database">The database instance to use for loading additional dependencies.</param>
        public void Load(DataRow dataRow, DB.Database database)
        {
            this.PisArticleID = (int)dataRow["PisArticleID"];
            this.TenantID = (string)dataRow["TenantID"];
            this.ScanCode = (string)dataRow["ScanCode"];
        }
    }
}
