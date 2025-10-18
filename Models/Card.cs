using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;


namespace GoldCard.Models
{
    public class Card
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public int Id { get; set; }

        [Required]
        public string CardNumber { get; set; }
        [Required]
        public string CardType { get; set; }
    }
}
