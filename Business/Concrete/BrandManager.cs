using Business.Abstract;
using Core.Utilities.Result.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Core.Utilities.Result.Concrete;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public IResult Add(Brand brand)
        {
            _brandDal.Add(brand);

            return new Succe
        }

        public IResult Delete(Brand brand)
        {
            var result =_brandDal.Delete(brand);

            return new Result(result);
        }

        public IDataResult<List<Brand>> GetAll()
        {
            var result= _brandDal.GetAll();

            return new SuccessDataResult<List<Brand>>(result); 
        }

        public IDataResult<Brand> GetById(int brandId)
        {
            var result = _brandDal.Get(p=> p.BrandId == brandId);
            return new SuccessDataResult<Brand>(result);
        }

        public IResult Update(Brand brand)
        {
            _brandDal.Update(brand);
        }
    }
}
