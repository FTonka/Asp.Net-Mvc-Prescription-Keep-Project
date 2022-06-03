using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfDoctorRepository : GenericRepository<Doctor>, IDoctorDal
    {
        public List<Doctor> GetHospitalInfo(int id)
        {
            Context c = new Context();
            return c.Set<Doctor>().Include(x => x.Hospital).Where(x => x.HosiptalID == id).ToList();
        }


    }
}
