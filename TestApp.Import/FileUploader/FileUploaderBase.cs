using System;
using TestApp.Import.Interfaces;

namespace TestApp.Import.FileUploader
{
    public abstract class FileUploaderBase : IFileUploader
    {
        public event EventHandler<string> OnEventLogged;
        public abstract void UploadFile(string filepath);

        protected virtual void OnOnEventLogged(string e)
        {
            OnEventLogged?.Invoke(this, e);
        }
    }
}
