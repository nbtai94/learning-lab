using LearnDapperPostgres.Data;
using LearnDapperPostgres.Models;

namespace LearnDapperPostgres.Services
{
    public class CustomerService : Service<Customer>, ICustomerService
    {
        public CustomerService(IGenericRepository<Customer> repository) : base(repository)
        {
        }
    }
}
