using Business.Abstract;
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

        public List<Category> GetAll()
        {
            return _categoryDal.GetAll();
        }

        public Category GetByCategoryId(int id)
        {
            return _categoryDal.Get(c => c.CategoryId == id);
        }

        public Category GetByCategoryName(string name)
        {
            return _categoryDal.Get(c => c.CategoryName == name);
        }

        public void Insert(Category category)
        {
            if (category.CategoryName.Length >= 2)
            {
                _categoryDal.Add(category);
            }
            else
            {
                throw new Exception("Not a valid format!!!");
            }
        }

        public void Delete(Category category)
        {
            _categoryDal.Delete(category);
        }

        public void Update(Category category)
        {
            _categoryDal.Update(category);
        }
    }
}
