using System.Collections.Generic;

namespace CareFusion.Mosaic.Interfaces.Types.Configuration
{
    /// <summary>
    /// Class which represents a conveyor system
    /// </summary>
    public class ConveyorSystem
    {
        #region Members

        private List<Output> _outputs = new List<Output>();
        private List<HandoverPoint> _handOverPoints = new List<HandoverPoint>();

        #endregion

        #region Properties

        public string Name { get; set; }

        public bool IsDisabled { get; set; }

        public string IpAddress { get; set; }

        public ConveyorType Type { get; set; }

        public List<Output> Outputs { get { return _outputs; } }

        public List<HandoverPoint> HandoverPoints { get { return _handOverPoints; } }

        #endregion
    }
}
