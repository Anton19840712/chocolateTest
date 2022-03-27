namespace Demo.Models.PersonModels.ResponsePersonsDto
{
    /// <summary>
    /// Response model for UI.
    /// </summary>
    public class ResponsePersonDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public int Score { get; set; }
    }
}
