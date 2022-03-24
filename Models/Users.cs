using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Var1.Models
{
    public class WUser
    {
        public int WUserID { get; set; }
        [Display(Name = "Имя")]
        public string FirstName { get; set; }
        [Display(Name = "Фамилия")]
        public string LastName { get; set; }
        [Display(Name = "Должность")]
        public int DoljnForeignKey { get; set; }
        [Display(Name = "Пароль")]
        public string Passw { get; set; }
        public WDoljn WDoljn { get; set;}
        [Display(Name = "Полное имя")]
        public string FullName
        {
            get
            {
                return LastName + " " + FirstName;
            }
        }
    }

}