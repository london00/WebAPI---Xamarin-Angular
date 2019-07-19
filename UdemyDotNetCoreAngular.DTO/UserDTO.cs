using System.ComponentModel.DataAnnotations;

namespace UdemyDotNetCoreAngular.DTO
{
    public class UserDTO
    {
        [StringLength(512)]
        public string UserName { get; set; }
        [StringLength(512)]
        public string Email { get; set; }
        [StringLength(512)]
        public string Password { get; set; }
    }
}
