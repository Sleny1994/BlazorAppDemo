using System.ComponentModel.DataAnnotations;

namespace BlazorAppDemo.Models
{
    public class UserInfo
    {
        [Key]
        [Display(Name = "用户名")]
        [StringLength(30,MinimumLength = 3)] 
        public string UserName { get; set; }

        [Display(Name = "密码")]
        [Required]
        [DataType(DataType.Password)]
        [StringLength (30,MinimumLength = 4)]
        public string Password { get; set; }

        public DateTime LastLoginTime { get; set; }
        public DateTime ChangedPasswordTime { get; set; }
    }
}
