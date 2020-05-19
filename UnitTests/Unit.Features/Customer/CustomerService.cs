using System.Collections.Generic;
using System.Linq;
using MediatR;

namespace Features.Clientes
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _clientRepository;
        private readonly IMediator _mediator;

        public CustomerService(ICustomerRepository clientRepository, IMediator mediator)
        {
            _clientRepository = clientRepository;
            _mediator = mediator;
        }

        public IEnumerable<Customer> GetAllActive()
        {
            return _clientRepository.GetAll().Where(c => c.Active);
        }

        public void Add(Customer client)
        {
            if (!client.IsValid())
                return;

            _clientRepository.Add(client);
            _mediator.Publish(new CustomerEmailNotification("admin@me.com", client.Email, "Olá", "Bem vindo!"));
        }

        public void Update(Customer client)
        {
            if (!client.IsValid())
                return;

            _clientRepository.Update(client);
            _mediator.Publish(new CustomerEmailNotification("admin@me.com", client.Email, "Mudanças", "Dê uma olhada!"));
        }

        public void Inactivate(Customer client)
        {
            if (!client.IsValid())
                return;

            client.Inactivate();
            _clientRepository.Update(client);
            _mediator.Publish(new CustomerEmailNotification("admin@me.com", client.Email, "Até breve", "Até mais tarde!"));
        }

        public void Delete(Customer client)
        {
            _clientRepository.Delete(client.Id);
            _mediator.Publish(new CustomerEmailNotification("admin@me.com", client.Email, "Adeus", "Tenha uma boa jornada!"));
        }

        public void Dispose()
        {
            _clientRepository.Dispose();
        }
    }
}