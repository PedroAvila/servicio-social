using System.Text;
using FluentValidation.Results;

namespace ServicioSocial.Services
{
    public class Validator
    {
        public static string GetErrorMessages(IEnumerable<ValidationFailure> errorResult)
        {
            var errorList = new StringBuilder();
            foreach (var error in errorResult)
            {
                errorList.AppendLine(error.ErrorMessage);
            }
            return errorList.ToString();
        }
    }
}