using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WIPCream.BusinessGateway.Logic.Model;
using WIPCream.DataGateway.DAL2.Models;

namespace WIPCream.BusinessGateway.Logic.Services.Course
{
    public interface ICourseBusinessService
    {
        string ResgisterCourse(CourseDTO model);
        string Delete(int id);
        List<CourseDTO> RetrieveAll();
        CourseDTO FindById(int id);
        string Update(CourseDTO Test);
        WIPCream2 getDB();
        void Dispose();
    }
}
