using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DigestAuthCalc
{
  public static class EnumHelper
  {
    /// <summary>
    /// Gets an attribute on an enum field value
    /// </summary>
    /// <typeparam name="T">The type of the attribute you want to retrieve</typeparam>
    /// <param name="enumVal">The enum value</param>
    /// <returns>The attribute of type T that exists on the enum value</returns>
    public static T GetAttributeOfType<T>(this Enum enumVal) where T : System.Attribute
    {
      var type = enumVal.GetType();
      var memInfo = type.GetMember(enumVal.ToString());
      var attributes = memInfo[0].GetCustomAttributes(typeof(T), false);
      return (attributes.Length > 0) ? (T)attributes[0] : null;
    }

    public static IEnumerable<string> GetAttributeNamesOfType(Type attributeType, Type enumType)
    {
      foreach (var enumVal in Enum.GetValues(enumType))
      {
        var memInfo = enumType.GetMember(enumVal.ToString());
        var attributes = memInfo[0].GetCustomAttributes(attributeType, false);
        yield return (attributes.Length > 0) ? ((dynamic)Convert.ChangeType(attributes[0], attributeType)).Name : null;
      }
    }
    public static T GetValueByAttributeNameOfType<T, A>(string attributeName) where T : notnull, Enum where A : System.Attribute
    {
      var enumType = typeof(T);
      var attributeType = typeof(A);
      foreach (var enumVal in Enum.GetValues(enumType))
      {
        var memInfo = enumType.GetMember(enumVal.ToString());
        var attributes = memInfo[0].GetCustomAttributes(attributeType, false);
        if ((attributes.Length > 0) && ((dynamic)Convert.ChangeType(attributes[0], attributeType)).Name == attributeName)
          return (T)enumVal;
      }
      return default(T);
    }
  }
}
