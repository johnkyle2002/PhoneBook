using Microsoft.EntityFrameworkCore;
using PhoneBook.Model;
using System;

namespace PhoneBook.Repository
{
    public class PhoneBookDBContext : DbContext
    {
        public PhoneBookDBContext(DbContextOptions<PhoneBookDBContext> options) : base(options)
        {
        }

        public DbSet<AddressBook> AddressBook { get; set; }
    }
}
