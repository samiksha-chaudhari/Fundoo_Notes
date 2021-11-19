using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FundooModel
{
    public class ResetModel //Reset model class
    {
        //using get set property
        [Required] //indicate property must have value
        public string Email { get; set; }

        [Required]
        public string NewPassword { get; set; }
        
        [Required]
        public string ConfirmPassword { get; set; }

    }
}
