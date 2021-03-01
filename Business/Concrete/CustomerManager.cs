using Business.Abstract;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public IResult Add(Customer customer)
        {
            _customerDal.Add(customer);

            return new SuccessResult();
        }

        public IResult Delete(Customer customer)
        {
            _customerDal.Delete(customer);

            return new SuccessResult();
        }

        public IDataResult<List<Customer>> GetAll()
        {
           var result = _customerDal.GetAll();

            return new SuccessDataResult<List<Customer>>(result);
        }

        public IDataResult<List<Customer>> GetById(int Id)
        {
            var result = _customerDal.GetById(Id);

            return new SuccessDataResult<List<Customer>>(result);
        }

        public IResult Update(Customer customer)
        {
            _customerDal.Update(customer);

            return new SuccessResult();
        }
    }
}


//foreach (var item in _customerDal.GetAll())
//{
//    if (item.Id == customer.Id)
//    {
//        item.CompanyName = customer.CompanyName;

//        _customerDal.Update(customer);
//    }
//}


//foreach (var item in _customerDal.GetAll())
//{
//    if (item.Id == customer.Id)
//    {
//        _customerDal.Delete(customer);
//    }
//}