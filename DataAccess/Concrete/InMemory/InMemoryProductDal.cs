using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal//sanki veritabanımız var ve onu yönetiyor gibi simule ediyoruz burada
    {
        List<Product> _products;//Uygulama newlendiği anda oluştulacak ürün listesi. Vveritabanından alıyormuş gibi

        public InMemoryProductDal()//Vveritabanından alıyormuş gibi ürün listesi oluşturuyoruz.
        {
            _products = new List<Product> {
                new Product{ProductID=1, CategoryID=1, ProductName="Bardak", UnitPrice=15, UnitsInStock=15},
                new Product{ProductID=2, CategoryID=1, ProductName="Kamera", UnitPrice=500, UnitsInStock=3},
                new Product{ProductID=3, CategoryID=2, ProductName="Telefon", UnitPrice=1500, UnitsInStock=2},
                new Product{ProductID=4, CategoryID=2, ProductName="Klavye", UnitPrice=150, UnitsInStock=65},
                new Product{ProductID=5, CategoryID=2, ProductName="Fare", UnitPrice=85, UnitsInStock=1},
            };
        }

        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            //foreach (var p in _products)//bu döngü sileceğimiz ürünü bulmak için silmek istediğimiz ID yi her bir ürünle karşılaştırıyor
            //{
            //    if (product.ProductID==p.ProductID)
            //    {
            //        productToDelete=p
            //    }
            //}

            //singleordefault kodu foreach mantığı ile çalışır herbirini p takma ismiyle dön şarta uyanı producttodelete e at.
            Product productToDelete = _products.SingleOrDefault(p=>p.ProductID==product.ProductID); //yukardaki foreach döngüsünün linq ile yazımı
            _products.Remove(productToDelete);
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()//bütün veritabanı ürünlerini istediği için
        {
            return _products;//bütün products ları dönderiyoruz.
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllByCategory(int CategoryID)
        {
            return _products.Where(p => p.CategoryID == CategoryID).ToList();//where koşulu belirtilen koşula uyan bütün elemanları yeni bir liste yaparak döndürür.
        }

        public void Update(Product product)
        {
            //gönderdiğim ürün id sine sahip olan  listedeki ürünü bul
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductID == product.ProductID);//güncellenecek referansı bulup producttoUpdate e atıyoruz.
            //ürünü bulup referansı producttoupdate e attıktan sonra gönderdiğimiz bilgileri aktarıyoruz.
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryID = product.CategoryID;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;

        }
    }
}
