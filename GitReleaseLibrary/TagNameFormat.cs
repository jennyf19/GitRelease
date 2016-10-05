using System.Text.RegularExpressions;


namespace GitReleaseAutomator
{
    public class TagNameFormat
    {
        private static Regex _tagNamePattern = new Regex(@"^v[1-9]{1,2}\.([0-9]{1,2}\.)([0-9]{1,3})$");

        public static bool IsValid(string tagName)
        {
            if (string.IsNullOrEmpty(tagName))
            {
                return false;
            }
            return _tagNamePattern.IsMatch(tagName);
        }
    }
}
