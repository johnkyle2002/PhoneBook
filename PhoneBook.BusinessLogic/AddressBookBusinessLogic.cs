using Microsoft.EntityFrameworkCore;
using PhoneBook.DataTransferModel;
using PhoneBook.Interface.BusinessLogic;
using PhoneBook.Interface.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.BusinessLogic
{
    public class AddressBookBusinessLogic: IAddressBookBusinessLogic
    {
        #region Private Member

        private readonly IAddressBookRepository _addressBookRepository;

        #endregion

        #region Constructor

        public AddressBookBusinessLogic(IAddressBookRepository addressBookRepository)
        {
            _addressBookRepository = addressBookRepository;
        }

        #endregion

        #region Public Method

        public async Task<OperationResult<Model.AddressBook>> AddAsync(Model.AddressBook addressBook)
            => await _addressBookRepository.AddAsync(addressBook);

        public async Task<IEnumerable<Model.AddressBook>> GetAllAsync()
        {
            return await _addressBookRepository.Entity.OrderBy(o => o.Name).ToListAsync();
        }
         

        #endregion
    }
}
