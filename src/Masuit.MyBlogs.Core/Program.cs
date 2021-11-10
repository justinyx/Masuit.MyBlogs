﻿using Autofac.Extensions.DependencyInjection;
using Masuit.MyBlogs.Core;
using Masuit.MyBlogs.Core.Common;
using Masuit.MyBlogs.Core.Extensions.DriveHelpers;
using Masuit.MyBlogs.Core.Infrastructure;
using Masuit.MyBlogs.Core.Infrastructure.Drive;
using Masuit.Tools;
using Microsoft.AspNetCore.Server.Kestrel.Core;

if (!"223.5.5.5".GetIPLocation().Contains("阿里"))
{
    throw new Exception("IP地址库初始化失败，请重启应用！");
}

InitOneDrive();
PerfCounter.Init();
CreateWebHostBuilder(args).Build().Run();

static IHostBuilder CreateWebHostBuilder(string[] args) => Host.CreateDefaultBuilder(args).UseServiceProviderFactory(new AutofacServiceProviderFactory()).ConfigureWebHostDefaults(hostBuilder => hostBuilder.UseKestrel(opt =>
{
    var config = opt.ApplicationServices.GetService<IConfiguration>();
    var port = config["Port"] ?? "5000";
    var sslport = config["Https:Port"] ?? "5001";
    opt.ListenAnyIP(port.ToInt32());
    if (bool.Parse(config["Https:Enabled"]))
    {
        opt.ListenAnyIP(sslport.ToInt32(), s =>
        {
            if (Environment.OSVersion.Platform == PlatformID.Win32NT && Environment.OSVersion.Version.Major >= 10)
            {
                s.Protocols = HttpProtocols.Http1AndHttp2;
            }

            s.UseHttps(AppContext.BaseDirectory + config["Https:CertPath"], config["Https:CertPassword"]);
        });
    }

    opt.Limits.MaxRequestBodySize = null;
    Console.WriteLine($"应用程序监听端口：http：{port}，https：{sslport}");
}).UseStartup<Startup>());

static void InitOneDrive()
{
    //初始化
    if (!File.Exists(Path.Combine(Directory.GetCurrentDirectory(), "App_Data", "OneDrive.db")))
    {
        File.Copy("App_Data\\OneDrive.template.db", "App_Data\\OneDrive.db");
        Console.WriteLine("数据库创建成功");
    }

    using var settingService = new SettingService(new DriveContext());
    if (settingService.Get("IsInit") != "true")
    {
        settingService.Set("IsInit", "true").Wait();
        Console.WriteLine("数据初始化成功");
        Console.WriteLine($"请登录 {OneDriveConfiguration.BaseUri}/#/admin 进行身份及其他配置");
    }
}
