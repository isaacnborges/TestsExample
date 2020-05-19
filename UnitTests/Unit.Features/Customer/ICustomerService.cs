using System;
using System.Collections.Generic;

namespace Features.Clientes
{
    public interface ICustomerService : IDisposable
    {
        IEnumerable<Customer> GetAllActive();
        void Add(Customer client);
        void Update(Customer client);
        void Delete(Customer client);
        void Inactivate(Customer client);
    }
}