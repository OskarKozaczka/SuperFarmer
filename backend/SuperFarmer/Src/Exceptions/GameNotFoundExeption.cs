using System.Runtime.Serialization;

namespace SuperFarmer.Src
{
    [Serializable]
    internal class GameNotFoundExeption : Exception
    {
        public GameNotFoundExeption()
        {
        }

        public GameNotFoundExeption(string? message) : base(message)
        {
        }

        public GameNotFoundExeption(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected GameNotFoundExeption(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}