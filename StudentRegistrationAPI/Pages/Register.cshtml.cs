using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentRegistration.Models;
using System.Net.Http.Json;

namespace StudentRegistration.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly IHttpClientFactory _clientFactory;

        public RegisterModel(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        [BindProperty]
        public Student Student { get; set; } = new Student();

        public string? Message { get; set; }

        public void OnGet()
        {
            // Nothing needed for GET
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            var client = _clientFactory.CreateClient();

            // Change URL if your API runs on a different port
            var response = await client.PostAsJsonAsync("https://localhost:5001/api/Students", Student);

            if (response.IsSuccessStatusCode)
            {
                Message = "Student registered successfully!";
                Student = new Student(); // Clear form
            }
            else
            {
                Message = "Error registering student.";
            }

            return Page();
        }
    }
}
