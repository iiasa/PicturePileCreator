namespace PPC.Utility.DTO.Exception
{
    public class ResourceMissingException : System.Exception
    {
        public ResourceMissingException()
        {
        }

        public ResourceMissingException(string message) : base(message)
        {
        }

        public ResourceMissingException(string message, System.Exception innerException) : base(message, innerException)
        {
        }
    }
}