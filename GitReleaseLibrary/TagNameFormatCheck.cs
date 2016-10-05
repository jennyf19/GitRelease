using System.Text.RegularExpressions;


namespace GitReleaseLibrary
{
    public class TagNameFormatCheck
    {
        private static Regex _tagNamePattern = new Regex(@"^v[1-9]\.([0-9]{1,2}\.)([0-9]{1,3})$");

        public static bool TagNameFormat(string tagName)
        {
            if (string.IsNullOrEmpty(tagName)) return false;

            return _tagNamePattern.IsMatch(tagName);
        }
    }
}
