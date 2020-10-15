using System.Data;
using CareFusion.Mosaic.Interfaces.Types.Database;
using System.Xml.Serialization;

namespace CareFusion.Mosaic.Interfaces.Types.Articles
{
    /// <summary>
    /// Class which represents an article which is stored in a storage system.
    /// </summary>
    public class RobotArticle : IDatabaseType
    {
        #region Properties

        /// <summary>
        /// Gets or sets the identifier of the article.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the Mosaic component which is assigned to this article.
        /// </summary>
        public int ComponentID { get; set; }

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
        /// Gets or sets a flag indicating whether this article requires fridge storage.
        /// </summary>
        public bool RequiresFridge { get; set; }

        /// <summary>
        /// Gets or sets a flag indicating whether this article is available.
        /// </summary>
        public bool IsAvailable { get; set; }
        
        /// <summary>
        /// Gets or sets a flag indicating whether this article is blocked.
        /// </summary>
        public bool IsBlocked { get; set; }

        /// <summary>
        /// Gets or sets the number of packs for this article.
        /// </summary>
        public int PackCount { get; set; }

        /// <summary>
        /// Gets or sets the number of subitems of the packs for this article.
        /// </summary>
        public int SubItemCount { get; set; }

        /// <summary>
        /// Gets or sets the maximum number of sub items for this article.
        /// </summary>
        public int MaxSubItemQuantity { get; set; }

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
                    "ID", "ComponentID", "Code", "Name", 
                    "DosageForm", "PackagingUnit", "RequiresFridge", "IsAvailable",
                    "IsBlocked", "MaxSubItemQuantity"
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
                    this.ComponentID,
                    this.Code,
                    this.Name,
                    this.DosageForm,
                    this.PackagingUnit,
                    this.RequiresFridge,
                    this.IsAvailable,
                    this.IsBlocked,
                    this.MaxSubItemQuantity
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
                return new string[] { "ID", "ComponentID" };
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
                return new object[] { this.ID, this.ComponentID };
            }
        }

        /// <summary>
        /// Gets an array of dependent database objects according to this object instance.
        /// These dependent objects are also serialized whenever this object instance is serialized.
        /// </summary>
        [XmlIgnore]
        public IDatabaseType[][] Dependencies 
        {
            // TODO: return article attributes.
            get { return null;  } 
        }

        #endregion 

        /// <summary>
        /// Initializes a new instance of the <see cref="RobotArticle"/> class.
        /// </summary>
        public RobotArticle()
        {
            this.Code = string.Empty;
            this.Name = string.Empty;
            this.DosageForm = string.Empty;
            this.PackagingUnit = string.Empty;
        }

        /// <summary>
        /// Loads the content of the database type from the specified database row object.
        /// </summary>
        /// <param name="dataRow">The database row object to load the database type from.</param>
        /// <param name="database">The database instance to use for loading additional dependencies.</param>
        public void Load(DataRow dataRow, DB.Database database)
        {
            this.ID = (int)dataRow["ID"];
            this.ComponentID = (int)dataRow["ComponentID"];
            this.Code = (string)dataRow["Code"];
            this.Name = (string)dataRow["Name"];
            this.DosageForm = (string)dataRow["DosageForm"];
            this.PackagingUnit = (string)dataRow["PackagingUnit"];
            this.RequiresFridge = (bool)dataRow["RequiresFridge"];
            this.IsAvailable = (bool)dataRow["IsAvailable"];
            this.IsBlocked = (bool)dataRow["IsBlocked"];
            this.MaxSubItemQuantity = (int)dataRow["MaxSubItemQuantity"];
        }
    }
}
