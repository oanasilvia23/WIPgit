using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WIPCream.DataGateway.DAL2.Models;
using WIPCream.DataGateway.DAL2.Services.UsersEntity;
using System.Diagnostics;
using System.Security.Cryptography;
using WIPCream.DataGateway.DAL2.Services.AssignmentEntity;
using WIPCream.DataGateway.DAL2.Services.DisciplineEntity;
using WIPCream.DataGateway.DAL2.Services.UserDisciplineEntity;
using WIPCream.DataGateway.DAL2.Services.UserRoleEntity;

namespace WIPCream.DataGateway.DAL.UnitTest.Models
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class UnitTest1
    {
        IUsersService srv;
        IUserRoleService urs;
        IUserDisciplinesService uds;
        IDisciplineService ds;
        IAssignmentService AS;
        public UnitTest1()
        {
            //
            // TODO: Add constructor logic here
            //

            srv = new UsersService();
            urs=new UserRoleService();
            uds=new UserDisciplinesService();
            ds=new DisciplineService();
            AS=new AssignmentService();
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestMethod1()
        {
            //
            // TODO: Add test logic here
            //
            Users user = new Users();
            user.Email = "mirceasuceveanu@siemens.com";
            user.FirstName = "Mircea";
            user.Lastname = "Suceveanu";
            user.UserId = 0;
            user.Password = "mirciulika";
            user.StudentId = 3310;
            user.UserName = "MirceaDan";
            Debug.Assert(((srv.CreateEntity(user)).Equals("Succes!")));
            Users user2 = null;
            user2 = srv.Find(user.UserId);
            Debug.Assert(user2.Equals(user));
            Debug.Assert(user2!=null);
            Debug.Assert((srv.FindByEmail("mirceasuceveanu@siemens.com")).Equals(user));
            Debug.Assert((srv.FindByEmail("mircea.suceveanu@siemens.com"))==null);
            user2.Email = "mircea.suceveanu@siemens.com";
            srv.UpdateEntity(user2);
            Debug.Assert((srv.FindByEmail("mirceasuceveanu@siemens.com"))==null);
            Debug.Assert((srv.FindByEmail("mircea.suceveanu@siemens.com")).Equals(user));
            Debug.Assert(srv.RetrieveAll().Count==1);
            srv.DeleteEntity(user.UserId);
            Debug.Assert(srv.RetrieveAll().Count == 0);
        }

        [TestMethod]
        public void Testmethod2()
        {
            UserRoles ur=new UserRoles();
            Users user = new Users();
            user.Email = "mirceasuceveanu@siemens.com";
            user.FirstName = "Mircea";
            user.Lastname = "Suceveanu";
            user.UserId = 0;
            user.Password = "mirciulika";
            user.StudentId = 3310;
            user.UserName = "MirceaDan";
            ur.Users = user;
            ur.RoleId = 0;
            ur.UserId = 0;
            urs.CreateEntity(ur);
            Debug.Assert(urs.RetrieveAll().Count==1);
            UserRoles ur2 = null;
            ur2 = urs.Find(ur2.RoleId);
            Debug.Assert(ur.Equals(ur2));
            Debug.Assert(ur.UserId.Equals(urs.FindByUserId(ur2.UserId)));
            Debug.Assert(ur.Users.Email.Equals("mirceasuceveanu@siemens.com"));
            Debug.Assert(!ur.Users.Email.Equals("mircea.suceveanu@siemens.com"));
            user.Email = "mircea.suceveanu@siemens.com";
            ur.Users = user;
            Debug.Assert(urs.UpdateEntity(ur).Equals("Role updated!"));
            Debug.Assert(!ur.Users.Email.Equals("mirceasuceveanu@siemens.com"));
            Debug.Assert(ur.Users.Email.Equals("mircea.suceveanu@siemens.com"));
            Debug.Assert(urs.RetrieveAll().Count==1);
            urs.DeleteEntity(ur.RoleId);
            Debug.Assert(urs.RetrieveAll().Count == 0);
        }

        [TestMethod]
        public void TestMethod3()
        {
            UserDisciplines ud=new UserDisciplines();
            Users user = new Users();
            user.Email = "mirceasuceveanu@siemens.com";
            user.FirstName = "Mircea";
            user.Lastname = "Suceveanu";
            user.UserId = 0;
            user.Password = "mirciulika";
            user.StudentId = 3310;
            user.UserName = "MirceaDan";
            UserRoles ur = new UserRoles();
            ur.Users = user;
            ur.RoleId = 0;
            ur.UserId = 0;
            Disciplines dis=new Disciplines();
            dis.DisciplineId = 0;
            dis.Name = "Create C# app";
            ud.Discipline = dis;
            uds.CreateEntity(ud);
            Debug.Assert(uds.RetrieveAll().Count==1);
            Debug.Assert(uds.Find(dis.DisciplineId)!=null);
            Debug.Assert(uds.Find(dis.DisciplineId).Equals(ud));
            Debug.Assert(uds.Find(dis.DisciplineId).Discipline.Name.Equals("Create C# app"));
            dis.Name = "Create Java app";
            ud.Discipline = dis;
            Debug.Assert(uds.Find(dis.DisciplineId).Discipline.Name.Equals("Create Java app"));
            uds.DeleteEntity(ud.DisciplineId);
            Debug.Assert(uds.RetrieveAll().Count==0);
        }

        [TestMethod]
        public void Testmethod4()
        {
            Disciplines d=new Disciplines();
            d.DisciplineId = 0;
            d.Name = "Math";
            Debug.Assert((ds.CreateEntity(d)).Equals("Succes!"));
            Debug.Assert(ds.RetrieveAll().Count==1);
            Debug.Assert(d.Name.Equals("Math"));
            Debug.Assert(!d.Name.Equals("Informatics"));
            d.Name = "pula";
            ds.UpdateEntity(d);
            Debug.Assert(!d.Name.Equals("Math"));
            Debug.Assert(d.Name.Equals("Informatics"));
            Disciplines d2 = ds.Find(d.DisciplineId);
            Debug.Assert(d.DisciplineId==d2.DisciplineId);
            ds.CreateEntity(d2);
            Debug.Assert(ds.RetrieveAll().Count==2);
            ds.DeleteEntity(d.DisciplineId);
            ds.DeleteEntity(d2.DisciplineId);
            Debug.Assert(ds.RetrieveAll().Count==0);
        }

        [TestMethod]
        public void TestMethod5()
        {
            Disciplines d = new Disciplines();
            d.DisciplineId = 0;
            d.Name = "Informatics";
            Assignments a=new Assignments();
            a.DisciplineId = 0;
            a.AssignmentId = 0;
            a.CreatedAt=DateTime.Now;
            a.Deadline=DateTime.Now;
            a.Description = "Create an MVC application";
            a.Disciplines = d;
            a.Name = "WIPCream";
            Debug.Assert((AS.CreateEntity(a)).Equals("Succes!"));
            Debug.Assert(AS.RetrieveAll().Count==1);
            Assignments a2 = AS.Find(a.AssignmentId);
            a2.AssignmentId = 1;
            Debug.Assert(a2.AssignmentId==a.AssignmentId);
            d.Name = "pula";
            a.Disciplines = d;
            Debug.Assert(AS.UpdateEntity(a).Equals("Succes!"));
            Debug.Assert(AS.Find(a.AssignmentId).Name.Equals("Mathematics"));
            AS.CreateEntity(a2);
            Debug.Assert(AS.RetrieveAll().Count==2);
            AS.DeleteEntity(a.AssignmentId);
            AS.DeleteEntity(a2.AssignmentId);
            Debug.Assert(AS.RetrieveAll().Count==0);
        }
    }
}
