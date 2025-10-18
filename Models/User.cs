using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;


namespace GoldCard.Models
{
    public class User
    {
        //[JsonIgnore]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string CustomerNumber { get; set; }
        [Required]
        public string Town { get; set; }

        //public override string ToString()
        //{
        //    return $"Namn: {FirstName} {LastName} Stad: {Town} Nr: {CustomerNumber}";
        //}
    }
}
