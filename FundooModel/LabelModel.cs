﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FundooModel
{
    public class LabelModel
    {
        [Key]
        public int LabelId { get; set; }

        public string Label { get; set; }

        [ForeignKey("NotesModel")]
        public int? NoteId { get; set; }        
        public virtual NotesModel NotesModel { get; set; }

        [ForeignKey("RegisterModel")]
        public int ID { get; set; }
        public virtual RegisterModel RegisterModel { get; set; }

        
    }
}
