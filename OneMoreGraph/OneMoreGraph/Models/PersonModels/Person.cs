using OneMoreGraph.Enums;

namespace OneMoreGraph.Models.PersonModels;

public class Person
{
    public int Id { get; set; }
    public Gender Gender { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public int Score { get; set; }
}