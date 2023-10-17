using Microsoft.Extensions.Configuration.Json;

namespace BlazorAppDemo.Data
{
    // 该类用于读取appsettings.json文件中的配置信息
    public class ConfigHelper
    {
        public static IConfiguration Configuration { get; set; }
        static ConfigHelper() 
        {
            // ReloadOnChange = true 表示当appsettings.json被修改时重新加载
            Configuration = new ConfigurationBuilder()
                .Add(new JsonConfigurationSource { Path = "appsettings.json", ReloadOnChange = true })
                .Build();
        }
    }
}
