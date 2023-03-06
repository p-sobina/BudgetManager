namespace BudgetManager.Exceptions
{
    public class AuthenticationFailedException : GenericException
    {
        public AuthenticationFailedException() : base("Authentication failed", null, System.Net.HttpStatusCode.Unauthorized) { }
    }
}
