using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using Contacts.Core.Entities;
using ContactsApi.Dal.Repositories.Interfaces;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ContactsApi.Dal.Repositories
{
    public class ContactsRepository : IContactsRepository
    {
        private readonly ContactsDbContext<Contact> _context;
        private readonly IMongoCollection<Contact> _collection;

        public ContactsRepository(IConfiguration configuration)
        {
            _context = new ContactsDbContext<Contact>(configuration);
            _collection = _context.GetCollection("Contacts");
        }

        public async Task CreateAsync(Contact contact)
        {
            await _collection.InsertOneAsync(contact);
        }

        public async Task DeleteAsync(ObjectId id)
        {
            await _collection.DeleteOneAsync(c => c.Id == id);
        }

        public async Task<List<Contact>> GetAllAsync()
        {
            return await _collection.Find(c => c.Id != null).ToListAsync();
        }

        public async Task<Contact> GetAsync(ObjectId id)
        {
            return await _collection.Find(c => c.Id == id).FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(Contact contact)
        {
            var filter = Builders<Contact>.Filter.Eq("_id", contact.Id);
            await _collection.ReplaceOneAsync(filter, contact);
        }
    }
}
