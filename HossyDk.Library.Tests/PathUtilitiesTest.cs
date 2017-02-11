using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HossyDk.Library.Utils;

namespace HossyDk.Library.Tests
{
    [TestClass]
    public class PathUtilitiesTest
    {
        [TestMethod]
        public void ShouldRemoveIllegalCharactersInFileName()
        {
            //Arrange
            string illegalFileName = "/\\ok-this-is-a/-test-øæå\\//";
            string validFileName = "ok-this-is-a-test-øæå";

            //Act
            string replacedFileName = PathUtilities.RemoveIllegalPathCharacters(illegalFileName);

            //Assert
            Assert.AreEqual(replacedFileName, validFileName);
        }

        [TestMethod]
        public void ShouldNotRemoveIllegalCharactersInFileName()
        {
            //Arrange
            string illegalFileName = "this-is-a&&-test-øæå";
            string validFileName = "this-is-a&&-test-øæå";

            //Act
            string replacedFileName = PathUtilities.RemoveIllegalPathCharacters(illegalFileName);

            //Assert
            Assert.AreEqual(replacedFileName, validFileName);
        }

        [TestMethod]
        public void ShouldIncludeValidFileExtension()
        {
            //Arrange
            string legalFileName = "test.png";

            //Act
            bool isValidFileExtension = PathUtilities.IsLegalFileExtension(legalFileName);

            //Assert
            Assert.IsTrue(isValidFileExtension);
        }

        [TestMethod]
        public void ShouldIncludeValidUpperFileExtension()
        {
            //Arrange
            string legalFileName = "test.PNG";

            //Act
            bool isValidFileExtension = PathUtilities.IsLegalFileExtension(legalFileName);

            //Assert
            Assert.IsTrue(isValidFileExtension);
        }

        [TestMethod]
        public void ShouldNotIncludeValidFileExtension()
        {
            //Arrange
            string legalFileName = "test.pdf";

            //Act
            bool isValidFileExtension = PathUtilities.IsLegalFileExtension(legalFileName);

            //Assert
            Assert.IsFalse(isValidFileExtension);
        }
    }
}
