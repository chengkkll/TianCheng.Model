# TianCheng.Model

目标架构为：.NET Standard 2.0

实体对象基类，及其常用操作。

## 基类介绍

基类主要为ID类型的基类，包括Guid类型的ID基类、Int类型的基类、ObjectId类型的基类（MongoDB的ID）

并根据这三种基类分别做了常用的业务对象基类。业务对象基类包括：创建人ID、创建人名称、创建时间、更新人ID、更新人名称、更新时间、状态、发布时间、是否逻辑删除这些属性。业务对象可以直接继承，专注具体业务的属性信息。

另外还增加了数据查询方面的对象，包括查询条件（分页、排序）、查询结果（分页信息及数据）

## 常用操作说明

常用操作包括：对象转换、序列化、日志、常用异常处理、依赖注入。

### 对象转换

使用了[AutoMapper](http://automapper.org/)作为对象转换的操作。这里为了使用方便。对其做了一些封装。

对于对象间转换的设置，可以通过继承`IAutoProfile`接口，并在派生类的构造方法中调用接口的`Register`方法。当然`Register`方法内需要写你要转换的对象。

例如：

```csharp
using AutoMapper;
using System;

namespace TianCheng.Model
{
    /// <summary>
    /// 基础信息的AutoMapper转换
    /// </summary>
    public class ModelProfile : Profile, IAutoProfile
    {
        /// <summary>
        /// 构造方法
        /// </summary>
        public ModelProfile()
        {
            Register();
        }
        /// <summary>
        /// 注册需要自动AutoMapper的对象信息
        /// </summary>
        public void Register()
        {
            //时间与字符串的处理
            CreateMap<string, DateTime>().ConvertUsing(new StringToDateTimeConverter());
            CreateMap<DateTime, string>().ConvertUsing(new DateTimeToStringConverter());
            CreateMap<string, DateTime?>().ConvertUsing(new StringToDateTimeNullConverter());
            CreateMap<DateTime?, string>().ConvertUsing(new DateTimeNullToStringConverter());
            //MongoDB的ID 与字符串的处理
            CreateMap<string, MongoDB.Bson.ObjectId>().ConvertUsing(new StringToObjectIdConverter());
            CreateMap<MongoDB.Bson.ObjectId, string>().ConvertUsing(new ObjectIdToStringConverter());
        }
    }
}
```

如果您只引用TianCheng.Model，您还得调用一下`TianCheng.Model.AutoMapperExtension.InitializeMappers();`来确保加载全部的对象转换配置。

### Json处理

使用了[Newtonsoft](https://www.newtonsoft.com/json)作为Json的处理方式。由于自己的习惯所以增加两个常用的扩展方法`ToJson`与`JsonToObject`。

例如：

```csharp
  QueryInfo query = new QueryInfo();
  string json = query.ToJson();
  QueryInfo info = json.JsonToObject<QueryInfo>();
```

### 日志处理

使用[Serilog](https://serilog.net/)作为日志处理的工具。已添加两个日志工具`CommonLog`与`AppLog`。`CommonLog`是按固定的配置写日志；`AppLog`是读取appsettings.json配置来写日志。

#### CommonLog

`CommonLog`的日志配置如下：

1. 控制台输出Information级别以上的信息；
2. Debug窗口输出为全输出；
3. 文件输出为Warning级别以上的，文件名格式为`Logs/TianCheng.Common-{Date}.txt`

#### AppLog

如果想`AppLog`在开发模式使用`appsettings.Development.json`配置；成产模式使用`appsettings.Production.json`配置。需要做如下步骤：

1、Program中做如下修改

```csharp
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .ConfigureAppConfiguration(TianCheng.Model.ServiceLoader.Appsettings)     // 新增一行
                .Build();
    }
```

2、在成产模式的机器增加环境变量`ASPNETCORE_ENVIRONMENT`并设置值为`Production`。

#### Serilog的配置信息参考如下

```json
  "Serilog": {
    "WriteTo": [
      {
        "Name": "RollingFile",
        "Args": {
          "pathFormat": "Logs/common-{Date}.txt",
          "restrictedToMinimumLevel": "Information"
        }
      },
      "Debug",
      {
        "Name": "Console",
        "Args": {
          "theme": "Serilog.Sinks.SystemConsole.Themes.AnsiConsoleTheme::Code, Serilog.Sinks.Console",
          "outputTemplate": "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj} <s:{SourceContext}>{NewLine}{Exception}",
          "restrictedToMinimumLevel": "Information"
        }
      },
      {
        "Name": "MongoDB",
        "Args": {
          "databaseUrl": "mongodb://localhost:27017/samples",
          "collectionName": "system_log",
          "restrictedToMinimumLevel": "Information"
        }
      }
    ]
  }
```

### 常用异常处理

为了统一异常的处理，增加了`ApiException`对象。通过自定义的异常抛错误有很多好处，例如，方便后续MVC中间件拦截并做想要的处理。

异常调用：

```csharp
ApiException.ThrowBadRequest("要删除的数据被使用，不能删除");
```

### 依赖注入

为了获取服务方便，增加了`ServiceLoader`，会自动对所有继承`IServiceRegister`的对象做注入操作，并可在任意的地方通过`ServiceLoader.GetService<T>()`的方式来获取想要的对象。

ServiceLoader的使用方式：

```csharp
DepartmentService departmentService = ServiceLoader.GetService<DepartmentService>();
```

如果想使用完整的功能，`Startup`代码如下：

```csharp
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
```
