using Microsoft.EntityFrameworkCore;
using PhoneBook.DataTransferModel;
using PhoneBook.Interface.BusinessLogic;
using PhoneBook.Interface.Repository;
using PhoneBook.Shared.Extension;
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

        public async Task<IEnumerable<Model.AddressBook>> GetSearchAsync(string name, string phone)
        {
            var query = _addressBookRepository.Entity.AsQueryable();

            if (!name.IsNullOrWhiteSpace())
            {
                query = query.Where(w => EF.Functions.Like(w.Name, $"%{name.Trim()}%"));
            }

            if (!phone.IsNullOrWhiteSpace())
            {
                query = query.Where(w => w.PhoneNo == phone);
            }

            return await query.OrderBy(w => w.Name)
                .ToListAsync();
        }

        #endregion
    }
}
