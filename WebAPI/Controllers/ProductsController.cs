using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;


namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        IProductService _productService;//constructor oluşturunca new lemeden çalışması için startup.cs yi düzenledik 
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("GetAll")]//get yani veri isteme görme işlemi gerçekleştiğinde burası çalışacak. Takma isim verdik GetAll diye
        public IActionResult GetAll()
        {
            var result = _productService.GetAll();
            if (result.Success)
            {
                return Ok(result);//İşlem başarılı ise yani http request200 result yı dönder
            }
            return BadRequest(result);//http 400de result ı dönder
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id)//id ye göre veri istiyoruz.//Takma isim verdikten sonra GetById diye kullanabiliyoruz.
        {
            var result = _productService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        //güncelleme ve silme işlemleri içinde httppost u kullanırız. Ama güncellemeler için httpput silme için httpdelete de kullanılabilir.

        [HttpPost("Add")] //post yani gönderme kaydetme işlemi gerçekleştiğinde, çalıştığında burası çalışacak
        public IActionResult Add(Product product)
        {
            var result = _productService.Add(product);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GetByCategoryId")]
        public IActionResult GetByCategoryId(int id)//id ye göre veri istiyoruz.//Takma isim verdikten sonra GetById diye kullanabiliyoruz.
        {
            var result = _productService.GetAllByCategoryId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
