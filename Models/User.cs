namespace GoldCard.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CustomerNumber { get; set; }
        public string Town { get; set; }

        //public override string ToString()
        //{
        //    return $"Namn: {FirstName} {LastName} Stad: {Town} Nr: {CustomerNumber}";
        //}
    }
}
