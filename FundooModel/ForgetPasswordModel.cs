using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FundooModel
{
    public class ForgetPasswordModel
    {
        //using get set property
        [Required] //indicate property must have value
        public string Email { get; set; }

    }
}
