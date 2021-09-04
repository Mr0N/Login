using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Login.Models
{
    public class MessageFormModel
    {
        public int Id { set; get; }
        [RegularExpression(@".{5,}",ErrorMessage = "Мінімум 5 символів")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Поле не повино бути пустим")]
        public string Message { set; get; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Поле не повино бути пустим")]
        
        public string Username { set; get; }
    }
}
