using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Doctor
    {
        [Key]
        public int DoctorID { get; set; }
        [StringLength(100)]
        public string DoctorName{ get; set; }
        [StringLength(20)]
        public string DoctorBirthdate { get; set; }
        [StringLength(1)]
        public string DoctorGender { get; set; }
        [StringLength(200)]
        public string DoctorAddress { get; set; }
        [StringLength(50)]
        public string DoctorMail { get; set; }
        public List<Note> Notes { get; set; }

        public int HosiptalID { get; set; }
        public Hospital Hospital { get; set; }

        
    }
}
