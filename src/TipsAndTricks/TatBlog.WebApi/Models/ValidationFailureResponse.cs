using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TatBlog.WebApi.Models
{
    public class ValidationFailureResponse
    {
        public IEnumerable<string> Errors { get; set; }
        public ValidationFailureResponse(
            IEnumerable<string> errorMessages)
        {
            Errors = errorMessages;

        }
    }

}



