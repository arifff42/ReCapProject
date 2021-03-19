using Business.Abstract;
using Business.BusinessAspect.Autofac;
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

        [SecuredOperation("rental.add,admin")]
        public IResult Add(Rental rental)
        {
            foreach (var p in _rentalDal.GetAll(p => p.CarId == rental.CarId).Where(p => p.ReturnDate == null)) 
            {
                if (p.ReturnDate.Value <= p.RentDate)
                {
                    System.Console.WriteLine("Teslim Tarihi, Kiralama Tarihinden Önce Olamaz.");
                    return new ErrorResult("Teslim Tarihi, Kiralama Tarihinden Önce Olamaz.");
                }
                else
                {
                    System.Console.WriteLine("Bu araç şuan da kiralık.");
                    return new ErrorResult("Bu araç şuan da kiralık.");
                }
            }

            _rentalDal.Add(rental);
            System.Console.WriteLine("Araç Kiralandı");
            return new SuccessResult();
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            System.Console.WriteLine("Silindi");
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
            if (rental.ReturnDate <= rental.RentDate)
            {
                System.Console.WriteLine("Teslim Tarihi, Kiralama Tarihinden Önce Olamaz.");
                return new ErrorResult("Teslim Tarihi, Kiralama Tarihinden Önce Olamaz.");
            }
            else
            {
                _rentalDal.Update(rental);
                System.Console.WriteLine("Güncellendi");
                return new SuccessResult();
            }
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
