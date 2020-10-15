using System.Collections.Generic;
using System.Data;

namespace CareFusion.Mosaic.Interfaces.Types.Database
{
    /// <summary>
    /// Interface which defines all methods that are required by the Mosaic database backend 
    /// to loaded and save a plain CLR type in one of the Mosaic databases.
    /// </summary>
    public interface IDatabaseType
    {
        #region Properties

        /// <summary>
        /// Gets an array of the property names of this object.
        /// These names are required to serialize this object to the database.
        /// </summary>
        string[] PropertyNames { get; }

        /// <summary>
        /// Gets an array of the raw property values of this object.
        /// These values are required to serialize this object to the database.
        /// </summary>
        object[] PropertyValues { get; }

        /// <summary>
        /// Gets an array of the property names which define the unique key of this object.
        /// These names are required to delete this object from the database.
        /// </summary>
        string[] KeyPropertyNames { get; }

        /// <summary>
        /// Gets an array of the raw property values which define the unique key of this object.
        /// These names are required to delete this object from the database.
        /// </summary>
        object[] KeyPropertyValues { get; }

        /// <summary>
        /// Gets an array of dependent database objects according to this object instance.
        /// These dependent objects are also serialized whenever this object instance is serialized.
        /// </summary>
        IDatabaseType[][] Dependencies { get; }

        #endregion

        #region Members

        /// <summary>
        /// Loads the content of the database type from the specified database row object.
        /// </summary>
        /// <param name="dataRow">The database row object to load the database type from.</param>
        /// <param name="database">The database instance to use for loading additional dependencies.</param>
        void Load(DataRow dataRow, DB.Database database);

        #endregion
    }
}
