namespace BudgetManager.Exceptions
{
    public class NotFoundException : GenericException
    {
        public NotFoundException(string name) : base(string.Format("User not found [Name: {0}]", name), null, System.Net.HttpStatusCode.NotFound) { }
        public NotFoundException(int id) : base(string.Format("Resource not found [ID: {0}]", id), null, System.Net.HttpStatusCode.NotFound) { }
    }
}