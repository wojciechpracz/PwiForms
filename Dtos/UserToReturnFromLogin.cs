using pwiforms2.Models;

namespace pwiforms2.Dtos
{
    public class UserToReturnFromLogin
    {
        public UserToReturnWithDetails UserDetails { get; set; }
        public string Token { get; set; }
    }
}