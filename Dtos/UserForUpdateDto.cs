namespace PwiForms.Dtos
{
    public class UserForUpdateDto
    {
        public int Id { get; set; }       
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public int CountryId { get; set; }

    }
}