using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FundooModel
{
    public class LoginModel //LoginModel class
    {
        //using get set property
        [Required]//indicate property must have value
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
