namespace Business.Shared.Exceptions
{
    public class ForeignKeyException : Exception
    {
        public ForeignKeyException(string message) : base(message)
        {

        }
    }
}
