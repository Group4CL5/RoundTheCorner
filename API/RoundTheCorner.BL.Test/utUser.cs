using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RoundTheCorner.BL.Models;

namespace RoundTheCorner.BL.Tests
{
    [TestClass]
    public class utUser
    {
        [TestMethod]
        public void Seed()
        {
            bool result = UserManager.Seed();
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GetUsers()
        {
            List<UserModel> users = UserManager.GetUsers();
            int expected = 1;

            Assert.Equals(users.Count, expected);
        }

        [TestMethod]
        public void Update()
        {
            UserModel user = new UserModel
            {
                userID = 1,
                email = "test@test.com",
                firstName = "Wadabinga",
                lastName = "testAccount",
                password = UserManager.GetHash("123"),
                phone = "123-456-7890"
            };

            UserManager.Update(user);

            UserModel newUser = UserManager.GetUser(1);

            Assert.Equals(user.firstName, newUser.firstName);
        }

        [TestMethod]
        public void Login()
        {
            UserModel user = new UserModel
            {
                email = "test@test.com",
                password = UserManager.GetHash("123"),
            };

            bool result = UserManager.Login(user);
            Assert.IsTrue(result);
        }


        [TestMethod]
        public void Deactivate()
        {
            UserManager.Deactivate(1);

            UserModel user = UserManager.GetUser(1);

            Assert.IsTrue(user.deactivated);
        }

        [TestMethod]
        public void Delete()
        {
            bool result = UserManager.Delete(1);
            Assert.IsTrue(result);
        }
    }
}
