﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WIPCream.DataGateway.DAL2.Models;

namespace WIPCream.DataGateway.DAL2.Services.DisciplineEntity
{
    public interface IDisciplineService
    {
        string CreateEntity(Disciplines model);
        Disciplines Find(int id);
        string DeleteEntity(int id);
        string UpdateEntity(Disciplines model);
        List<Disciplines> RetrieveAll();
        WIPCream2 GetDB();
        void Dispose();
    }
}
