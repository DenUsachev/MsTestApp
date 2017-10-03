using System;

namespace TestApp.Import.Interfaces
{
    /// <summary>
    /// File uploader interface
    /// </summary>
    public interface IFileUploader
    {
        event EventHandler<string> OnEventLogged;
        void UploadFile(string filepath);
    }
}
