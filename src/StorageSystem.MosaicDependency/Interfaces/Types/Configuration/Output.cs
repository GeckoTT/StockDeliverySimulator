using System;
using System.Data;
using CareFusion.Mosaic.Interfaces.Types.Database;

namespace CareFusion.Mosaic.Interfaces.Types.Configuration
{
    /// <summary>
    /// Class which represents an output for a transport system.
    /// </summary>
    public class Output : IDatabaseType
    {
        #region IDatabaseType Implementation

        /// <summary>
        /// Gets an array of dependent database objects according to this object instance.
        /// These dependent objects are also serialized whenever this object instance is serialized.
        /// </summary>
        public IDatabaseType[][] Dependencies
        {
            get
            {
                return null;
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
                return new string[] { "Number" };
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
                return new object[] { this.Number };
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
                    "Number", "NumberInConveyorSystem", "Name", "Description",
                    "ExternalIdentifier", "AreSpecialPacksAllowed", "IsTrash", "IsDisabled"
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
                    this.Number,
                    this.NumberInConveyorSystem,
                    this.Name,
                    this.Description,
                    this.ExternalIdentifier,
                    this.AreSpecialPacksAllowed,
                    this.IsTrash,
                    this.IsDisabled
                };
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Output"/> class.
        /// </summary>
        public Output()
        {
            this.Number = 0;
            this.NumberInConveyorSystem = 0;
            this.Name = string.Empty;
            this.Description = string.Empty;
            this.ExternalIdentifier = string.Empty;
            this.AreSpecialPacksAllowed = false;
            this.IsTrash = false;
            this.IsDisabled = false;
        }

        /// <summary>
        /// Loads the content of the data type from the specified database row object.
        /// </summary>
        /// <param name="dataRow">The database row object to load the data type from.</param>
        /// <param name="database">The database instance to use for loading additional dependencies.</param>
        public void Load(DataRow dataRow, DB.Database database)
        {
            this.Number = (int)dataRow["Number"];
            this.NumberInConveyorSystem = (int)dataRow["NumberInConveyorSystem"];
            this.Name = (string)dataRow["Name"];
            this.Description = (string)dataRow["Description"];
            this.ExternalIdentifier = (string)dataRow["ExternalIdentifier"];
            this.AreSpecialPacksAllowed = (bool)dataRow["AreSpecialPacksAllowed"];
            this.IsTrash = (bool)dataRow["IsTrash"];
            this.IsDisabled = (bool)dataRow["IsDisabled"];
        }

        #endregion

        #region Properties

        public string Name { get; set; }

        public int Number { get; set; }

        public bool IsDisabled { get; set; }

        public string Description { get; set; }

        public int NumberInConveyorSystem { get; set; }

        public string ExternalIdentifier { get; set; }

        public bool IsTrash { get; set; }

        public bool AreSpecialPacksAllowed { get; set; }

        #endregion
    }
}
