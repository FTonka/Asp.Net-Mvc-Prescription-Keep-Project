using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class NoteValidator:AbstractValidator<Note>
    {
        public NoteValidator()
        {
            RuleFor(x => x.NoteTitle).NotEmpty().WithMessage("*Not başlığı boş geçilemez");
            RuleFor(x => x.NoteTitle).MaximumLength(35).WithMessage("*35 Kelimeden Fazla Karakter Girişi Yapamazsınız");
            RuleFor(x => x.NoteContent).NotEmpty().WithMessage("*Madem Yazacak bişeyin yok ne diye başlık açıyorsun");
           // RuleFor(x => x.NoteCreateDate).NotEmpty().WithMessage("*İnsanlıktan öncemi gittin muayeneye niye tarih girmiyorsun");
            
        }
    }
}
