using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Helper;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace Business.Concrete
{
    public class ProductImageManager : IProductImageService
    {
        IProductImageDal _productImageDal;

        public ProductImageManager(IProductImageDal productImageDal)
        {
            _productImageDal = productImageDal;
        }

        //[SecuredOperation("admin")]
        //[CacheRemoveAspect("IProductImageService.Get")]
        [ValidationAspect(typeof(ProductImageValidator))]
        public IResult Add(ProductImage productImage, IFormFile file)
        {
            IResult result = BusinessRules.Run(
                CheckIfImageLimitExpired(productImage.ProductId),
                CheckIfImageExtensionValid(file)
                );

            if (result != null)
            {
                return result;
            }

            productImage.ImagePath = FileHelper.Add(file);
            productImage.UploadDate = DateTime.Now;
            _productImageDal.Add(productImage);
            return new SuccessResult();
        }

        //[SecuredOperation("admin")]
        //[CacheRemoveAspect("IProductImageService.Get")]
        public IResult Delete(ProductImage productImage)
        {
            IResult result = BusinessRules.Run(
                CheckIfImageExists(productImage.ProductImageId)
                );
            if (result != null)
            {
                return result;
            }


            var image = _productImageDal.Get(p => p.ProductImageId == productImage.ProductImageId);
            if (image == null)
            {
                return new ErrorResult(Messages.ImageNotFound);
            }
            FileHelper.Delete(image.ImagePath);
            _productImageDal.Delete(productImage);
            return new SuccessResult(Messages.SuccessImageDeleted);
        }

        //[SecuredOperation("admin")]
        //[CacheRemoveAspect("IProductImageService.Get")]
        public IResult DeleteByProductId(int productId)
        {
            var result = _productImageDal.GetAll(p => p.ProductId == productId);
            if (result.Any())
            {
                foreach (var productImage in result)
                {
                    Delete(productImage);
                }
                return new SuccessResult(Messages.AllImagesDeleted);
            }
            return new ErrorResult(Messages.CarHaveNoImage);
        }

        //[CacheAspect]
        public IDataResult<List<ProductImage>> GetAll()
        {
            return new SuccessDataResult<List<ProductImage>>(_productImageDal.GetAll());
        }

        //[CacheAspect]
        public IDataResult<ProductImage> Get(int id)
        {
            return new SuccessDataResult<ProductImage>(_productImageDal.Get(p => p.ProductImageId == id));
        }
        //[CacheAspect]
        public IDataResult<List<ProductImage>> GetImagesById(int id)
        {
            return new SuccessDataResult<List<ProductImage>>(_productImageDal.GetAll(p => p.ProductId == id).ToList());
        }

        private IResult CheckIfImageLimitExpired(int productId)
        {
            int result = _productImageDal.GetAll(p => p.ProductId == productId).Count;
            if (result >= 4)
            {
                return new ErrorResult(Messages.OverLimit);
            }
            return new SuccessResult();
        }

        private IResult CheckIfImageExtensionValid(IFormFile file)
        {
            bool isValidFileExtension = Messages.ValidImageFileTypes.Any(t => t == Path.GetExtension(file.FileName).ToUpper());
            if (!isValidFileExtension)
            {
                return new ErrorResult(Messages.InvalidImageExtension);
            }

            return new SuccessResult();
        }

        private IResult CheckIfImageExists(int id)
        {
            if (!_productImageDal.IsExist(id))
            {
                return new SuccessResult();
            }

            return new ErrorResult(Messages.ProductImageMustBeExists);
        }
        /*
        IProductImageDal _productImageDal;

        public ProductImageManager(IProductImageDal productImageDal)
        {
            _productImageDal = productImageDal;
        }

        [ValidationAspect(typeof(ProductImageValidator))]
        public IResult Add(IFormFile file, ProductImage productImage)
        {
          
            IResult result = BusinessRules.Run(CheckImageLimitExceeded(productImage.ProductId));
            if (result != null)
            {
                return new ErrorResult(Messages.ImageLimitExceded);//return result;
            }

            productImage.ImagePath = FileHelper.Add(file);
            productImage.UploadDate = DateTime.Now;

            _productImageDal.Add(productImage);
            return new SuccessResult(Messages.ProductImageAdded);
        }


        public IResult Delete(ProductImage productImage)
        {
            var oldPath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\wwwroot")) + _productImageDal.Get(p => p.ProductImageId == productImage.ProductImageId).ImagePath;
            IResult result = BusinessRules.Run(FileHelper.Delete(oldPath));

            if (result != null)
            {
                return result;
            }

            _productImageDal.Delete(productImage);
            return new SuccessResult(Messages.ProductImageDeleted);
        }

        public IDataResult<List<ProductImage>> GetAll()
        {
            return new SuccessDataResult<List<ProductImage>>(_productImageDal.GetAll(), Messages.ProductImagesListed);
        }

        public IDataResult<ProductImage> GetById(int id)
        {
            IResult result = BusinessRules.Run(CheckIfProductImageNull(id));
            if (result != null)
            {
                return new ErrorDataResult<ProductImage>(result.Message);
            }
            return new SuccessDataResult<ProductImage>(_productImageDal.Get(p => p.ProductId == id));
        }

        public IResult Update(IFormFile file, ProductImage productImage)
        {
            IResult result = BusinessRules.Run(CheckImageLimitExceeded(productImage.ProductId));
            if (result != null)
            {
                return result;
            }

            var oldPath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\wwwroot")) + _productImageDal.Get(p => p.ProductImageId == productImage.ProductImageId).ImagePath;

            productImage.ImagePath = FileHelper.Update(oldPath, file);
            productImage.UploadDate = DateTime.Now;
            _productImageDal.Update(productImage);
            return new SuccessResult(Messages.ProductImageUpdated);
        }

        public IDataResult<List<ProductImage>> GetImagesByProductId(int productId)
        {
            IResult result = BusinessRules.Run(CheckIfProductImageNull(productId));
            if (result != null)
            {
                return new ErrorDataResult<List<ProductImage>>(result.Message);
            }
            return new SuccessDataResult<List<ProductImage>>(CheckIfProductImageNull(productId).Data);
        }


        //businessrule codes
        private IResult CheckImageLimitExceeded(int productId)
        {
            var productImageCount = _productImageDal.GetAll(p => p.ProductId == productId).Count;
            if (productImageCount >= 5)
            {
                return new ErrorResult(Messages.ProductImageLimitExceeded);
            }

            return new SuccessResult();
        }
        private IDataResult<List<ProductImage>> CheckIfProductImageNull(int id)
        {
            try
            {
                string path = @"\images\DefaultImage.jpg";
                var result = _productImageDal.GetAll(p => p.ProductId == id).Any();
                if (!result)
                {
                    List<ProductImage> productImage = new List<ProductImage>();
                    productImage.Add(new ProductImage { ProductId = id, ImagePath = path, UploadDate = DateTime.Now });
                    return new SuccessDataResult<List<ProductImage>>(productImage);
                }
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<List<ProductImage>>(exception.Message);
            }
            return new SuccessDataResult<List<ProductImage>>(_productImageDal.GetAll(p => p.ProductId == id));
        } */
    }
}
