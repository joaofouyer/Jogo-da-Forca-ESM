namespace JFESM.Web.Validators
{
    public interface IValidator<T> where T : class
    {
        ValidationResult Validate(T objecToBeValidated);
    }
}