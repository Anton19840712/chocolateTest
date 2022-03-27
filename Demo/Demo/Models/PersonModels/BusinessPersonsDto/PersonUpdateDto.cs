namespace Demo.Models.PersonModels.BusinessPersonsDto
{
    /// <summary>
    /// Update person model.
    /// </summary>
    public class PersonUpdateDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public int Score { get; set; }
    };
}
