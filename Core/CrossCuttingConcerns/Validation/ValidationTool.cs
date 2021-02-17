using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Validation
{
    public static class ValidationTool //heryerde kullanabileceğimiz bir doğrulama kodu ekliyoruz.
    {
        public static  void Validate(IValidator validator, object entity)
        {
            var context = new ValidationContext<object>(entity);//product için doğrulama yapıyoruz.
            var result = validator.Validate(context);//context içerisini validate edip sonucu result a aktarıyoruz.
            if (!result.IsValid)//eğer sonuç geçerli değilse
            {
                throw new ValidationException(result.Errors);//hata fırlatıyoruz
            }
        }
    }
}
