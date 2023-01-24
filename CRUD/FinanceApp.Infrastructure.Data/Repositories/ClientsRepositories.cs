using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FinanceApp.Controller;
using FinanceApp.Controller.Interfaces.Repositories;
using FinanceApp.Infrastructure.Data.Context;


namespace FinanceApp.Infrastructure.Data.Repositories
{
    public class ClientsRepositories : IBaseRepository<Clients, Guid>
    {
        private ClientContext db;

        private void DateVerifier(DateTime birthday)
        {
            

            int now = int.Parse(DateTime.Now.ToString("yyyyMMdd"));
            int dob = int.Parse(birthday.ToString("yyyyMMdd"));

            int age = (now - dob) / 10000;
            if (age < 18)
            {
                throw new Exception("You can't edit the birthdate to be below the legal age");
            };
            
        }


        public ClientsRepositories(ClientContext _db)
        {
            db = _db;
        }
        public Clients Add(Clients entity)
        {
            DateVerifier(entity.BirthDate);            
            entity.CliId = Guid.NewGuid();
            entity.CreationDate = DateTime.Now;
            entity.ModificationDate = DateTime.Now;

            db.Clients.Add(entity);
            return entity;
        }

        public void Delete(Guid entityId)
        {
            var selectedClient = db.Clients.Where(c => c.CliId == entityId).FirstOrDefault();
            if (selectedClient != null)
            {
                if (selectedClient.Accounts.Any(x => (bool)(x.AccountCancelled = false)))
                    throw new InvalidDataException("You can't delete a client with products associated");

                db.Clients.Remove(selectedClient);
            }
        }

        public void Edit(Clients entity)
        {
            var selectedClient = db.Clients.Where(c => c.CliId == entity.CliId).FirstOrDefault();
            if (selectedClient != null)
            {
                DateVerifier(entity.BirthDate);
                selectedClient.NumberId = entity.NumberId;
                selectedClient.IdType = entity.IdType;
                selectedClient.NameClient = entity.NameClient;
                selectedClient.SurnameClient = entity.SurnameClient;
                selectedClient.ClientEmail = entity.ClientEmail;
                selectedClient.BirthDate = entity.BirthDate;
                selectedClient.ModificationDate = DateTime.Now;
                
                db.Entry(selectedClient).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
        }

        public List<Clients> GetAll()
        {
            return db.Clients.ToList();
        }

        public Clients GetById(Guid entityId)
        {
            var selectedClient = db.Clients.Where(c => c.CliId == entityId).FirstOrDefault();
            return selectedClient;
        }

        public void SaveChanges()
        {
            db.SaveChanges();
        }
    }
}
