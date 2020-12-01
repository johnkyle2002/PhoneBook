using Microsoft.EntityFrameworkCore;
using PhoneBook.Interface.Repository;
using PhoneBook.Model;

namespace PhoneBook.Repository
{
    public class AddressBookRepository
    {
        private readonly IUnitOfWorkModel<AddressBook> _unitOfWork;

        public AddressBookRepository(IUnitOfWorkModel<AddressBook> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public DbSet<AddressBook> Entity => _unitOfWork.Entity;

    }
}
