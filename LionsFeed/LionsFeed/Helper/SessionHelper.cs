using LionsFeed.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace LionsFeed.Helper
{
    public static class SessionHelper
    {

        public static void SetSession(this ISession session, string key, object o)
        {
            var str = JsonConvert.SerializeObject(o);
            session.SetString(key, str);
        }

        public static T GetSession<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            if (value != null)
            {
                return JsonConvert.DeserializeObject<T>(value);
            }
            return default(T);
        }

        public static ApplicationUser GetLoggedInUser(this ISession session)
        {
            return session.GetSession<ApplicationUser>("LoggedInUser");
        }

        public static void SetLoggedInUser(this ISession session, ApplicationUser user)
        {
            session.SetSession("LoggedInUser", user);
        }
    }
}
