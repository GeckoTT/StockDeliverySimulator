using CareFusion.Mosaic.DB;
using CareFusion.Mosaic.Interfaces.Types.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Xml.Serialization;

namespace CareFusion.Mosaic.Interfaces.Types.Articles
{
    /// <summary>
    /// Class which represents a master article.
    /// </summary>
    [Serializable]
    public class PISArticle : IDatabaseType
    {
        #region Members
        /// <summary>
        /// Database reference to use for lazy loading.
        /// </summary>
        private DB.Database _database = null;

        /// <summary>
        /// Flag whether to lazy load attribute dependencies.
        /// </summary>
        private bool _attributesRequireLazyLoad = false;

        /// <summary>
        /// Holds the list of Attribute related to this Article.
        /// </summary>
        private PisArticleAttributeList _attributes = new PisArticleAttributeList();

        /// <summary>
        /// Flag whether to lazy load scan code dependencies.
        /// </summary>
        private bool _scanCodeRequireLazyLoad = false;

        /// <summary>
        /// Holds the list of Attribute related to this Article.
        /// </summary>
        private List<PisArticleScanCode> _scanCodes = new List<PisArticleScanCode>();

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the identifier of the article.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the parent article.
        /// </summary>
        public int? ParentPisArticleID { get; set; }

        /// <summary>
        /// Gets or sets the tenant identifier of the article.
        /// </summary>
        public string TenantID { get; set; }

        /// <summary>
        /// Gets or sets the system internal article code.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the name of the article.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the dosage form of the article.
        /// </summary>
        public string DosageForm { get; set; }

        /// <summary>
        /// Gets or sets the packaging unit of the article.
        /// </summary>
        public string PackagingUnit { get; set; }

        /// <summary>
        /// Gets or sets the maximum number of sub items for this article.
        /// </summary>
        public int MaxSubItemQuantity { get; set; }

        /// <summary>
        /// Gets or sets the code used to store this item on the Robot.
        /// </summary>
        public string RobotArticleCode { get; set; }
        
        /// <summary>
        /// Gets or sets the stock location identifier of the article.
        /// </summary>
        public string StockLocationID { get; set; }

        /// <summary>
        /// Gets or sets the machine location of the article.
        /// </summary>
        public string MachineLocation { get; set; }

        /// <summary>
        /// Gets or sets the flag whether batch number tracking is set or not.
        /// </summary>
        public bool BatchTracking { get; set; }

        /// <summary>
        /// Gets or sets the flag whether serial number tracking is set or not.
        /// </summary>
        public bool SerialTracking { get; set; }

        /// <summary>
        /// Gets or sets the flag whether expiry date tracking is set or not.
        /// </summary>
        public bool ExpiryTracking { get; set; }

        /// <summary>
        /// Gets the list of attributes which are assigned to this PISArticle
        /// </summary>
        public PisArticleAttributeList Attributes
        {
            get
            {
                if ((_attributesRequireLazyLoad) && (_database != null))
                {
                    _attributes.Load(_database, this.ID);
                    _attributesRequireLazyLoad = false;
                }

                return _attributes;
            }
        }

        /// <summary>
        /// Gets the list of scan code which are assigned to this PISArticle
        /// </summary>
        public List<PisArticleScanCode> ScanCodes
        {
            get
            {
                if ((_scanCodeRequireLazyLoad) && (_database != null))
                {
                    _scanCodes = _database.Query<PisArticleScanCode>(new CommandFilter("PisArticleID", this.ID));
                    _scanCodeRequireLazyLoad = false;
                }

                return _scanCodes;
            }
        }

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
                    "ID", "ParentPisArticleID", "TenantID", "Code", "Name", 
                    "DosageForm", "PackagingUnit", "MaxSubItemQuantity",
                    "RobotArticleCode", "StockLocationID", "MachineLocation",
                    "BatchTracking", "SerialTracking", "ExpiryTracking"
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
                    this.ID,
                    this.ParentPisArticleID,
                    this.TenantID,
                    this.Code,
                    this.Name,
                    this.DosageForm,
                    this.PackagingUnit,
                    this.MaxSubItemQuantity,
                    this.RobotArticleCode,
                    this.StockLocationID,
                    this.MachineLocation,
                    this.BatchTracking,
                    this.SerialTracking,
                    this.ExpiryTracking
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
                return new string[] { "ID", "TenantID" };
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
                return new object[] { this.ID, this.TenantID };
            }
        }

        /// <summary>
        /// Gets an array of dependent database objects according to this object instance.
        /// These dependent objects are also serialized whenever this object instance is serialized.
        /// </summary>
        [XmlIgnore]
        public IDatabaseType[][] Dependencies
        {
            get
            {
                IDatabaseType[][] result = new IDatabaseType[2][];

                // attributes
                result[0] = _attributes.ToArray();

                // Scan code.
                result[1] = ScanCodes.ToArray();

                return result;
            }
        }


        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="PISArticle"/> class.
        /// </summary>
        public PISArticle()
        {
            this.TenantID = string.Empty;
            this.Code = string.Empty;
            this.Name = string.Empty;
            this.DosageForm = string.Empty;
            this.PackagingUnit = string.Empty;
            this.RobotArticleCode = string.Empty;
            this.StockLocationID = string.Empty;
            this.MachineLocation = string.Empty;
            this.BatchTracking = default(bool);
            this.SerialTracking = default(bool);
            this.ExpiryTracking = default(bool);
        }

        /// <summary>
        /// Loads the content of the database type from the specified database row object.
        /// </summary>
        /// <param name="dataRow">The database row object to load the database type from.</param>
        /// <param name="database">The database instance to use for loading additional dependencies.</param>
        public void Load(DataRow dataRow, DB.Database database)
        {
            this.ID = (int)dataRow["ID"];
            this.ParentPisArticleID = (dataRow["ParentPisArticleID"] != System.DBNull.Value) ? (int?)dataRow["ParentPisArticleID"] : null ;
            this.TenantID = (string)dataRow["TenantID"];
            this.Code = (string)dataRow["Code"];
            this.Name = (string)dataRow["Name"];
            this.DosageForm = (string)dataRow["DosageForm"];
            this.PackagingUnit = (string)dataRow["PackagingUnit"];
            this.MaxSubItemQuantity = (int)dataRow["MaxSubItemQuantity"];

            if (dataRow["RobotArticleCode"] != System.DBNull.Value)
            {
                this.RobotArticleCode = (string)dataRow["RobotArticleCode"];
            }

            this.StockLocationID = (string)dataRow["StockLocationID"];
            this.MachineLocation = (string)dataRow["MachineLocation"];

            this.BatchTracking = (bool)dataRow["BatchTracking"];
            this.SerialTracking = (bool)dataRow["SerialTracking"];
            this.ExpiryTracking = (bool)dataRow["ExpiryTracking"];

            _attributesRequireLazyLoad = true;
            _scanCodeRequireLazyLoad = true;
            _database = database;
        }
    }
}


