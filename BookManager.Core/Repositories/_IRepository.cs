﻿using System.Collections.Generic;

namespace BookManager.Core.Repositories
{
    public interface _IRepository<T>
    {
        int Insert(T item);
        void Update(T item);
        void Delete(T item);
        T GetById(int id);
        IEnumerable<T> GetAll();
    }
}
