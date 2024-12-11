using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Backend.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Backend.Features.Clients
{
    public interface IClientService
    {
        IEnumerable<Client> GetAllClients();
        Client? GetClientById(int id);
        void AddClient(Client client);
        void UpdateClient(Client client);
        void DeleteClient(int id);
    }

    public class ClientService : IClientService
    {
        private readonly CargoHubDbContext _dbContext;

        public ClientService(CargoHubDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Client> GetAllClients()
        {
            if (_dbContext.Clients != null)
            {
                return _dbContext.Clients.ToList();
            }
            return new List<Client>();
        }

        public Client? GetClientById(int id)
        {
            return _dbContext.Clients?.Find(id);
        }

        public void AddClient(Client client)
        {
            _dbContext.Clients?.Add(client);
            _dbContext.SaveChanges();
        }

        public void UpdateClient(Client client)
        {
            _dbContext.Clients?.Update(client);
            _dbContext.SaveChanges();
        }

        public void DeleteClient(int id)
        {
            var client = _dbContext.Clients?.Find(id);
            if (client != null)
            {
                _dbContext.Clients?.Remove(client);
                _dbContext.SaveChanges();
            }

        }
    }
}
