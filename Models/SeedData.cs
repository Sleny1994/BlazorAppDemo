using Microsoft.EntityFrameworkCore;

namespace BlazorAppDemo.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BookContext(serviceProvider.GetRequiredService<DbContextOptions<BookContext>>())) 
            { 
                // 如果数据库中有Book表，则数据初始化类将返回，不添加任何数据
                if(context.Book.Any()) { return; } // DB has been seeded

                context.Book.AddRange(
                    new Book
                    {
                        Name = "Python编程 从入门到实践",
                        ReleaseDate = DateTime.Parse("2018-1-12"),
                        Author = "埃里克·马瑟斯",
                        Price = 75.99M,
                        StockQty = 10,
                        Qty = 0,
                        TotalPages = 445,
                        Type = ""
                    },
                    new Book
                    {
                        Name = "Java编程的逻辑",
                        ReleaseDate = DateTime.Parse("2018-1-13"),
                        Author = "马俊昌",
                        Price = 48.99M,
                        StockQty = 12,
                        Qty = 0,
                        TotalPages = 675,
                        Type = ""
                    },
                    new Book
                    {
                        Name = "统计思维:大数据时代瞬间洞察因果的关键技能",
                        ReleaseDate = DateTime.Parse("2017-12-23"),
                        Author = "西内启",
                        Price = 39.99M,
                        StockQty = 20,
                        Qty = 0,
                        TotalPages = 330,
                        Type = ""
                    },
                    new Book
                    {
                        Name = "微信营销",
                        ReleaseDate = DateTime.Parse("2018-01-05"),
                        Author = "徐林海",
                        Price = 33.99M,
                        StockQty = 30,
                        Qty = 0,
                        TotalPages = 266,
                        Type = ""
                    }) ;
                // 保存修改，缺少则不会写入数据库中
                context.SaveChanges();
            }
        }
    }
}
