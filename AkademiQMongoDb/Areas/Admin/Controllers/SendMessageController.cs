using AkademiQMongoDb.DTOs.SendMessageDtos;
using AkademiQMongoDb.Services.SendMessageServices;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace AkademiQMongoDb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SendMessageController : Controller
    {
        private readonly ISendMessageService _sendMessageService;

        public SendMessageController(ISendMessageService sendMessageService)
        {
            _sendMessageService = sendMessageService;
        }

        public async Task<IActionResult> Index()
        {
            var sendMessage = await _sendMessageService.GetAllAsync();
            return View(sendMessage);
        }

        public IActionResult CreateSendMessage()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateSendMessage(CreateSendMessageDto SendMessageDto)
        {
            await _sendMessageService.CreateAsync(SendMessageDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteSendMessage(string id)
        {
            await _sendMessageService.DeleteAsync(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> ToggleReadStatus(string id)
        {
            // 1. Önce ID'ye göre mesajı veritabanından getiriyoruz
            // (Servisinde GetByIdAsync metodunun olduğunu ve UpdateSendMessageDto döndüğünü varsayıyorum)
            var message = await _sendMessageService.GetByIdAsync(id);

            if (message != null)
            {
                // DÜZELTME: Result DTO'sunu Update DTO'suna çeviriyoruz
                var updateMessage = message.Adapt<UpdateSendMessageDto>();

                // Değeri tersine çeviriyoruz
                updateMessage.IsRead = !updateMessage.IsRead;

                // Artık doğru DTO tipini gönderdiğimiz için hata vermeyecek
                await _sendMessageService.UpdateAsync(updateMessage);
            }

            // İşlem bitince sayfayı yenile
            return RedirectToAction("Index");
        }
    }
}
