using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WebApi
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            // ServiceLoader 中存入，方便后续获取服务
            TianCheng.Model.ServiceLoader.Services = services;
            TianCheng.Model.ServiceLoader.Configuration = Configuration;
            // 根据IServiceRegister 接口来注册能找到的所有服务
            services.AddBusinessServices();
            // 设置对象自动映射
            TianCheng.Model.AutoMapperExtension.InitializeMappers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            TianCheng.Model.ServiceLoader.Instance = app.ApplicationServices;
        }
    }
}
