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
    public class NoteManager : INoteService
    {
        INoteDal _noteDal;
        public NoteManager(INoteDal noteDal)
        {
            _noteDal = noteDal;
        }
        public void AddNote(Note note)
        {
            _noteDal.Insert(note);
        }
        public List<Note> GetNotesByEId(int id)
        {
            return _noteDal.GetNotesByEmployeeId(id);
        }
        public List<Note> GetDoctorInfo()
        {
            return _noteDal.GetNotesWithDoctor();   
        }


        public void DeleteNote(Note note)
        {
            _noteDal.Delete(note);
        }

        public Note GetById(int id)
        {
            return _noteDal.GetById(id);
        }

        public void UpdateNote(Note note)
        {
             _noteDal.Update(note);
        }
        public List<Note> GetNoteDetails(int id)
        {
            return _noteDal.GetNoteDetailsWithNoteId(id);
        }

    }
}
