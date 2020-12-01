using Microsoft.EntityFrameworkCore;
using PhoneBook.Model;
using System.Threading.Tasks;

namespace PhoneBook.Interface.Repository
{
    public interface IAddressBookRepository
    {
        DbSet<AddressBook> Entity { get; }

        Task<DataTransferModel.OperationResult<AddressBook>> AddAsync(AddressBook addressBook);
    }
}
