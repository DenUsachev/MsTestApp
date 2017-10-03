using System;
using System.Collections.Generic;
using TestApp.Domain;
using TestApp.Import.Interfaces;

namespace TestApp.Import.FileUploader
{
    /// <summary>
    /// Base implementation of File Uploader.
    /// </summary>
    public abstract class FileUploaderBase : IFileUploader
    {
        protected CustomerRepository Repository;

        public event EventHandler<string> OnEventLogged;
        public abstract void UploadFile(string filepath);

        /// <summary>
        /// Validates the amount of the current entry
        /// </summary>
        /// <param name="entry">Current entry</param>
        /// <param name="validationErrors">Validation error text</param>
        /// <returns></returns>
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

        /// <summary>
        /// Saves entry to the DB
        /// </summary>
        /// <param name="entry"></param>
        protected void SaveEntry(CustomerEntry entry)
        {
            IList<string> validationMessages;
            if (ValidateEntry(entry, out validationMessages))
            {
                Repository.Add(entry);
            }
            else
            {
                foreach (var validationMessage in validationMessages)
                {
                    RaiseLogEvent(validationMessage);
                }
            }
        }

        /// <summary>
        /// Raises an event to log import message
        /// </summary>
        /// <param name="message"></param>
        protected virtual void RaiseLogEvent(string message)
        {
            OnEventLogged?.Invoke(this, message);
        }
    }
}
