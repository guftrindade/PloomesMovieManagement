namespace Movie.Management.Domain.Helpers
{

    public class ResultOperation<T> where T : class
    {
        public ResultOperation()
        {
            Errors = new ResponseErrorMessages();
        }

        public bool Success { get { return !Errors.Messages.Any(); } }

        public ResponseErrorMessages Errors { get; set; }

        public T Result { get; set; }
    }

    public class ResponseErrorMessages
    {
        public ResponseErrorMessages()
        {
            Messages = new List<string>();
        }

        public List<string> Messages { get; set; }
    }
}