namespace Gunter.Core.Infrastructure.Exceptions
{
    public class GunterInfoSourceException : Exception
    {

        public GunterInfoSourceException(string message) : base(message)
        {

        }

        public GunterInfoSourceException(string message, Exception ex) : base(message, ex)
        {

        }

    }
}
