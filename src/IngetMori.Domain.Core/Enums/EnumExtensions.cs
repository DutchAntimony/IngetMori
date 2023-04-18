using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Reflection;

namespace IngetMori.Domain.Core.Enums;
public static class EnumExtensions
{
    public static string DisplayName(this Enum enumValue)
    {
        var enumType = enumValue.GetType();
        MemberInfo info = enumType.GetMember(enumValue.ToString()).First();

        return info is not null && info.CustomAttributes.Any() && info.GetCustomAttribute<DisplayAttribute>() is DisplayAttribute nameAttr
            ? nameAttr.Name ?? enumValue.ToString()
            : enumValue.ToString();
    }

    public static string? Description(this Enum enumValue)
    {
        var enumType = enumValue.GetType();
        MemberInfo info = enumType.GetMember(enumValue.ToString()).First();

        return info is not null && info.CustomAttributes.Any() && info.GetCustomAttribute<DescriptionAttribute>() is DescriptionAttribute descrAttr
            ? descrAttr.Description
            : null;
    }

    public static Enum? GetEnumValueFromDisplayName<T>(this string displayName) where T : struct, Enum
    {
        foreach (var enumValue in Enum.GetValues<T>())
            if (enumValue.DisplayName() == displayName)
                return enumValue;
        return null;
    }
}
