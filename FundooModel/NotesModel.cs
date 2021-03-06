using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FundooModel
{
    public class NotesModel
    {        
        [Key]
        public int NoteId { get; set; }
       
        public string Title { get; set; }
        public string Description { get; set; }
        public string Reminder { get; set; }
        
        public string Colour { get; set; }

        public string Image { get; set; }

        [DefaultValue(false)]
        public bool Pin { get; set; }

        [DefaultValue(false)]
        public bool Archive { get; set; }
               
        [DefaultValue(false)]
        public bool Trash { get; set; }

        [Required]
        [ForeignKey("RegisterModel")]
        public int ID { get; set; }
        public virtual RegisterModel RegisterModel { get; set; }


    }
}
