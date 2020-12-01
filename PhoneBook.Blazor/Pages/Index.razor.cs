using Microsoft.AspNetCore.Components;
using PhoneBook.Interface.BusinessLogic;
using System.Threading.Tasks;
using PhoneBook.Model;
namespace PhoneBook.Blazor.Pages
{
    public partial class Index
    {
        [Inject] IAddressBookBusinessLogic _addressBookBusinessLogic { get; set; }

        protected AddressBook AddressBook { get; set; }
        protected string Error;

        async Task ValidateAddressAsync()
        {
            var result = await _addressBookBusinessLogic.AddAsync(AddressBook);

            if (result.Succeeded)
                AddressBook = new AddressBook();
            else
            {
                Error = result.Message;
            }
        }

        protected override void OnInitialized()
        {
            AddressBook = new AddressBook();

            base.OnInitialized();
        }
    }
}
