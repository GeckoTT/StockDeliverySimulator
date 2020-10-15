using System;
using System.Data;
using CareFusion.Mosaic.Interfaces.Components;
using CareFusion.Mosaic.Interfaces.Types.Database;

namespace CareFusion.Mosaic.Interfaces.Types.Components
{
    /// <summary>
    /// Class which represents a Mosaic component database type.
    /// </summary>
    public class Component : IDatabaseType
    {
        #region Properties

        /// <summary>
        /// Gets or sets the identifier of the Mosaic component.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the type of the Mosaic component.
        /// </summary>
        public ComponentType Type { get; set; }

        /// <summary>
        /// Gets or sets the relative path of the assembly that contains the Mosaic component.
        /// If the component is hosted within the Mosaic application itself, this property is an empty string.
        /// </summary>
        public string Assembly { get; set; }

        /// <summary>
        /// Gets or sets the full name of the class that implements the Mosaic component.
        /// </summary>
        public string ClassName { get; set; }

        /// <summary>
        /// Gets or sets the description of the Mosaic component.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets a flag which identifies marks the component as active.
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the Mosaic component which is connected with this component.
        /// </summary>
        public int ConnectedComponentID { get; set; }

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
                    "ID", "Type", "Assembly", "ClassName", 
                    "Description", "IsActive", "ConnectedComponentID"
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
                    this.Type.ToString(),
                    this.Assembly,
                    this.ClassName,
                    this.Description,
                    this.IsActive,
                    (this.ConnectedComponentID > 0) ? (object)this.ConnectedComponentID : DBNull.Value
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
                return new string[] { "ID" };
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
                return new object[] { this.ID };
            }
        }

        /// <summary>
        /// Gets an array of dependent database objects according to this object instance.
        /// These dependent objects are also serialized whenever this object instance is serialized.
        /// </summary>
        public IDatabaseType[][] Dependencies { get { return null; } }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="Component"/> class.
        /// </summary>
        public Component()
        {
            this.Assembly = string.Empty;
            this.ClassName = string.Empty;
            this.Description = string.Empty;
        }

        /// <summary>
        /// Loads the content of the data type from the specified database row object.
        /// </summary>
        /// <param name="dataRow">The database row object to load the data type from.</param>
        /// <param name="database">The database instance to use for loading additional dependencies.</param>
        public void Load(DataRow dataRow, DB.Database database)
        {
            this.ID = (int)dataRow["ID"];
            this.Type = (ComponentType)Enum.Parse(typeof(ComponentType), (string)dataRow["Type"]);
            this.Assembly = (string)dataRow["Assembly"];
            this.ClassName = (string)dataRow["ClassName"];
            this.Description = (string)dataRow["Description"];
            this.IsActive = (bool)dataRow["IsActive"];

            object idValue = dataRow["ConnectedComponentID"];
            this.ConnectedComponentID = (idValue != DBNull.Value) ? (int)idValue : 0;
        }       
    }
}
