using PhoneBook.DataTransferModel;
using PhoneBook.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhoneBook.Interface.BusinessLogic
{
    public interface IAddressBookBusinessLogic
    {
        Task<OperationResult<AddressBook>> AddAsync(AddressBook addressBook);
        Task<IEnumerable<AddressBook>> GetAllAsync();
        Task<IEnumerable<AddressBook>> GetSearchAsync(string name, string phone);
    }
}
