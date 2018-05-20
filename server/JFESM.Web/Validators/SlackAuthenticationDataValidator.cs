using JFESM.Web.Controllers.Items;

namespace JFESM.Web.Validators
{
    public class SlackAuthenticationDataValidator : IValidator<SlackUserDTO>
    {
        
        public ValidationResult Validate(SlackUserDTO value)
        {
            var validationResult = new ValidationResult();

            if (value == null)
            {
                validationResult.ErrorMessage = "Dados inválidos.";
            }
            else
            {
                if (value.User == null)
                {
                    validationResult.ErrorMessage =  "Informações do usuário inválidas";
                }
                else
                {
                    var userEmail = value.User.Email;
                    if (string.IsNullOrWhiteSpace(userEmail))
                    {
                        validationResult.ErrorMessage =  "Email é obrigatório";
                    }
                }
            }

            return validationResult;
        }
    }
}