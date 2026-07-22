using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CleaningSite.Data;
using CleaningSite.Models;

namespace CleaningSite.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly AppDbContext _db;
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _config;



        public IndexModel(ILogger<IndexModel> logger, AppDbContext db, HttpClient httpClient, IConfiguration config)
        {
            _logger = logger;
            _db = db;
            _httpClient = httpClient;
            _config = config;
        }

        [BindProperty]
        public ContactRequest Input { get; set; } = new();

        private async Task SendTelegramNotificationAsync(ContactRequest request)
        {
            var botToken = _config["Telegram:BotToken"];
            var chatId = _config["Telegram:ChatId"];
            var text = $"Новая заявка!\nИмя: {request.Name}\nТелефон: {request.Phone}";
            var url = $"https://api.telegram.org/bot{botToken}/sendMessage?chat_id={chatId}&text={Uri.EscapeDataString(text)}";
            await _httpClient.GetAsync(url);
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _db.ContactRequests.Add(Input);
            _db.SaveChanges();

            await SendTelegramNotificationAsync(Input);

            TempData["Success"] = true;
            return RedirectToPage(null, null, "contact");
        }

        public async Task<IActionResult> OnPostAjax()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Проверьте правильность заполнения полей");
            }

            _db.ContactRequests.Add(Input);
            _db.SaveChanges();

            await SendTelegramNotificationAsync(Input);


            return new JsonResult(new { success = true });

        }
        
    }
}
