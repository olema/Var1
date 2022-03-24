using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Var1.Models
{
    public class Emk
    {
        public int EmkID { get; set; }
        [DataType(DataType.DateTime)]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Дата-время")]
        public DateTime InputDate { get; set; }
        [Display(Name = "ID пациента")]
        public int PacientID { get; set; }
        [Display(Name = "ID врача")]
        public int WUserID { get; set; }
        public Pacient Pacient { get; set; }
        public int OperID { get; set; }
        public Oper Oper { get; set; }
        public WUser WUser { get; set; }
       
    }
}