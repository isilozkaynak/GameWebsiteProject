using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IProductImageService
    {
        IResult Add(IFormFile file, ProductImage productImage);
        IResult Update(IFormFile file, ProductImage productImage);
        IResult Delete(ProductImage productImage);
        IDataResult<List<ProductImage>> GetAll();
        IDataResult<ProductImage> GetById(int productImageId);
        IDataResult<List<ProductImage>> GetImagesByProductId(int productId);
    }
}
