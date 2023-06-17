namespace Employee.Models.Client.Messages.Response
{
    public class ErrorData
    {
        public string ErrorMessage { get; set; }

        public bool HasError
        {
            get { return !string.IsNullOrEmpty(this.ErrorMessage); }
        }
    }
}