namespace HotelManagerAPI.Models
{
    public class GuestDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }

        public string FullName => FirstName + " " + LastName;
    }
}