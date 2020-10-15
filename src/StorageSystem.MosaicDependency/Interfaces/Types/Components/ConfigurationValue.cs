using System;
using System.Data;
using CareFusion.Mosaic.Interfaces.Types.Database;

namespace CareFusion.Mosaic.Interfaces.Types.Components
{
    /// <summary>
    /// Class which represents a Mosaic component's configuration value.
    /// </summary>
    public class ConfigurationValue : IDatabaseType
    {
        #region Properties

        /// <summary>
        /// Gets or sets the identifier of the Mosaic component this configuration value belongs to.
        /// </summary>
        public int ComponentID { get; set; }

        /// <summary>
        /// Gets or sets the name of the configuration value.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the value of the configuration value.
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Gets an array of the property names of this object.
        /// These names are required to serialize this object to the database.
        /// </summary>
        public string[] PropertyNames
        {
            get { return new string[] { "ComponentID", "Name", "Value" }; }
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
                    this.ComponentID, 
                    this.Name, 
                    (this.Value != null) ? this.Value : (object)DBNull.Value
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
                return new string[] { "ComponentID", "Name" };
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
                return new object[] { this.ComponentID, this.Name };
            }
        }

        /// <summary>
        /// Gets an array of dependent database objects according to this object instance.
        /// These dependent objects are also serialized whenever this object instance is serialized.
        /// </summary>
        public IDatabaseType[][] Dependencies { get { return null; } }

        #endregion

        /// <summary>
        /// Loads the content of the database type from the specified database row object.
        /// </summary>
        /// <param name="dataRow">The database row object to load the database type from.</param>
        /// <param name="database">The database instance to use for loading additional dependencies.</param>
        public void Load(DataRow dataRow, DB.Database database)
        {
            this.ComponentID = (int)dataRow["ComponentID"];
            this.Name = (string)dataRow["Name"];
            object rowValue = dataRow["Value"];
            this.Value = (rowValue != DBNull.Value) ? (string)rowValue : string.Empty;        
        }       
    }
}
