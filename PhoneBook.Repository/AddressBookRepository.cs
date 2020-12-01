using Microsoft.EntityFrameworkCore;
using PhoneBook.DataTransferModel;
using PhoneBook.Interface.Repository;
using PhoneBook.Model;
using System.Threading.Tasks;

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

        public async Task<OperationResult<AddressBook>> AddAsync(AddressBook addressBook)
        {
            if (await _unitOfWork.AddAsync(addressBook))
            {
                return new OperationResult<AddressBook>
                {
                    Model = addressBook,
                    Succeeded = true
                };
            }
            else
            {
                return new OperationResult<AddressBook>
                {
                    Message = "Unable to add record, please contact Application SUpport. Thank you.",
                };
            }
        }
    }
}
