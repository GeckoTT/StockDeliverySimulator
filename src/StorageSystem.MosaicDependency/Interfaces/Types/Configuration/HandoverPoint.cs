namespace CareFusion.Mosaic.Interfaces.Types.Configuration
{
    /// <summary>
    /// Class which represents an hand over point for a transport system.
    /// </summary>
    public class HandoverPoint
    {
        public string Name { get; set; }

        public int Index { get; set; }

        public string ExternalIdentifier { get; set; }

        public int MinPackLength { get; set; }

        public int MaxPackDiagonalSize { get; set; }

        public int ContainerDiameter { get; set; }
        
        public int ContainerLength { get; set; }

        public bool HasLabelPrinter { get; set; }
    }
}
