using LionsFeed.Helper;
using LionsFeed.Models;
using Microsoft.AspNetCore.Mvc;

namespace LionsFeed.Controllers
{
    public class BaseController : Controller
    {
        public BaseController()
        {

        }

        public ApplicationUser GetLoggedInUser()
        {
            return HttpContext.Session.GetLoggedInUser();
        }

        public void SetLoggedInUser(ApplicationUser user)
        {
            SetSession("LoggedInUser", user);
        }

        public void SetSession(string key, object o)
        {
            HttpContext.Session.SetSession(key, o);
        }

        public T GetSession<T>(string key)
        {
            return HttpContext.Session.GetSession<T>(key);
        }
    }
}