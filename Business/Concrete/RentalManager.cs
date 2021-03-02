using Business.Abstract;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental rental)
        {
            if (rental.ReturnDate==null)
            {
                //System.Console.WriteLine("Bu araç şuan da kiralık.");
                return new ErrorResult("Bu araç şuan da kiralık.");
            }
            else
            {
                _rentalDal.Add(rental);                
            }

            return new SuccessResult();
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);

            return new SuccessResult();
        }

        public IDataResult<List<Rental>> GetAll()
        {
            var result = _rentalDal.GetAll();

            return new SuccessDataResult<List<Rental>>(result);
        }

        public IDataResult<List<Rental>> GetById(int Id)
        {
            var result = _rentalDal.GetById(Id);

            return new SuccessDataResult<List<Rental>>(result);
        }

        public IDataResult<List<Rental>> GetByReturnDate()
        {
            //var result = _rentalDal.Get().ReturnDate();

            return new SuccessDataResult<List<Rental>>();
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);

            return new SuccessResult();
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            var result = _rentalDal.GetRentalDetails();

            return new SuccessDataResult<List<RentalDetailDto>>(result);
        }
    }
}
