using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Var1.Models
{
    public class WDoljn
    {
        public int WDoljnID { get; set; }
        [Display(Name = "Должность")]
        [StringLength(30, ErrorMessage = "Длина не больше 30.")]
        public string DoljnName { get; set; }
//        public int? WUserID { get; set; }
        [Display(Name = "Работник")]
        public WUser Wuser { get; set; }
    }
    
}