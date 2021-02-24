using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Business
{
    public class BusinessRules
    {
        public static IResult Run(params IResult[] logics)//params yazdığımızda istediğimiz kadar IResult parametre olarak gönderebiliriz. Gönderilen bütün parametreleri IResult arrayine atıyor. Logic iş kuralları demek
        {
            foreach (var logic in logics)
            {
                if (!logic.Success)//gönderilen iş kurallarından Eğer başarısız olan varsa o logic i gönderiyoruz.! işareti tersine çeviriyor
                {
                    return logic;
                }
            }
            return null;
        }
    }
}
