using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public IDataResult<List<Category>> GetAll()
        {
            return new SuccessDataResult<List<Category>>(_categoryDal.GetAll(), Messages.CategoriesListed);
        }

        public IDataResult<Category> GetByCategoryId(int id)
        {
            return new SuccessDataResult<Category>(_categoryDal.Get(c => c.CategoryId == id));
        }

        public IDataResult<Category> GetByCategoryName(string name)
        {
             return new SuccessDataResult<Category>(_categoryDal.Get(c => c.CategoryName == name));
        }

        public IResult Insert(Category category)
        {
            if (category.CategoryName.Length >= 2)
            {
                _categoryDal.Add(category);
                return new SuccessResult(Messages.CategoryAdded);
            }
            else
            {
                return new ErrorResult(Messages.CategoryNameInvalid);
            }
        }

        public IResult Delete(Category category)
        {
            _categoryDal.Delete(category);
            return new SuccessResult(Messages.CategoryDeleted);

        }

        public IResult Update(Category category)
        {
            _categoryDal.Update(category);
            return new SuccessResult(Messages.CategoryUpdated);
        }
    }
}
