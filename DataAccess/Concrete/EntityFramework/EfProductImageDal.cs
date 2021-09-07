using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductImageDal : EfEntityRepositoryBase<ProductImage, GameDbContext>, IProductImageDal
    {
            public bool IsExist(int id)
            {
                using (GameDbContext context = new GameDbContext())
                {
                    return context.ProductImages.Any(cI => cI.ProductImageId == id);
            }
            }
    }
}
