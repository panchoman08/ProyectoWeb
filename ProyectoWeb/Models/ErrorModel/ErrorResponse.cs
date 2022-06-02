namespace ProyectoWeb.Models.ErrorModel
{
    public class ErrorResponse : Exception
    {
        public string ErrorMessage { get; set; }

        public ErrorResponse(string message)
        {
            ErrorMessage = message;
        }
    }

    public class ErrorException : Exception
    {
        public string ExceptionMessage;

        public ErrorException(string message)
        {
            this.ExceptionMessage = message;
        }
    }
}
