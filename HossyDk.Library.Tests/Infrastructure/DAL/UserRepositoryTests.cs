using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit;
using HossyDk.Library.Account.Infrastructure;
using HossyDk.Library.Interfaces;
using FluentAssertions;
using HossyDk.Library.Repositories;
using Ploeh.AutoFixture.Xunit2;

namespace HossyDk.Library.Tests.Infrastructure.DAL
{
    /// <summary>
    /// Summary description for UserRepositoryTests
    /// </summary>
    [TestClass]
    public class UserRepositoryTests
    {
        private readonly IRepository<User> _userRepository;

        public UserRepositoryTests()
        {
            _userRepository = new UserRepository();
        }

        [Fact]
        public void ItShouldThrowExceptionIfUserIsNull()
        {
            //arrange
            User usr = null;

            //act
            Action action = () => _userRepository.Add(usr);

            //assert
            action.ShouldThrow<ArgumentNullException>();
        }

        [Theory]
        [AutoData]
        public void ItShouldThrowExceptionIfUsernameIsNull(User user)
        {
            //arrange
            user.Username = null;

            //act
            Action action = () => _userRepository.Add(user);

            //assert
            action.ShouldThrow<NullReferenceException>();
        }

        [Theory]
        [AutoData]
        public void ItShouldThrowExceptionIfPasswordIsNull(User user)
        {
            //arrange
            user.Password = null;

            //act
            Action action = () => _userRepository.Add(user);

            //assert
            action.ShouldThrow<NullReferenceException>();
        }
    }
}
