using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebKinoPoisk.DB;

namespace WebKinoPoisk.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntranceController : ControllerBase
    {
        public _1135KinopoiskContext db;
        public EntranceController(_1135KinopoiskContext db) 
        {
            this.db = db;
        }
        [HttpGet("Login")]
        public async Task<User> Login(string name, string password)
        {
            User user = db.Users.FirstOrDefault(s => s.Login == name && s.Password == password);
            return user;
        }
        [HttpGet("Registre")]
        public async Task Registre(string name, string password, bool sub)
        {
            db.Users.Add(new User() { Login = name, Password = password, HasSubscription = sub, IsAdmin = false });
        }
    }
}
