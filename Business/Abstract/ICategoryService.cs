using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        List<Category> GetAll();
        Category GetByCategoryId(int id);
        Category GetByCategoryName(string name);


        void Insert(Category category);
        void Delete(Category category);
        void Update(Category category);
    }
}
