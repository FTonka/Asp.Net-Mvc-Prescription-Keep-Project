using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface INoteService
    {
        void AddNote(Note note);
        void DeleteNote(Note note);
        Note GetById(int id);
        void UpdateNote(Note note);
    }
}
