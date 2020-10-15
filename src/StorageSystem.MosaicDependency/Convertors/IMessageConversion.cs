using CareFusion.Mosaic.Interfaces.Converters;
using CareFusion.Mosaic.Interfaces.Messages;

namespace CareFusion.Mosaic.Converters
{
    /// <summary>
    /// Interface of converter objects that are able to convert themselve into a Mosaic message.
    /// </summary>
    public interface IMessageConversion
    {
        /// <summary>
        /// Translates this object instance into a Mosaic message.
        /// </summary>
        /// <param name="converterStream">
        /// The converter stream instance which request the message conversion.
        /// </param>
        /// <returns>
        /// The Mosaic message representation of this object.
        /// </returns>
        MosaicMessage ToMosaicMessage(IConverterStream converterStream);
    }

}
