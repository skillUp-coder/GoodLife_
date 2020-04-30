﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeightLossSystem.Domain.Interfaces
{
    public interface IRepository<T> where T:class
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        void Create(T item);
        void Delete(int id);
        T CheckDatas(T user);
        T CheckDataRegister(T user);
        void Update(T item);
        IEnumerable<T> Find(Func<T, Boolean> predicate);
    }
}
