using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ISaleService
    {
        IDataResult<List<Sale>> GetAll();
        IDataResult<Sale> GetById(int id);

        IResult Insert(Sale sale);
        IResult Update(Sale sale);
        IResult Delete(Sale sale);
    }
}
