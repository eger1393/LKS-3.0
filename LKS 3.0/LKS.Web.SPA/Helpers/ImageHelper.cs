using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LKS.Web.Helpers
{
	public static class ImageHelper
	{
		public static async Task<string> SaveImageAsync(IFormFile file)
		{

			string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "photo"),
				filePath = GetFileName(folderPath, ".jpg");

			if (File.Exists(filePath))
				File.Delete(filePath);
			using(var stream = new FileStream(filePath, FileMode.Create))
			{
				await file.CopyToAsync(stream);
			}
			return $"/{filePath.Substring(filePath.IndexOf("photo")).Replace('\\', '/').TrimStart('/')}";
		}

		public static void DeleteImage(string filePath)
		{
			string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot") + filePath.Replace('/', '\\');
			if (File.Exists(path))
				File.Delete(path);
		}

		private static string GetFileName(string folderPath, string ext)
		{
			var md5 = System.Security.Cryptography.MD5.Create();
			var bytes = Encoding.ASCII.GetBytes( DateTime.Now.ToString());
			var hash = md5.ComputeHash(bytes);

			var sb = new StringBuilder();
			foreach (var h in hash)
				sb.AppendFormat("{0:x2}", h);

			var fileName = Path.Combine(folderPath, sb.ToString()) + ext;
			return fileName;
		}


	}
}
