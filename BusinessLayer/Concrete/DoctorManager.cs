using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class DoctorManager:IDoctorService
    {
        IDoctorDal _doctorDal;
        public DoctorManager(IDoctorDal doctorDal)
        {
            _doctorDal = doctorDal;
        }

        public List<Doctor> GetList()
        {
           return _doctorDal.GetListAll();
        }
        public List<Doctor> GetHInfo(int id)
        {
            return _doctorDal.GetHospitalInfo(id);
        }
    }
}
