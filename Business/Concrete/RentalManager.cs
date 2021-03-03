using Business.Abstract;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;
using System.Linq;

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
            foreach (var p in _rentalDal.GetAll(p => p.CarId == rental.CarId))
            {
                foreach (var a in _rentalDal.GetAll(a => a.ReturnDate==rental.ReturnDate))
                {
                    if (a.ReturnDate==null)
                    {                    
                        System.Console.WriteLine("Bu araç şuan da kiralık.");
                        //return new ErrorResult("Bu araç şuan da kiralık.");
                    }
                }
            }

            //if (rental.ReturnDate.Value==null)
            //{
            //    //System.Console.WriteLine("Bu araç şuan da kiralık.");
            //    return new ErrorResult("Bu araç şuan da kiralık.");
            //}
            //else
            //{
                _rentalDal.Add(rental);
            //}
            System.Console.WriteLine("Araç Kiralandı");
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

        //public IDataResult<List<Rental>> GetCarId(int Id)
        //{
        //   // var result = _rentalDal.g
        //}
    }
}
