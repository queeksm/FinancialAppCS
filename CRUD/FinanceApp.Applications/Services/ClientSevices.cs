using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FinanceApp.Controller;
using FinanceApp.Controller.Interfaces.Repositories;
using FinanceApp.Applications.Interfaces;

namespace FinanceApp.Applications.Services
{
    public class ClientSevices : IBaseService<Clients, Guid>
    {
        private readonly IBaseRepository<Clients, Guid> clientRepo;
        
        public ClientSevices(IBaseRepository<Clients,Guid> _clientRepo) { clientRepo = _clientRepo; }
        public Clients Add(Clients entity)
        {
            if (entity == null)
                throw new ArgumentNullException("'Client' Required");

            var resulClient = clientRepo.Add(entity);
            clientRepo.SaveChanges();
            return resulClient;
        }

        public void Delete(Guid entityId)
        {
            clientRepo.Delete(entityId);
            clientRepo.SaveChanges();
        }

        public void Edit(Clients entity)
        {
            if (entity == null)
                throw new ArgumentNullException("'Client' is required for editing");
            clientRepo.Edit(entity);
            clientRepo.SaveChanges();

        }

        public List<Clients> GetAll()
        {
            return clientRepo.GetAll();
        }

        public Clients GetById(Guid entityId)
        {
            return clientRepo.GetById(entityId);  
        }
    }
}
