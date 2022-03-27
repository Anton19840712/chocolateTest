using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.Models.PersonModels.DalPersonsDto
{
    /// <summary>
    /// Dal model to communicate with database.
    /// </summary>
    public class PersonDalDto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public int Score { get; set; }
    }
}
