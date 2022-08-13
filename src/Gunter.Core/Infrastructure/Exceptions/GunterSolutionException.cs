namespace Gunter.Core.Infrastructure.Exceptions
{
    public class GunterSolutionException : Exception
    {
        public GunterSolutionException(string message) : base(message)
        {

        }

        public GunterSolutionException(string message, Exception ex) : base(message, ex)
        {

        }

    }
}
