using AkademiQMongoDb.Services.ContactServices;
using Microsoft.AspNetCore.Mvc;

namespace AkademiQMongoDb.ViewComponents._UILayoutComponents
{
    public class _FooterContactPartial : ViewComponent
    {
        private readonly IContactService _contactService;

        public _FooterContactPartial(IContactService contactService)
        {
            _contactService = contactService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _contactService.GetAllAsync();

            var singleContact = values.FirstOrDefault();

            return View(singleContact);
        }
    }
}
