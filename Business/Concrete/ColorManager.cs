using Business.Abstract;
using Core.Utilities.Result.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        public IResult Add(Color color)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(Color color)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Color>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Color>> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IResult Update(Color color)
        {
            throw new NotImplementedException();
        }
    }
}
