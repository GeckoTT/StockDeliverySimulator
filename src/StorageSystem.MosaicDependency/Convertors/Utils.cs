using MosaicDependency.Convertors.Wwks2.Messages.Unprocessed;
using MosaicDependency.Convertors.Wwks2.Types;

namespace MosaicDependency.Convertors
{
    /// <summary>
    /// Internal class that contains util methods for WWKS2
    /// </summary>
    internal static class Utils
    {
        /// <summary>
        /// Sends the unprocessed message.
        /// </summary>
        /// <param name="messageBody">The message body received.</param>
        /// <param name="reason">The reason for not processing the message.</param>
        internal static UnprocessedMessageEnvelope CreateUnprocessedMessage(string messageBody, UnprocessedMessageReason reason)
        {
            var id = messageBody.Contains(@"Id=") ? GetValue(messageBody, @"Id=") : "1";

            var sourceResult = default(int);
            var source = messageBody.Contains("Source=") ?
                    int.TryParse(GetValue(messageBody, "Source="), out sourceResult) ?
                        sourceResult
                        : default(int)
                    : default(int);

            var destinationResult = default(int);
            var destination = messageBody.Contains("Destination=") ?
                    int.TryParse(GetValue(messageBody, "Destination="), out destinationResult) ?
                        destinationResult
                        : default(int)
                    : default(int);

            var response = new UnprocessedMessageEnvelope
            {
                UnprocessedMessage = new UnprocessedMessage
                {
                    Id = id,
                    Source = destination,
                    Destination = source,
                    Reason = reason.ToString(),
                    Text = reason == UnprocessedMessageReason.SyntaxError ? "The message is not valid XML or has other syntactical errors" : "The object type is not supported",
                    Message = new Message
                    {
                        RawContent = messageBody
                    }
                }
            };

            return response;
        }

        /// <summary>
        /// Gets the value for a given match term within a string.
        /// </summary>
        /// <param name="messageBody">The message body received.</param>
        /// <param name="matchTerm">The match term.</param>
        /// <returns>The found value.</returns>
        private static string GetValue(string messageBody, string matchTerm)
        {
            var startIndex = messageBody.IndexOf(matchTerm) + matchTerm.Length + 1;
            var endIndex = messageBody.IndexOf("\"", startIndex);

            return messageBody.Substring(startIndex, endIndex - startIndex);
        }
    }
}
