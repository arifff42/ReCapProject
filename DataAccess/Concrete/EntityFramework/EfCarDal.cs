using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentCarContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (RentCarContext context = new RentCarContext())
            {
                var result = from ca in context.Cars
                             join b in context.Brands on ca.BrandId equals b.BrandId
                             join co in context.Colors on ca.ColorId equals co.ColorId


                             select new CarDetailDto
                             {   
                                 CarId = ca.CarId,
                                 BrandName = b.BrandName,
                                 ColorName = co.ColorName,
                                 DailyPrice = ca.DailyPrice,
                                 ModelYear = ca.ModelYear,
                                 Description = ca.Description                                 
                             };

                return result.ToList();
            }
        }
    }
}
