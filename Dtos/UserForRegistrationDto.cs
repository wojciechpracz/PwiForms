namespace pwiforms2.Dtos
{
    public class UserForRegistrationDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public int CountryId { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
    }
}