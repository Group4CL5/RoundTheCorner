using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RoundTheCorner.BL.Models;

namespace RoundTheCorner.BL.Tests
{
    [TestClass]
    public class UTUser
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
            int expected = 2;

            Assert.AreEqual(users.Count, expected);
        }

        [TestMethod]
        public void Update()
        {
            List<UserModel> userModels = UserManager.GetUsers();


            UserModel user = userModels.FirstOrDefault(u => u.FirstName == "test");
            user.FirstName = "Tony";

            UserManager.Update(user);

            UserModel newUser = UserManager.GetUser(user.UserID);

            Assert.AreEqual(user.FirstName, newUser.FirstName);
        }

        [TestMethod]
        public void Login()
        {
            UserModel user = new UserModel
            {
                Email = "test@test.com",
                Password = "123",
            };

            bool result = UserManager.Login(user);
            Assert.IsTrue(result);
        }


        [TestMethod]
        public void Deactivate()
        {
            List<UserModel> userModels = UserManager.GetUsers();

            UserModel user = userModels.FirstOrDefault(u => u.FirstName == "Tony");

            UserManager.Deactivate(user.UserID);

            UserModel newUser = UserManager.GetUser(user.UserID);

            Assert.IsTrue(newUser.Deactivated);
        }

        [TestMethod]
        public void Delete()
        {
            List<UserModel> userModels = UserManager.GetUsers();

            UserModel user = userModels.FirstOrDefault(u => u.FirstName == "Tony");

            bool result = UserManager.Delete(user.UserID);
            Assert.IsTrue(result);
        }
    }
}
