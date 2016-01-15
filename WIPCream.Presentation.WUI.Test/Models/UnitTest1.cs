using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WIPCream.BusinessGateway.Logic.Model;
using System.Diagnostics;
using WIPCream.BusinessGateway.Logic.Services.User;
using WIPCream.BusinessGateway.Logic.Services.UserDisciplines;
using WIPCream.BusinessGateway.Logic.Services.UserRoles;
using WIPCream.BusinessGateway.Logic.Services.Disciplines;
using WIPCream.BusinessGateway.Logic.Services.Assignments;

namespace WIPCream.Presentation.WUI.Test.Models
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class UnitTest1
    {
        IUsersBusinessService ubs;
        IUserDisciplineBusinessService udbs;
        IUserRoleBusinessService urbs;
        IDisciplineBusinessService dbs;
        IAssignmentBusinessSerevice abs;
        public UnitTest1()
        {
            //
            // TODO: Add constructor logic here
            //
            ubs = new UserBusinessService();
            udbs = new UserDisciplineBusinessService();
            urbs = new UserRoleBusinessService();
            dbs = new DisciplineBusinessService();
            abs = new AssignmentBusinessService();
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
            
        }

        
    }
}
