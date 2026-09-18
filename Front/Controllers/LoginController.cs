using Microsoft.AspNetCore.Mvc;
using System.Web;

public class LoginController: Controller
{
    public ActionResult loginView()
    {
        return View();
    }
    public IActionResult cadastroView()
    {
        return View();
    }

    [HttpPost]
    public async Task Logar()
    {
        HttpContext.Session.SetString("logado", "true");
    }
}