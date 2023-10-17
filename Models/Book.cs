using System.ComponentModel.DataAnnotations;

namespace BlazorAppDemo.Models
{
    public class Book
    {
        private string name = string.Empty;
        private string author = string.Empty;

        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "图书名称必须填写且不能超过50个字符。"),StringLength(50)]
        public string Name { get => name; set => name = value; }

        [Required(ErrorMessage = "作者名称必须填写且不能超过40个字符。"),StringLength(40)]
        public string Author { get => author; set => author = value; }

        public DateTime ReleaseDate { get; set; }

        public decimal Price { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$"), Required(ErrorMessage = "图书类型必须填写且只能是A-Z的字母，最少一个字母，做多10个字母。"),MinLength(1),StringLength(10)]
        // 禁用空格，数字和特殊符号
        public string? Type { get; set; }

        public int TotalPages { get; set; }

        [Range(2,30,ErrorMessage = "图书库存数量在2-30之间。")]
        public int StockQty { get; set; }

        public int Qty { get; set; }
    }
}
