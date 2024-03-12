using System.ComponentModel.DataAnnotations;

namespace ChallengeStefaniniGroup.Core.Extensions
{
    public static class ExtensionEnum
    {
        public static string GetDisplayName(this Enum enu)
        {
            var nameFriendly = enu.GetType()?
                .GetField(enu.ToString())?
                .GetCustomAttributes(typeof(DisplayAttribute), false)
                .Cast<DisplayAttribute>()
                .SingleOrDefault()?
                .Name;
            return string.IsNullOrEmpty(nameFriendly) ? enu.ToString() : nameFriendly;
        }
    }
}
