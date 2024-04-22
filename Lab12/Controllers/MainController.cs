using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab12.Controllers;

public class MainController : Controller
{
    Context db_con;

    public MainController(Context context)
    {
        db_con = context;
    }

    public async Task<IActionResult> Index()
    {
        if (db_con.Users.ToList().Count == 0)
        {
            db_con.Users.Add(new User
            {
                Username = "Іван",
                Surname = "Рибаков",
                Age = 23
            });
            db_con.Users.Add(new User
            {
                Username = "Джон",
                Surname = "Сміт",
                Age = 45
            });
            db_con.Users.Add(new User
            {
                Username = "Джон",
                Surname = "Снов",
                Age = 30
            });
            db_con.Users.Add(new User
            {
                Username = "Санса",
                Surname = "Старк",
                Age = 24
            });
        }

        if (db_con.Companies.ToList().Count == 0)
        {
            db_con.Companies.Add(new Company
            {
                Name = "GlobalLogic"
            });
            db_con.Companies.Add(new Company
            {
                Name = "Epam"
            });
            db_con.Companies.Add(new Company
            {
                Name = "Genesis"
            });
            db_con.Companies.Add(new Company
            {
                Name = "Skyler"
            });
            db_con.Companies.Add(new Company
            {
                Name = "Zone3000"
            });
        }

        await db_con.SaveChangesAsync();
        return View(new IndexModel
        {
            Users = await db_con.Users.ToListAsync(),
            Companies = await db_con.Companies.ToListAsync()
        });
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(User user)
    {
        Console.WriteLine(user.Username + " " + user.Username + " " + user.Age);
        db_con.Users.Add(user);
        await db_con.SaveChangesAsync();
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id != null)
        {
            User? user = await db_con.Users.FirstOrDefaultAsync(p => p.Id == id);
            if (user != null) return View(user);
        }

        return NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> Edit(User user)
    {
        if (!ModelState.IsValid)
        {
            return View(user);
        }
        db_con.Entry(user).State = EntityState.Modified;
        try
        {
            await db_con.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            throw;
        }

        return RedirectToAction("Index");
    }
    [HttpPost]
    public async Task<IActionResult> Delete(int? id)
    {
        if (id != null)
        {
            User? user = await db_con.Users.FirstOrDefaultAsync(p => p.Id == id);
            if (user != null)
            {
                db_con.Users.Remove(user);
                await db_con.SaveChangesAsync();
                return RedirectToAction("Index");
            }
        }

        return NotFound();
    }
}