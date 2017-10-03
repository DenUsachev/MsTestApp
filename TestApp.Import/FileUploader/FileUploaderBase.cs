using TestApp.Import.Interfaces;

namespace TestApp.Import.FileUploader
{
    public abstract class FileUploaderBase : IFileUploader
    {
        public abstract void UploadFile(string filepath);
    }
}
