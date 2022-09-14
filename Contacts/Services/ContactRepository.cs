using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contacts.Models;
using Contacts.Services.Intefaces;
using Microsoft.EntityFrameworkCore;

namespace Contacts.Services
{
    public class ContactRepository : IContactRepository
    {
        private readonly LiteContext _context;

        public ContactRepository(LiteContext context)
        {
            _context = context;
        }


        public async Task<Contact> GetAsync(Guid id)
        {
            return await _context.Contacts.FirstOrDefaultAsync(x=>x.Id == id);
        }

        public async Task<IEnumerable<Contact>> GetAllAsync()
        {
            return await _context.Contacts.ToListAsync();
        }

        public async Task CreateAsync(Contact entity)
        {
            await _context.Contacts.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Contact entity)
        {
            _context.Contacts.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Contact entity)
        {
            _context.Contacts.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
