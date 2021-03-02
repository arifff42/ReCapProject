
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RentCarContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (RentCarContext context = new RentCarContext())
            {
                var result = from ren in context.Rentals 
                             join car in context.Cars on ren.CarId equals car.CarId
                             join bra in context.Brands on car.BrandId equals bra.BrandId
                             join col in context.Colors on car.ColorId equals col.ColorId
                             join cus in context.Customers on ren.CustomerId equals cus.Id
                             join us in context.Users on cus.UserId  equals us.Id

                             select new RentalDetailDto
                             {
                                 Id = ren.Id,
                                 FirstName = us.FirstName,
                                 LastName = us.LastName,
                                 RentDate = ren.RentDate,
                                 ReturnDate = ren.ReturnDate.Value, // ReturnDate,                                    
                                 ColorName = col.ColorName,
                                 DailyPrice = car.DailyPrice,
                                 ModelYear = car.ModelYear,
                                 Description = car.Description                                 
                             };

                //var result1 = string.IsDBNull(result);

                return result.ToList();
            }
        }
    }
}
