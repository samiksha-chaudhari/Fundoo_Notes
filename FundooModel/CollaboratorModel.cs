using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FundooModel
{
    public class CollaboratorModel
    {
        [Key]
        public int CollaboratorId { get; set; }
        public string CollaboratorEmail { get; set; }
                
        [ForeignKey("NotesModel")]
        public int NoteId { get; set; }         
        public virtual NotesModel NotesModel { get; set; }

    }
}
