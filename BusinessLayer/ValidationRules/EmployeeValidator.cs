using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class EmployeeValidator:AbstractValidator<Employee>
    {
        public EmployeeValidator()
        {
            RuleFor(x => x.EmployeeName).NotEmpty().WithMessage("İsim Alanı Boş Bırakılamaz");
            RuleFor(x => x.EmployeeName).MaximumLength(50).WithMessage("İsim Uzunluğu En Fazla 50 Olmalıdır");
            RuleFor(x => x.EmployeeName).MinimumLength(2).WithMessage("İsim Uzunuğu En Kısa 2 Olmalıdır");
            RuleFor(x => x.EmployeeSurname).NotEmpty().WithMessage("Soyisim Alanı Boş Bırakılamaz");
            RuleFor(x => x.EmployeeSurname).MaximumLength(50).WithMessage("Soyisim Uzunluğu En Fazla 50 Olmalıdır");
            RuleFor(x => x.EmployeeSurname).MinimumLength(2).WithMessage("Soyisim Uzunuğu En Kısa 2 Olmalıdır");
            RuleFor(x => x.EmployeeMail).NotEmpty().WithMessage("Mail Alanı Boş Bırakılamaz");
            RuleFor(x => x.EmployeePassword).NotEmpty().WithMessage("Şifre Alanı Boş Bırakılamaz");
            RuleFor(x => x.EmployeePassword).MinimumLength(5).WithMessage("Şifre Alanı En Az 6 Karakterden Oluşmalıdır");

        }
    }
}
