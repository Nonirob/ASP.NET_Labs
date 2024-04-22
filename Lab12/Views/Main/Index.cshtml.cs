using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


public class IndexModel : PageModel
{
    public List<User> Users { get; set; }
    public List<Company> Companies { get; set; }

    public void OnGet()
    {
    }
}