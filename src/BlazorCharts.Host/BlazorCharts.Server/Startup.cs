using BlazorCharts.Docs.Pages;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCharts.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddAntDesign();

#if DEBUG
            //README.md文件中增加更新日志
            var readmeFile = System.IO.Path.Combine(System.IO.Path.GetFullPath("..\\..\\..\\"), "README.md");
            var readme = System.IO.File.ReadAllText(readmeFile);
            readme = readme.Substring(0, readme.IndexOf("### 更新日志") + "### 更新日志".Length);

            StringBuilder logStr = new StringBuilder();
            foreach (var item in Log.logs.Take(5))
            {
                logStr.AppendLine($"**{item.Key}**");
                item.Value.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => $"- {x.Trim().Substring(1)}")
                    .ToList().ForEach(x => logStr.AppendLine(x));
                logStr.AppendLine();
            }
            readme += "\r\n\r\n";
            readme += logStr.ToString();
            System.IO.File.WriteAllText(readmeFile,readme);
#endif
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
