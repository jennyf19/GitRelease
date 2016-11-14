using GitReleaseAutomator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GitReleaseLibraryTest
{
    [TestClass]
    public class TagNameFormatTest
    {
        [TestMethod]
        public void TagNameFormatIncorrectWithTooManyDigitsTest()
        {
            bool actual = TagNameFormat.IsValid("v1.1111.1111");
            Assert.AreEqual(false, actual);
        }

        [TestMethod]
        public void TagNameFormatIncorrectWrongInitialLetterTest()
        {
            bool actual = TagNameFormat.IsValid("b1.11.11");
            Assert.AreEqual(false, actual);
        }

        [TestMethod]
        public void TagNameFormatIncorrectWithDotDot()
        {
            bool actual = TagNameFormat.IsValid("v1..");
            Assert.AreEqual(false, actual);
        }

        [TestMethod]
        public void TagNameFormatTagMissingTest()
        {
            bool actual = TagNameFormat.IsValid("");
            Assert.AreEqual(false, actual);
        }

        [TestMethod]
        public void TagNameFormatInCorrectWithUpperCaseFirstLetterTest()
        {
            bool actual = TagNameFormat.IsValid("V1.11.11");
            Assert.AreEqual(false, actual);
        }

        [TestMethod]
        public void TagNameFormatInCorrectWithSpecialCharacters()
        {
            bool actual = TagNameFormat.IsValid("v#.!@.#$");
            Assert.AreEqual(false, actual);
        }

        [TestMethod]
        public void TagNameFormatInCorrectWithNullValue()
        {
            bool actual = TagNameFormat.IsValid(null);
            Assert.AreEqual(false, actual);
        }

        [TestMethod]
        public void TagNameFormatInCorrectWithRandomName()
        {
            bool actual = TagNameFormat.IsValid("Hello");
            Assert.AreEqual(false, actual);
        }

        [TestMethod]
        public void TagNameFormatInCorrectWithMissingDigits()
        {
            bool actual = TagNameFormat.IsValid("V1.11.");
            Assert.AreEqual(false, actual);
        }

        [TestMethod]
        public void TagNameFormatCorrectWithOneAndTwoDigits()
        {
            bool actual = TagNameFormat.IsValid("v1.2.33");
            Assert.AreEqual(true, actual);
        }

        [TestMethod]
        public void TagNameFormatCorrectWithThreeEndDigits()
        {
            bool actual = TagNameFormat.IsValid("v1.11.222");
            Assert.AreEqual(true, actual);
        }

        [TestMethod]
        public void TagNameFormatCorrectTest()
        {
            bool actual = TagNameFormat.IsValid("v1.11.11");
            Assert.AreEqual(true, actual);
        }
           
        [TestMethod]
        public void TagNameFormatCorrectWithSingleDigitsTest()
        {
            bool actual = TagNameFormat.IsValid("v1.1.1");
            Assert.AreEqual(true, actual);
        }


        [TestMethod]
        public void TagNameFormatCorrectWithRandomDigitLenghtUpToThree()
        {
            bool actual = TagNameFormat.IsValid("v1.2.25");
            Assert.AreEqual(true, actual);
        }
    }
}
