using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Hospital
        {
        [Key]
        public int HospitalID { get; set; }
        [StringLength(200)]
        public string HospitalName { get; set; }
        [StringLength(50)]
        public string HospitalCity { get; set; }
        [StringLength(50)]
        public string HospitalDistrict { get; set; }

        public List<Doctor> Doctors { get; set; }



    }
}
