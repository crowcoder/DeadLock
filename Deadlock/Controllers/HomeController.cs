using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Deadlock.Controllers
{
    public class HomeController : ApiController
    {
        public string Get()
        {
            var stringTask = GetSomethingAsync();
            string stringResult = stringTask.Result.ToString();
            return stringResult;
        }

        public static async Task<string> GetSomethingAsync()
        {
            using (var client = new HttpClient())
            {
                var resultString = await client.GetStringAsync("http://www.google.com");
                return resultString;
            }
        }
    }
}
