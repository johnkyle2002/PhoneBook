using Microsoft.AspNetCore.Components;
using PhoneBook.Interface.BusinessLogic;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhoneBook.Blazor.Pages
{
    public partial class SearchAddress
    {
        protected string Phone { get; set; }

        protected string Name { get; set; }

        protected IEnumerable<Model.AddressBook> AddressBooks { get; set; }

        [Inject] IAddressBookBusinessLogic _addressBookBusinessLogic { get; set; }

        protected override async Task OnInitializedAsync()
        {

        }

        public async Task SearchAsync()
        {
            AddressBooks = await _addressBookBusinessLogic.GetSearchAsync(Name, Phone);
        }
    }
}
