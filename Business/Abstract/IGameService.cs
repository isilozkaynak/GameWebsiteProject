using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IGameService
    {
        IDataResult<List<Game>> GetAll();
        IDataResult<Game> GetById(int id);

        IResult Insert(Game game);
        IResult Update(Game game);
        IResult Delete(Game game);
    }
}
