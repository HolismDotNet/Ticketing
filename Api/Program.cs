using Holism.Api;

namespace Holism.Ticketing.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Startup.AddControllerSearchAssembly(typeof(Controllers.PostController).Assembly);
            Holism.Api.Config.ConfigureEverything();
            Application.Run();
        }
    }
}
