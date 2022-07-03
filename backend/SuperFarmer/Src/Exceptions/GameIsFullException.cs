using System.Runtime.Serialization;

namespace SuperFarmer.Src
{
    [Serializable]
    internal class GameIsFullException : Exception
    {
        public GameIsFullException()
        {
        }

        public GameIsFullException(string? message) : base(message)
        {
        }

        public GameIsFullException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected GameIsFullException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}