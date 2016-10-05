using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GitReleaseLibrary;

namespace GitReleaseLibraryTest
{
    [TestClass]
    public class TagNameFormatCheckTest
    {
        [TestMethod]
        public void TagNameFormatIncorrectWithTooManyDigitsTest()
        {
            bool actual = TagNameFormatCheck.TagNameFormat("v1.1111.1111");
            Assert.AreEqual(false, actual);
        }

        [TestMethod]
        public void TagNameFormatIncorrectWrongInitialLetterTest()
        {
            bool actual = TagNameFormatCheck.TagNameFormat("b1.11.11");
            Assert.AreEqual(false, actual);
        }

        [TestMethod]
        public void TagNameFormatIncorrectWithDotDot()
        {
            bool actual = TagNameFormatCheck.TagNameFormat("v1..");
            Assert.AreEqual(false, actual);
        }

        [TestMethod]
        public void TagNameFormatTagMissingTest()
        {
            bool actual = TagNameFormatCheck.TagNameFormat("");
            Assert.AreEqual(false, actual);
        }

        [TestMethod]
        public void TagNameFormatInCorrectWithUpperCaseFirstLetterTest()
        {
            bool actual = TagNameFormatCheck.TagNameFormat("V1.11.11");
            Assert.AreEqual(false, actual);
        }

        [TestMethod]
        public void TagNameFormatInCorrectWithSpecialCharacters()
        {
            bool actual = TagNameFormatCheck.TagNameFormat("v#.!@.#$");
            Assert.AreEqual(false, actual);
        }

        [TestMethod]
        public void TagNameFormatInCorrectWithNullValue()
        {
            bool actual = TagNameFormatCheck.TagNameFormat(null);
            Assert.AreEqual(false, actual);
        }

        [TestMethod]
        public void TagNameFormatInCorrectWithRandomName()
        {
            bool actual = TagNameFormatCheck.TagNameFormat("Hello");
            Assert.AreEqual(false, actual);
        }

        [TestMethod]
        public void TagNameFormatInCorrectWithMissingDigits()
        {
            bool actual = TagNameFormatCheck.TagNameFormat("V1.11.");
            Assert.AreEqual(false, actual);
        }

        [TestMethod]
        public void TagNameFormatCorrectWithOneAndTwoDigits()
        {
            bool actual = TagNameFormatCheck.TagNameFormat("v1.2.33");
            Assert.AreEqual(true, actual);
        }

        [TestMethod]
        public void TagNameFormatCorrectWithThreeEndDigits()
        {
            bool actual = TagNameFormatCheck.TagNameFormat("v1.11.222");
            Assert.AreEqual(true, actual);
        }

        [TestMethod]
        public void TagNameFormatCorrectTest()
        {
            bool actual = TagNameFormatCheck.TagNameFormat("v1.11.11");
            Assert.AreEqual(true, actual);
        }
           
        [TestMethod]
        public void TagNameFormatCorrectWithSingleDigitsTest()
        {
            bool actual = TagNameFormatCheck.TagNameFormat("v1.1.1");
            Assert.AreEqual(true, actual);
        }


        [TestMethod]
        public void TagNameFormatCorrectWithRandomDigitLenghtUpToThree()
        {
            bool actual = TagNameFormatCheck.TagNameFormat("v1.2.25");
            Assert.AreEqual(true, actual);
        }
    }
}
