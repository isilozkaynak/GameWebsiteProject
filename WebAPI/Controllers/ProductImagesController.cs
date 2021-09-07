using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImagesController : ControllerBase
    {
        IProductImageService _productImageService;

        public ProductImagesController(IProductImageService productImageService)
        {
            _productImageService = productImageService;
        }

        [HttpGet("getall")]

        public IActionResult GetAll()
        {
            var result = _productImageService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getimagesbyid")]

        public IActionResult GetImagesById(int id)
        {
            var result = _productImageService.GetImagesById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add([FromForm] ProductImage productImage, [FromForm] IFormFile file)
        {
            if (file == null)
            {
                return BadRequest("Boş resim gönderemezsin");
            }
            IResult result = _productImageService.Add(productImage, file);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete([FromForm(Name = ("ProductImageId"))] int productImageId)
        {

            var deleteProductImageByProductId = _productImageService.Get(productImageId).Data;
            var result = _productImageService.Delete(deleteProductImageByProductId);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("deletebyproductid")]
        public IActionResult DeleteByProductId([FromForm(Name = ("ProductId"))] int productId)
        {
            IResult result = _productImageService.DeleteByProductId(productId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
