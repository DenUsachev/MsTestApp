using System;

namespace TestApp.Import.Interfaces
{
    public interface IFileUploader
    {
        event EventHandler<string> OnEventLogged;
        void UploadFile(string filepath);
    }
}
