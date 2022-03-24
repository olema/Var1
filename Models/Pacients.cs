using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Var1.Models
{
    public class Pacient
    {
        public int PacientID { get; set; }
        [Required]
        [StringLength(50, ErrorMessage ="Имя не должно быть больше 50 символов.")]
        [Display(Name = "Имя")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Фамилия")]
        public string LastName { get; set; }
        [Required]
        [StringLength(10, ErrorMessage = "Длина не больше 10")]
        [Display(Name = "Полис")]
        public string MedPol { get; set; }
        [Display(Name = "Полное имя")]
        public string FullName
        {
            get
            {
                return LastName + " " + FirstName;
            }
        }

        public ICollection<Emk> Emk { get; set; }
        //public ICollection<WUser> WUser { get; set; }

    }

}