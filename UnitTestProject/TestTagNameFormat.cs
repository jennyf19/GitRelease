using System;
using System.Linq;
using Xunit;
using GitReleaseLibrary;

namespace UnitTestProject
{
    public class TestTagNameFormat
    {
        [Fact]
        public void TagNameFormatTest()
        {
            TagNameFormatCheck tagName = new TagNameFormatCheck();
            tagName.TagNameFormat("v1.11.11");
                        
            Assert.Equal("v1.11.11", tagName.ToString());
        }
    }
}
/*
 *  public string tagName { get; set; }

        public bool TagNameFormat(string tagName)
        {
            Regex tagNamePattern = new Regex(@"^v[1-9]\.([0-9][0-9]\.)([0-9][0-9])$");

            if (Regex.IsMatch(tagName, tagNamePattern.ToString()) && tagName != null)
            {
                return true;
            }

            else
            {
                return false;
            }
        }
*/