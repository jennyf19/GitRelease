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
            TagNameFormatCheck tagName = new TagNameFormatCheck();
            bool actual = tagName.TagNameFormat("v1.1111.1111");

            Assert.AreEqual(false, actual);
        }

        [TestMethod]
        public void TagNameFormatIncorrectWrongInitialLetterTest()
        {
            TagNameFormatCheck tagName = new TagNameFormatCheck();
            bool actual = tagName.TagNameFormat("b1.11.11");

            Assert.AreEqual(false, actual);
        }

        [TestMethod]
        public void TagNameFormatTagMissingTest()
        {
            TagNameFormatCheck tagName = new TagNameFormatCheck();
            bool actual = tagName.TagNameFormat("");

            Assert.AreEqual(false, actual);
        }

        [TestMethod]
        public void TagNameFormatInCorrectWithUpperCaseFirstLetterTest()
        {
            TagNameFormatCheck tagName = new TagNameFormatCheck();
            bool actual = tagName.TagNameFormat("V1.11.11");

            Assert.AreEqual(false, actual);
        }

        [TestMethod]
        public void TagNameFormatInCorrectWithSpecialCharacters()
        {
            TagNameFormatCheck tagName = new TagNameFormatCheck();
            bool actual = tagName.TagNameFormat("v#.!@.#$");

            Assert.AreEqual(false, actual);
        }

        [TestMethod]
        public void TagNameFormatInCorrectWithNullValue()
        {
            TagNameFormatCheck tagName = new TagNameFormatCheck();
            bool actual = tagName.TagNameFormat(null);

            Assert.AreEqual(false, actual);
        }

        [TestMethod]
        public void TagNameFormatInCorrectWithRandomName()
        {
            TagNameFormatCheck tagName = new TagNameFormatCheck();
            bool actual = tagName.TagNameFormat("Hello");

            Assert.AreEqual(false, actual);
        }

        [TestMethod]
        public void TagNameFormatInCorrectWithMissingDigits()
        {
            TagNameFormatCheck tagName = new TagNameFormatCheck();
            bool actual = tagName.TagNameFormat("V1.11.");

            Assert.AreEqual(false, actual);
        }

        [TestMethod]
        public void TagNameFormatCorrectWithOneAndTwoDigits()
        {
            TagNameFormatCheck tagName = new TagNameFormatCheck();
            bool actual = tagName.TagNameFormat("v1.2.33");

            Assert.AreEqual(true, actual);
        }

        [TestMethod]
        public void TagNameFormatCorrectWithThreeEndDigits()
        {
            TagNameFormatCheck tagName = new TagNameFormatCheck();
            bool actual = tagName.TagNameFormat("v1.11.222");

            Assert.AreEqual(true, actual);
        }

        [TestMethod]
        public void TagNameFormatCorrectTest()
        {
            TagNameFormatCheck tagName = new TagNameFormatCheck();
            bool actual = tagName.TagNameFormat("v1.11.11");

            Assert.AreEqual(true, actual);
        }
           
        [TestMethod]
        public void TagNameFormatCorrectWithSingleDigitsTest()
        {
            TagNameFormatCheck tagName = new TagNameFormatCheck();
            bool actual = tagName.TagNameFormat("v1.1.1");

            Assert.AreEqual(true, actual);
        }


        [TestMethod]
        public void TagNameFormatCorrectWithRandomDigitLenghtUpToThree()
        {
            TagNameFormatCheck tagName = new TagNameFormatCheck();
            bool actual = tagName.TagNameFormat("v1.2.25");

            Assert.AreEqual(true, actual);
        }
    }
}
