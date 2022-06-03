using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public  class Company
    {
        [Key]
        public int CompanyID { get; set; }
        [StringLength(200)]
        public string CompanyName { get; set; }
        [StringLength(50)]
        public string CompanyCity { get; set; }
        [StringLength(50)]
        public string CompanyDistrict { get; set; }
        [StringLength(10)]
        public string CompanyFoundationYear { get; set; }



    }
}
