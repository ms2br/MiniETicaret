﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Services.Interfaces.Storage
{
    public interface IStorageService : IStorage
    {
        protected string StorageName { get; }
    }
}
