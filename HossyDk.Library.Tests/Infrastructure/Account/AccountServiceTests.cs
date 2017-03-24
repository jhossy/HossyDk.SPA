using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit;
using HossyDk.Library.Interfaces;
using HossyDk.Library.Infrastructure.Account;
using HossyDk.Library.Account.Infrastructure;
using System.Collections.Generic;
using FluentAssertions;
using System.Linq;

namespace HossyDk.Library.Tests.Infrastructure.Account
{
    /// <summary>
    /// Summary description for AccountServiceTests
    /// </summary>
    [TestClass]
    public class AccountServiceTests
    {
        private readonly IRepository<User> _userRepository;

        public AccountServiceTests()
        {
            _userRepository = new FakeUserRepository();
        }

        [Theory]
        [InlineData("test", "validpassword")]
        public void ItShouldAuthenticate(
            string userName,
            string password)
        {
            //arrange
            var sut = new AccountService(_userRepository);

            //act
            var newUser = new User(userName, password);
            _userRepository.Add(newUser);

            //assert
            sut.Login(newUser).Should().BeTrue();
        }

        [Theory]
        [InlineData("test", "badpassword")]
        public void ItShouldNotAuthenticate(
            string userName,
            string password)
        {
            //arrange
            var sut = new AccountService(_userRepository);

            //act
            var newUser = new User(userName, password);

            //assert
            sut.Login(newUser).Should().BeFalse();
        }

        [Fact]
        public void ItShouldNotAuthenticateWhenUserIsNull()
        {
            //arrange
            var sut = new AccountService(_userRepository);

            //act
            
            //assert
            sut.Login(null).Should().BeFalse();
        }

        [Theory]
        [InlineData("test", "validpassword")]
        public void ItShouldNotAuthenticateWhenUserNameIsNull(
            string userName,
            string password)
        {
            //arrange
            var sut = new AccountService(_userRepository);

            //act
            var newUser = new User(userName, password);
            _userRepository.Add(newUser);
            newUser.Username = null;

            //assert
            sut.Login(newUser).Should().BeFalse();
        }

        [Theory]
        [InlineData("test", "validpassword")]
        public void ItShouldNotAuthenticateWhenPasswordIsNull(
            string username,
            string password)
        {
            //arrange
            var sut = new AccountService(_userRepository);

            //act
            var newUser = new User(username, password);
            _userRepository.Add(newUser);
            newUser.Password = null;

            //assert
            sut.Login(newUser).Should().BeFalse();
        }

        [Theory]
        [InlineData("", "password")]
        public void ItShouldNotAuthenticateWhenUsernameIsEmptyString(
            string username,
            string password)
        {
            //arrange
            var sut = new AccountService(_userRepository);

            //act
            var newUser = new User(username, password);
            _userRepository.Add(newUser);

            //assert
            sut.Login(newUser).Should().BeFalse();
        }

        [Theory]
        [InlineData("username", "")]
        public void ItShouldNotAuthenticateWhenPasswordIsEmptyString(
            string username,
            string password)
        {
            //arrange
            var sut = new AccountService(_userRepository);

            //act
            var newUser = new User(username, password);
            _userRepository.Add(newUser);

            //assert
            sut.Login(newUser).Should().BeFalse();
        }
    }

    public class FakeUserRepository : IRepository<User>
    {
        private List<User> _repository;

        public FakeUserRepository()
        {
            _repository = new List<User>();
        }

        public void Add(User user)
        {
            _repository.Add(user);
        }

        public IEnumerable<User> GetAll()
        {
            return _repository.ToList();
        }
    }
}
