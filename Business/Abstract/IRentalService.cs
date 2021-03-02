using Core.Utilities.Result.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IResult Add(Rental rental);
        IResult Delete(Rental rental);
        IResult Update(Rental rental);

        IDataResult<List<Rental>> GetAll();
        IDataResult<List<Rental>> GetById(int Id);
        IDataResult<List<Rental>> GetByReturnDate(/*DateTime dateTime*/);
        IDataResult<List<RentalDetailDto>> GetRentalDetails();
    }
}
