using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PortableLogin;

namespace PortableLoginTests
{
    [TestClass]
    public class UserTest
    {
        [TestMethod]
        public void hashPasswordTest()
        {
            string inserted = User.hashPassword("admin"); 
            string expected = "7c87541fd3f3ef5016e12d411900c87a6046a8e8";
            Assert.AreEqual(inserted, expected);
        }
        ////Username validation unit tests
        [TestMethod]
        public void isValidUsernameEmptyTest()
        {
            bool inserted =User.isValidUsername("");
            bool expected = false;
            Assert.AreEqual(inserted,expected);
        }
        [TestMethod]
          public void isValidUsernameWhiteSpaceTest()
        {
            bool inserted =User.isValidUsername(" ");
            bool expected = false;
            Assert.AreEqual(inserted,expected);
        }
        [TestMethod]
        public void isValidUsernameLongTest()
        {
            bool inserted =User.isValidUsername("123456789012345678901");
            bool expected = false;
            Assert.AreEqual(inserted,expected);
        }
         [TestMethod]
        public void isValidUsernameValidTest()
        {
            bool inserted =User.isValidUsername("admin");
            bool expected = true;
            Assert.AreEqual(inserted,expected);
        }
        ////Password validation unit tests
         [TestMethod]
         public void isValidPasswordEmptyTest()
         {
             bool inserted = User.isValidPassword("");
             bool expected = false;
             Assert.AreEqual(inserted, expected);
         }
         [TestMethod]
         public void isValidPasswordWhiteSpaceTest()
         {
             bool inserted = User.isValidPassword(" ");
             bool expected = false;
             Assert.AreEqual(inserted, expected);
         }
         [TestMethod]
         public void isValidPasswordLongTest()
         {
             bool inserted = User.isValidPassword("123456789012345678901");
             bool expected = false;
             Assert.AreEqual(inserted, expected);
         }
         [TestMethod]
         public void isValidPasswordValidTest()
         {
             bool inserted = User.isValidPassword("admin");
             bool expected = true;
             Assert.AreEqual(inserted, expected);
         }
    }
}
