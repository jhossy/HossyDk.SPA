using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit;
using HossyDk.Library.Account.Infrastructure;
using FluentAssertions;

namespace HossyDk.Library.Tests.Infrastructure.Account
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class UserTests
    {
        [Theory]
        [InlineData(null, "password")]
        public void ItShouldThrowNullReferenceExceptionWhenUsernameIsNull(
            string username,
            string password)
        {
            //arrange
            Action action = () => new User(username, password);

            //act

            //assert
            action.ShouldThrow<ArgumentNullException>();
        }

        [Theory]
        [InlineData("username", null)]
        public void ItShouldThrowNullReferenceExceptionWhenPasswordIsNull(
            string username,
            string password)
        {
            //arrange
            Action action = () => new User(username, password);

            //act

            //assert
            action.ShouldThrow<ArgumentNullException>();
        }
    }
}
