using pwiforms2.Models;

namespace pwiforms2.Dtos
{
    public class UserToReturnWithDetails
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
        public string Phone { get; set; }
    }
}