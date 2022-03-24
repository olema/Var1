using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Var1.Models
{
    public class Oper
    {
        public int OperID { get; set; }
        [Display(Name = "Тип действия")]
        public string OperName { get; set; }
    }
}