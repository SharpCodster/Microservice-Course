namespace VivaioInCloud.Common.Exceptions
{
    public class DuplicatedItemException : Exception
    {
        public DuplicatedItemException() : base()
        {
        }

        public DuplicatedItemException(string message) : base(message)
        {
        }

        public DuplicatedItemException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
