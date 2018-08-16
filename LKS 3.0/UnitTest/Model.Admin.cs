using System;
using System.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using LKS_3._0.Model;
using System.Collections.Generic;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Admin_Initials()
        {
            List<Admin> admins = new List<Admin>();
            admins.Add(new Admin() { FirstName = "test", MiddleName = "Rest", LastName = "Est" });
            admins.Add(new Admin());
            admins.Add(new Admin() { FirstName = "test", MiddleName = "Rest"});

            Assert.AreEqual(admins[0].Initials, "Rest t. E.");
            Assert.ThrowsException<Exception>(() => admins[1].Initials);
            Assert.ThrowsException<Exception>(() => admins[2].Initials);
        }
    }
}
