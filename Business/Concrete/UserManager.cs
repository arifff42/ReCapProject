using Business.Abstract;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }


        public IResult Add(User user)
        {
            _userDal.Add(user);

            return new SuccessResult();
        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);

            return new SuccessResult();
        }

        public IDataResult<List<User>> GetAll()
        {
            var result = _userDal.GetAll();

            return new SuccessDataResult<List<User>>(result);
        }

        public IDataResult<List<User>> GetById(int Id)
        {
            var result = _userDal.GetById(Id);

            return new SuccessDataResult<List<User>>(result);
        }

        public IResult Update(User user)
        {
            _userDal.Update(user);

            return new SuccessResult();
        }
    }
}
