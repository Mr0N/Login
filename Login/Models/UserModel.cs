using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Login.Models
{
    public class UserModel
    {
        [Key]
        public int Id { set; get; }
        [Required(AllowEmptyStrings =false,ErrorMessage ="Поле не повино бути пустим")]
        public string UserName { set; get; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Поле не повино бути пустим")]
        public string Passwork { set; get; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Поле не повино бути пустим")]
        public string Email { set; get; }
        public UserType Role { set; get; } = UserType.User;
    }
}
