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
    public class GameManager : IGameService
    {
        IGameDal _gameDal;
        public GameManager(IGameDal gameDal)
        {
            _gameDal = gameDal;
        }

        public IResult Delete(Game game)
        {
            _gameDal.Delete(game);
            return new SuccessResult(Messages.GameDeleted);
        }

        public IDataResult<List<Game>> GetAll()
        {
            return new SuccessDataResult<List<Game>>(_gameDal.GetAll(), Messages.GamesListed);
        }

        public IDataResult<Game> GetById(int id)
        {
            return new SuccessDataResult<Game>(_gameDal.Get(g => g.GameId == id));
        }

        public IResult Insert(Game game)
        {
            if (game.GameName.Length>=2)
            {
                _gameDal.Add(game);
                return new SuccessResult(Messages.GameAdded);
            }
            else
            {
                return new ErrorResult(Messages.GameNameInvalid);
            }

        }

        public IResult Update(Game game)
        {
            _gameDal.Update(game);
            return new SuccessResult(Messages.GameUpdated);
        }
    }
}
