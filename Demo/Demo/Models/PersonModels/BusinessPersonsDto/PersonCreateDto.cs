namespace Demo.Models.PersonModels.BusinessPersonsDto
{
    /// <summary>
    /// Create person model.
    /// </summary>
    /// <param name="Gender"></param>
    /// <param name="FirstName"></param>
    /// <param name="LastName"></param>
    /// <param name="Email"></param>
    /// <param name="Score"></param>
    public record PersonCreateDto(string Gender, string FirstName, string LastName, string Email, int Score);
    
}
