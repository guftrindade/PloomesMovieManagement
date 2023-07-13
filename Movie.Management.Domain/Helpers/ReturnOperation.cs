namespace Movie.Management.Domain.Helpers
{

    public class ResultOperation<T> where T : class
    {
        public ResultOperation()
        {
            Errors = new ResponseErrorMessages();
        }

        public bool Success { get { return !Errors.Mensagens.Any(); } }

        public ResponseErrorMessages Errors { get; set; }

        public T Result { get; set; }
    }

    public class ResponseErrorMessages
    {
        public ResponseErrorMessages()
        {
            Mensagens = new List<string>();
        }

        public List<string> Mensagens { get; set; }
    }
}