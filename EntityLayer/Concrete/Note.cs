using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Note
    {
        [Key]
        public int NoteID { get; set; }
        [StringLength(100)]
        public string NoteTitle { get; set; }

        [StringLength(5000)]
        public string NoteContent { get; set; }
        [StringLength(100)]
        public string NoteGeoLocation { get; set; }
        [StringLength(20)]
        public string NoteCreateDate { get; set; }
        public int EmployeeID { get; set; }
        public Employee Employee { get; set; }
        public int DoctorID { get; set; }
        public Doctor Doctor { get; set; }

    }
}
