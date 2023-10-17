using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Net;

namespace BlazorAppDemo.Utils
{
    public class FileHelpers
    {
        public static string NewName;
        public static string FullName;
        public static async Task<string> ProcessFormFile(IBrowserFile formFile, ModelStateDictionary modelState, IWebHostEnvironment env, int maxFileSize)
        {
            var fieldDisplayName = string.Empty;
            if (!string.IsNullOrEmpty(formFile.Name))
            {
                // 如果名称未找到，会提示简单错误消息，但不会显示文件名称
                string displayFileName = formFile.Name.Substring(formFile.Name.IndexOf('.') + 1);
                fieldDisplayName = $"{displayFileName}";
            }
            // 使用path.GetFileName获取一个带路径的全文件名
            // 通过HtmlEncode进行编码的结果必须在错误消息中返回
            var fileName = WebUtility.HtmlEncode(Path.GetFileName(formFile.Name));
            if(formFile.ContentType.ToLower() != "text/plain")
            {
                modelState.AddModelError(formFile.Name, $"The {fieldDisplayName}file ({fileName}) must be a text file.");
            }

            // 校验文件长度，如果文件不包含内容，则不必读取文件长度
            // 此校验不会检查仅具有BOM（字节顺序标记）作为内容的文件
            // 因此在读取文件内容后再次检查文件内容长度，以校验仅包含BOM的文件
            if(formFile.Size == 0)
            {
                modelState.AddModelError(formFile.Name, $"The {fieldDisplayName}file ({fileName}) is empty.");
            }
            else if(formFile.Size > maxFileSize)
            {
                modelState.AddModelError(formFile.Name, $"The {fieldDisplayName}file ({fileName}) exceeds 1 MB.");
            }
            else
            {
                try
                {
                    // 获取一个随机文件名
                    var trustedFileNameForFileStorage = Path.GetRandomFileName();
                    var path = Path.Combine(env.ContentRootPath, env.EnvironmentName, "unsafeUploads", trustedFileNameForFileStorage);

                    NewName = trustedFileNameForFileStorage;
                    FullName = path;

                    using (var reader = new FileStream(path, FileMode.Create))
                    {
                        await formFile.OpenReadStream(maxFileSize).CopyToAsync(reader);
                    }
                }
                catch(Exception ex) {
                    modelState.AddModelError(formFile.Name,
                        $"The {fieldDisplayName}file ({fileName}) upload failed." +
                        $"Please contact the Help Desk for support.Error: {ex.Message}");
                    throw ex;
                }
            }
            return string.Empty;
        }
    }
}
