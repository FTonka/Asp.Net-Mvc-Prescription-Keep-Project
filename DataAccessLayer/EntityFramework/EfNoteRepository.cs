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
    public class EfNoteRepository : GenericRepository<Note>, INoteDal
    {

        public List<Note> GetNotesByEmployeeId(int id)
        {
            Context c = new Context();
            return c.Set<Note>().Include(x => x.Doctor).Where(x => x.EmployeeID == id).ToList();
        }

        public List<Note> GetNotesWithDoctor()
        {
            Context c=new Context();
            return c.Set<Note>().Include(x => x.Doctor).ToList();
        }

        public List<Note> GetNoteDetailsWithNoteId(int id)
        {
            Context c = new Context();
            return c.Set<Note>().Include(x => x.Employee).Where(x => x.NoteID == id).ToList();
        }
     

    }
}
