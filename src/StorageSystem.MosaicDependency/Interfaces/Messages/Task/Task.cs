
using CareFusion.Mosaic.Interfaces.Types.Input;
using CareFusion.Mosaic.Interfaces.Types.Output;
using System.Collections.Generic;
namespace CareFusion.Mosaic.Interfaces.Messages.Task
{
    /// <summary>
    /// Class which represents a task (e.g. output process) within Mosaic.
    /// </summary>
    public class Task
    {
        #region Members

        /// <summary>
        /// The list of box numbers that belong to this task.
        /// </summary>
        private List<string> _boxNumbers = new List<string>();

        /// <summary>
        /// The list of order item packs that belong to this task.
        /// </summary>
        private List<StockOutputOrderItemPack> _outputPacks = new List<StockOutputOrderItemPack>();

        /// <summary>
        /// The list of stock delivery items that belong to this task.
        /// </summary>
        private List<StockDeliveryItem> _deliveryItems = new List<StockDeliveryItem>();

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the identifier of the task.
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// Gets or sets the type of the task.
        /// </summary>
        public TaskType Type { get; set; }

        /// <summary>
        /// Gets or sets the current state of the task.
        /// </summary>
        public TaskState State { get; set; }

        /// <summary>
        /// The list of output order item packs that belong to this task.
        /// </summary>
        public List<StockOutputOrderItemPack> OutputPacks { get { return _outputPacks; } }

        /// <summary>
        /// The list of stock delivery items that belong to this task.
        /// </summary>
        public List<StockDeliveryItem> DeliveryItems { get { return _deliveryItems; } }

        /// <summary>
        /// The list of box numbers that belong to this task.
        /// </summary>
        public List<string> BoxNumbers { get { return _boxNumbers; } }

        #endregion
    }
}
