using Infrastructure.Databases.CustomerDatabase.Interfaces;
using Infrastructure.Databases.CustomerDatabase.Repositories;
using Infrastructure.Persistence;

namespace Infrastructure.Databases.CustomerDatabase
{
    public class CustomerUnitOfWork(CustomerDbContext context) : UnitOfWork(context)
    {
        private ICustomerRepository? _customerRepository;
        private IAddressRepository? _addressRepository;

        public ICustomerRepository CustomerRepository
        {
            get
            {
                _customerRepository ??= new CustomerRepository(context);
                return _customerRepository;
            }
        }

        public IAddressRepository AddressRepository
        {
            get
            {
                _addressRepository ??= new AddressRepository(context);
                return _addressRepository;
            }
        }
    }
}
