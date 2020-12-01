using Microsoft.AspNetCore.Components;
using PhoneBook.Interface.BusinessLogic;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhoneBook.Blazor.Pages
{
    public partial class AddressList
    {
        protected IEnumerable<Model.AddressBook> AddressBooks { get; set; }

        [Inject] IAddressBookBusinessLogic _addressBookBusinessLogic { get; set; }

        protected override async Task OnInitializedAsync()
        {
            AddressBooks = await _addressBookBusinessLogic.GetAllAsync();
        }
    }
}
