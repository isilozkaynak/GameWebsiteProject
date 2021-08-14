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
        IDataResult<Category> GetByCategoryId(int id);
        IDataResult<Category> GetByCategoryName(string name);


        IResult Insert(Category category);
        IResult Delete(Category category);
        IResult Update(Category category);
    }
}
