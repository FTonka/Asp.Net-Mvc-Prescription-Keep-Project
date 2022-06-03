using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }
        [StringLength(100)]
        public string EmployeeName { get; set; }
        [StringLength(100)]
        public string EmployeeSurname { get; set; }
        public string EmployeeBirthdate { get; set; }
        [StringLength(1)]
        public string EmployeeGender { get; set; }
        [StringLength(50)]
        public string EmployeeMail { get; set; }
        [StringLength(100)]
        public string EmployeePassword { get; set; }
        [StringLength(100)]
        public string EmployeeAddress { get; set; }
        [StringLength(100)]
        public string EmployeeImg { get; set; }

        [StringLength(20)]
        public string EmployeeTelNumber { get; set; }
        
        public string CreateDate { get; set; }
        [StringLength(100)]
        public string EmployeesCompany { get; set; }
        [StringLength(100)]
        public string EmployeesDepartment { get; set; }


        public List<Note> Notes { get; set; }



    }
}
