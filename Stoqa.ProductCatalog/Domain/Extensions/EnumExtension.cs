using System.ComponentModel;

namespace Stoqa.ProductCatalog.Domain.Extensions;

public static class EnumExtension
{
    public static string GetDescription<T>(this T message) where T : Enum
    {
        var type = message.GetType();
        var memberInfo = type.GetMember(message.ToString());
        var attributes = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

        return ((DescriptionAttribute)attributes[0]).Description;
    }
}