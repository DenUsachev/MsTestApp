using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TestApp.Domain;
using TestApp.Import.Interfaces;

namespace TestApp.Import.FileUploader
{
    public abstract class FileUploaderBase : IFileUploader
    {
        public event EventHandler<string> OnEventLogged;
        public abstract void UploadFile(string filepath);

        public bool ValidateEntry(CustomerEntry entry, out IList<string> validationErrors)
        {
            validationErrors = new List<string>();
            if (entry.Amount < 0)
            {
                validationErrors.Add("Importing amount must be positive");
                return false;
            }
            return true;
        }

        protected virtual void RaiseLogEvent(string message)
        {
            OnEventLogged?.Invoke(this, message);
        }
    }
}
