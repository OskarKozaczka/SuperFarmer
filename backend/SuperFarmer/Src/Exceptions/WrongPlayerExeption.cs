using System.Runtime.Serialization;

namespace SuperFarmer.Src
{
    [Serializable]
    internal class WrongPlayerExeption : Exception
    {
        public WrongPlayerExeption()
        {
        }

        public WrongPlayerExeption(string? message) : base(message)
        {
        }

        public WrongPlayerExeption(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected WrongPlayerExeption(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}