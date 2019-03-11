﻿using System;
using EwuConnect.Domain.Models.Profile;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EwuConnect.Domain.Tests.Models.Profile
{
    [TestClass]
    public class UserTests
    {
        [TestMethod]
        public void UserTests_1_Pass()
        {
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void User_CreateUser_Pass()
        {
            User user = new User { FirstName = "Kyle", LastName = "Burgi" };
            Assert.AreEqual("Kyle", user.FirstName);
            Assert.AreEqual("Burgi", user.LastName);
        }
    }
}
