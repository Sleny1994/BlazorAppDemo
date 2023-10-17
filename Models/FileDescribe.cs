using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorAppDemo.Models
{
    public class FileDescribe
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]

        [Key]
        public int ID { get; set; }

        [Display(Name = "文件名称")]
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Display(Name = "上传后文件名称")]
        [StringLength(100)]
        public string NewName { get; set; }

        [Display(Name = "文件大小(bytes)")]
        [DisplayFormat(DataFormatString = "{0:N1}")]
        public long FileSize { get; set; }

        [Display(Name = "文件描述")]
        public string PubliceDescribe { get; set; }

        [Display(Name = "文件路径")]
        [StringLength (300)]
        public string FullName { get; set; }

        [Display(Name = "上传时间(UTC)")]
        [DisplayFormat(DataFormatString = "{0:F}")]
        [Required]
        public DateTime UploadDateTime { get; set; }
    }
}
