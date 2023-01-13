using System.ComponentModel.DataAnnotations;

namespace MoviesApp.Filters;

public class ShortNameOrLastNameAttribute : ValidationAttribute
{
    public ShortNameOrLastNameAttribute(int name, int lastName)
    {
        Name = name;
        LastName = lastName;
    }
    public int Name { get; }
    public int LastName { get; }

    public string GetErrorMessage() => $"The actor's first or last name must contain more than 4 sign";

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        string enterName = value.ToString();
        string enterLastName = value.ToString();
        if (enterLastName != null && enterName != null && (enterName.Length < Name || enterLastName.Length < LastName))
        {
            return new ValidationResult(GetErrorMessage());
        }
        
        return ValidationResult.Success;
    }
}