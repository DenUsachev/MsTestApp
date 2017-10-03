﻿using System;

namespace TestApp.Import.Interfaces
{
    public interface IDataRepository<T> where T : class
    {
        T Get(int id);

        bool Add(T entry);

        void Delete(T entry);

        void Update(T entry);
    }
}
