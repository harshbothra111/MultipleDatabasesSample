using Infrastructure.Databases.CustomerDatabase.Repositories;
using Infrastructure.Persistence;

namespace Infrastructure.Databases.CustomerDatabase
{
    public class CustomerUnitOfWork(CustomerDbContext context) : UnitOfWork(context)
    {
        private CustomerRepository? _customerRepository;
        private AddressRepository? _addressRepository;

        public CustomerRepository CustomerRepository
        {
            get
            {
                _customerRepository ??= new CustomerRepository(context);
                return _customerRepository;
            }
        }

        public AddressRepository AddressRepository
        {
            get
            {
                _addressRepository ??= new AddressRepository(context);
                return _addressRepository;
            }
        }
    }
}
