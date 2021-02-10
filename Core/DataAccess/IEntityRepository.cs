using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
//core katmanları hiçbir katmanı referans almaz
namespace Core.DataAccess
{
    //generic constraint-generic kısıtlama demek
    //class : referans tip olabilir demektir.
    //IEntity : IEntity olabilir veya IEntity implement eden bir nesne gelebilir temektir.
    //new(): newlenemez demek
    public interface IEntityRepository<T>
        where T:class,IEntity,new()//T parametresi bir class ve sadece IEntity de tanımlı olanlardan gelsin
    {
        List<T> GetAll(Expression<Func<T,bool>> filter=null);//kategoriye göre listele, kriterlere göre getir demek için Expression ekledik.
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        
    }
}
