using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class ProductValidator:AbstractValidator<Product>//ürün doğrulama kurallarını oluşturuyoruz
    {
        public ProductValidator()//kurallar ctor constructor içerisine yazılır.
        {
            RuleFor(p => p.ProductName).NotEmpty();//productname boş geçilemez
            RuleFor(p => p.ProductName).MinimumLength(2);//productname in min uzunluğu 2 karakter olmalıdır.
            RuleFor(p => p.UnitPrice).NotEmpty();//unitprice boş geçilemez
            RuleFor(p => p.UnitPrice).GreaterThan(0);//unitprice 0 dan büyük olmalı
            RuleFor(p => p.UnitPrice).GreaterThanOrEqualTo(10).When(p => p.CategoryID == 1);//unitprice 10 dan büyük olmalı categoryıd 1 ise
            RuleFor(p => p.ProductName).Must(StartWithA).WithMessage("Ürünler A Harfi İle Başlamalı");//productname A ile başlamalı diye biz kural yazıyoruz.withmessage ile uyarı yazısı ekledik.

        }

        private bool StartWithA(string arg)//arg kuraldaki productname eşittir. True, false döner
        {
            return arg.StartsWith("A");
        }
    }
}
