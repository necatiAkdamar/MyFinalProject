using Core.DataAccess;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>//veritabanındaki user ı direk kullanmak için
    {
        List<OperationClaim> GetClaims(User user);
    }
}
