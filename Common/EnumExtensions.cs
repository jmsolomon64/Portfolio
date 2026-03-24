using System.ComponentModel;
using System.Reflection;

namespace Common;

public static class EnumExtensions
{
    public static string GetDescription<T>(this T target) where T : Enum
    {
        string description = string.Empty;
        Type type = typeof(T);

        MemberInfo? targetMemberInfo = type.GetMember(target.ToString())
            .FirstOrDefault(x => x.DeclaringType == type);

        if(targetMemberInfo != null)
        {
            description = targetMemberInfo.Name;

            Attribute? attr = targetMemberInfo
                .GetCustomAttribute(typeof(DescriptionAttribute));

            description = attr == null ? description 
                : ((DescriptionAttribute)attr).Description;
        }

        return description;
    }

    public static List<T> GetEnumValues<T>() where T : Enum =>
        Enum.GetValues(typeof(T)).Cast<T>().ToList();
}
