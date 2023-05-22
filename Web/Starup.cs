using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Web.Models;

namespace Web
{
    public class Starup
       
    {
        public Starup(IConfiguration configuration)
        {
            configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<BarSenttings>
                (Configuration.GetSection(nameof(BarSenttings)));


            services.AddSingleton<IBarSenttings>
                (d => d.GetRequiredService<IOptions<BarSenttings>>().Value);


            services.AddControllers();
            
        }

    
    }
}
