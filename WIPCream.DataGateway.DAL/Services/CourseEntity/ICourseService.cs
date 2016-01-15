using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WIPCream.DataGateway.DAL2.Models;

namespace WIPCream.DataGateway.DAL2.Services.CourseEntity
{
    public interface ICourseService
    {
        string CreateEntity(Courses model);
        Courses Find(int id);
        string DeleteEntity(int id);
        string UpdateEntity(Courses model);
        List<Courses> RetrieveAll();
        WIPCream2 GetDB();
        void Dispose();
    }
}
