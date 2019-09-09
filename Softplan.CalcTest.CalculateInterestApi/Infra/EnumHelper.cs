using System;
using System.ComponentModel;
using System.Reflection;

namespace Softplan.CalcTest.CalculateInterestApi.Infra
{
    /// <summary>
    /// Inspired by: https://weblogs.asp.net/grantbarrington/enumhelper-getting-a-friendly-description-from-an-enum
    /// </summary>
    public static class EnumHelper
    {
        /// <summary>
        /// Retrieve the description on the enum, e.g.
        /// [Description("Bright Pink")]
        /// BrightPink = 2,
        /// Then when you pass in the enum, it will retrieve the description
        /// </summary>
        /// <param name="enum">The Enumeration</param>
        /// <returns>A string representing the friendly name</returns>
        public static string GetDescription(this Enum @enum)
        {
            var type = @enum.GetType();

            var memberInfos = type.GetMember(@enum.ToString());

            if (memberInfos.Length <= 0) return @enum.ToString();

            var customAttributes = memberInfos[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

            return customAttributes.Length > 0 ? ((DescriptionAttribute)customAttributes[0]).Description : @enum.ToString();
        }

    }
}
