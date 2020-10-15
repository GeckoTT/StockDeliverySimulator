
namespace CareFusion.Mosaic.Interfaces.Components
{
    /// <summary>
    /// Enum which defines all the different types of supported Mosaic components.
    /// </summary>
    public enum ComponentType
    {
        Mosaic,
        /// <summary>
        /// Name of the Connector component type.
        /// </summary>
        Connector,

        /// <summary>
        /// Name of the Converter component type.
        /// </summary>
        Converter,

        /// <summary>
        /// Name of the Orchestration component type.
        /// </summary>
        Orchestration,

        /// <summary>
        /// Name of the BoxPicking module component type.
        /// </summary>
        BoxSystem,

        /// <summary>
        /// Name of the SchedulerTasks component type.
        /// </summary>
        SchedulerTask,

        /// <summary>
        /// Name of the PlcConnection component type.
        /// </summary>
        PlcConnection,

        /// <summary>
        /// Name of the WCF service component type.
        /// </summary>
        WcfService,

        /// <summary>
        /// Name of the pack conveyor component type.
        /// </summary>
        PackConveyor
    }

}
