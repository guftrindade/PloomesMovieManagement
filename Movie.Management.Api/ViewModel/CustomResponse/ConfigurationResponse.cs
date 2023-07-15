using System.Net;

namespace Movie.Management.Api.ViewModel.CustomResponse
{
    public class ConfigurationResponse
    {
        public ErrorResponse SetErrorResponse(Exception ex)
        {
            return new ErrorResponse
            {
                Title = "An error occurred while processing your request.",
                StatusCode = (int)HttpStatusCode.InternalServerError,
                Message = ex.Message
            };
        }
    }
}
