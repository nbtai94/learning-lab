using System.Runtime.CompilerServices;

namespace DemoIdentityRole.Extentions
{
    public static class StringHandler
    {
        public static string RemoveSign(this string str)
        {
            str = str + "hello";
            return str;
        }
    }
}
