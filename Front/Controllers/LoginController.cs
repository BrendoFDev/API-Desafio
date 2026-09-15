using Microsoft.AspNetCore.Mvc;
using System.Web;

public class LoginController: Controller
{
    public ActionResult loginView()
    {
        return View();
    }
}