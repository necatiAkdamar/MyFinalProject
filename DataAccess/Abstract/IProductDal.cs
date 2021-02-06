using Core.DataAccess;
using Entities.Concrete;
using Entities.Concrete.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IProductDal:IEntityRepository<Product>//Data erişimi ve kullanımı için gerçekleştirilen operasyonlar tanımlanıyor
    {
        List<ProductDetailDto> GetProductDetails();
    }
}
