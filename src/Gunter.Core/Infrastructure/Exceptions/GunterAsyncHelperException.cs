namespace Gunter.Core.Infrastructure.Exceptions
{
    public class GunterAsyncHelperException : Exception
    {
        public GunterAsyncHelperException(string message) : base(message)
        {

        }

        public GunterAsyncHelperException(string message, Exception ex) : base(message, ex)
        {

        }
    }
}
