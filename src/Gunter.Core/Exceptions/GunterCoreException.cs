namespace Gunter.Core.Infrastructure.Exceptions
{
    public class GunterCoreException : Exception
    {

        public GunterCoreException(string message) : base(message)
        {

        }

        public GunterCoreException(string message, Exception ex) : base(message, ex)
        {

        }
    }
}