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
            bool actual = tagName.TagNameFormat("v1.111.111");

            Assert.AreEqual(false, actual);
        }

        [TestMethod]
        public void TagNameFormatIncorrectWithTooFewDigitsTest()
        {
            TagNameFormatCheck tagName = new TagNameFormatCheck();
            bool actual = tagName.TagNameFormat("v1.1.1");

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
        public void TagNameFormatCorrectTest()
        {
            TagNameFormatCheck tagName = new TagNameFormatCheck();
            bool actual = tagName.TagNameFormat("v1.11.11");

            Assert.AreEqual(true, actual);
        }
    }
}
