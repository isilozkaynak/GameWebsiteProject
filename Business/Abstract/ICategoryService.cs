using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        IDataResult<List<Category>> GetAll();
        IDataResult<Category> GetByCategoryId(int categoryId);
        IDataResult<Category> GetByCategoryName(string categoryName);


        IResult Insert(Category category);
        IResult Delete(Category category);
        IResult Update(Category category);
    }
}
