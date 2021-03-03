using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.CCS;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.Concrete.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        ICategoryService _categoryService;
        public ProductManager(IProductDal productDal, ICategoryService categoryService)
        {
            _productDal = productDal;
            _categoryService = categoryService;
        }

        [SecuredOperation("product.add,admin")]//product.add ve admin yetkisi olanlar Add işlemi yapabilecek
        [ValidationAspect(typeof(ProductValidator))]//Add methodunu ProductValidator daki kurallara göre doğrulama yapıyoruz.
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Add(Product product)
        {
            IResult result = BusinessRules.Run(CheckIfProductNameExists(product.ProductName),//iş kurallarını kontol edip sonucu result a atıyoruz.
                CheckIfProductCountOfCategoryCorrect(product.CategoryID), 
                CheckCategoryCount());

            if (result != null)
            {
                return result;
            }

            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);
        }


        [CacheAspect]//aşağıda çağrılacak kodlarda veri değişiklikleri yoksa ilk çalışmasını cache leyip daha sonra isteklere hep onu gönderir.
        public IDataResult<List<Product>> GetAll()
        {
            if (DateTime.Now.Hour == 01)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.ProductListed);
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryID == id));
        }


        [CacheAspect]//Manipülasyon yapan yani veri değişimleri, güncelleme gibi methodları cacheaspect ile yönetiyoruz
        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductID == productId));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            if (DateTime.Now.Hour == 23)
            {
                return new ErrorDataResult<List<ProductDetailDto>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
        }

        [ValidationAspect(typeof(ProductValidator))]
        [CacheRemoveAspect("IProductService.Get")]//IproductService de bütün getleri güncelleme success olduğu zaman cache den siler
        public IResult Update(Product product)
        {
            _productDal.Update(product);
            return new SuccessResult(Messages.ProductUpdated);
        }



        //İş Kuralları
        private IResult CheckIfProductCountOfCategoryCorrect(int categoryId)//İş kuralı ekliyoruz. Herbir kategori için ürün sayısı 10 geçemez.
        {
            var result = _productDal.GetAll(p => p.CategoryID == categoryId).Count;
            if (result >= 15)
            {
                return new ErrorResult(Messages.ProductCountOfCategoryError);
            }
            return new SuccessResult();
        }

        private IResult CheckIfProductNameExists(string productName)//İş kuralı ekliyoruz. Aynı ürün isminden tekrar eklenemez
        {
            var result = _productDal.GetAll(p => p.ProductName == productName).Any();//Any parantez içerisindeki şarta uyan data varmı yokmu true-false döndürür.
            if (result)
            {
                return new ErrorResult(Messages.ProductNameAlreadyExists);
            }
            return new SuccessResult();
        }

        private IResult CheckCategoryCount()//İş kuralı ekliyoruz. Kategori sayısı 25 geçtiğinde yeni ürün eklenemez
        {
            var result = _categoryService.GetAll();//Any parantez içerisindeki şarta uyan data varmı yokmu true-false döndürür.
            if (result.Data.Count>25)
            {
                return new ErrorResult(Messages.CategoryLimitExceded);
            }
            return new SuccessResult();
        }

        [TransactionScopeAspect]
        public IResult AddTransactionalTest(Product product)
        {
            throw new NotImplementedException();
        }
    }
}