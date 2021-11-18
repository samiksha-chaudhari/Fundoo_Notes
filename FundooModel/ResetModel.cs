using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FundooModel
{
    public class ResetModel
    {
        [Required]
        public string Email { get; set; }
    }
}
