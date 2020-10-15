using CareFusion.Mosaic.DB;
using CareFusion.Mosaic.Interfaces.Types.Database;
using System.Collections.Generic;
using System.Data;

namespace CareFusion.Mosaic.Interfaces.Types.Articles
{
    /// <summary>
    /// Class which represents a list of PIS article attibute.
    /// </summary>
    public class PisArticleAttributeList
    {
        private Dictionary<string, PisArticleAttribute> _attributes;

        public PisArticleAttributeList()
        {
            _attributes = new Dictionary<string, PisArticleAttribute>();
        }

        /// <summary>
        /// Loads the attribute from related PIS ID.
        /// </summary>
        /// <param name="dataRow">The database row object to load the database type from.</param>
        /// <param name="database">The database instance to use for loading additional dependencies.</param>
        public void Load(DB.Database _database, int pisArticleID)
        {
            List<PisArticleAttribute> unsortedAttribute = _database.Query<PisArticleAttribute>(new CommandFilter("PisArticleID", pisArticleID));

            foreach (PisArticleAttribute attribute in unsortedAttribute)
            {
                _attributes.Add(attribute.Name, attribute);
            }
        }

        public PisArticleAttribute[] ToArray()
        {
            PisArticleAttribute[] attributeAsArray = new PisArticleAttribute[_attributes.Values.Count];
            _attributes.Values.CopyTo(attributeAsArray, 0);
            return attributeAsArray;
        }

        public void SetPISArticleID(int pisArticleID, string tenantID)
        {
            foreach (KeyValuePair<string, PisArticleAttribute> keyValuePair in _attributes)
            {
                keyValuePair.Value.PisArticleID = pisArticleID;
                keyValuePair.Value.TenantID = tenantID;
            }
        }

        public void RemoveAttribute(string attributeName)
        {
            _attributes.Remove(attributeName);
        }

        public bool AttributeExist(string attributeName)
        {
            return _attributes.ContainsKey(attributeName);
        }

        public PisArticleAttribute this[string attributeName]
        {
            get
            {
                if (!_attributes.ContainsKey(attributeName))
                {
                    _attributes.Add(attributeName, new PisArticleAttribute()
                    {
                        PisArticleID = 0,
                        Name = attributeName,
                    });
                }

                return _attributes[attributeName];
            }
        }
    }


    /// <summary>
    /// Class which represents a PIS article attibute.
    /// </summary>
    public class PisArticleAttribute : IDatabaseType
    {
        #region Constants
        /// <summary>
        /// Attribute name for article that require to be stored in a fridge. 
        /// </summary>
        public const string RequiredFridge = "RequiredFridge";

        /// Attribute name for article that require to be stored as a controlled drug. 
        /// </summary>
        public const string ControlledDrug = "ControlledDrug";

        /// Attribute name for article that can be stored in the robot
        /// </summary>
        public const string RobotHandlingAllowed = "RobotHandlingAllowed";

        #endregion

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
        /// Gets or sets the name of the article attribute.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the Value of the article attribute.
        /// </summary>
        public string Value { get; set; }
        
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
                    "PisArticleID", "TenantID", "Name", "Value"
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
                    this.Name,
                    this.Value
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
                return new string[] { "PisArticleID", "Name" };
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
                return new object[] { this.PisArticleID, this.Name };
            }
        }

        /// <summary>
        /// Gets an array of dependent database objects according to this object instance.
        /// These dependent objects are also serialized whenever this object instance is serialized.
        /// </summary>
        public IDatabaseType[][] Dependencies
        {
            get { return null; }
        }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="PisArticleAttribute"/> class.
        /// </summary>
        public PisArticleAttribute()
        {
            this.Name = string.Empty;
            this.Value = string.Empty;
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
            this.Name = (string)dataRow["Name"];
            this.Value = (string)dataRow["Value"];
        }
    }
}
