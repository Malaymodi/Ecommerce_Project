using Ecommerce_Project_WebAPI.Services.Interface;

namespace Ecommerce_Project_WebAPI.Services
{
    public class Fileservice : IFileService
    {
        private readonly IWebHostEnvironment env;

        public Fileservice(IWebHostEnvironment env)
        {
            this.env = env;
        }

        public string Upload(IFormFile file)
        {
            var uploadDirecotroy = "wwwroot/Images";
            var uploadPath = Path.Combine(env.WebRootPath, uploadDirecotroy);

            if (!Directory.Exists(uploadPath))
                Directory.CreateDirectory(uploadPath);

            var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
            var filePath = Path.Combine(uploadPath, fileName);

            using (var strem = File.Create(filePath))
            {
                file.CopyTo(strem);
            }
            return fileName;
        }
    }
}
