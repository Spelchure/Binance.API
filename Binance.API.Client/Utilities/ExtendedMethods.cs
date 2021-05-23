using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using System.ComponentModel;
using System.Reflection;

namespace Binance.API.Client.Utilities
{
    /// <summary>
    /// Extensions for some methods.
    /// </summary>
    public static class ExtendedMethods
    {
        /// <summary>
        /// Checks string is valid json.
        /// </summary>
        /// <param name="stringValue">String to check</param>
        /// <returns>True if valid json.</returns>
        public static bool IsValidJson(this string stringValue)
        {
            if (string.IsNullOrWhiteSpace(stringValue))
            {
                return false;
            }

            var value = stringValue.Trim();

            if((value.StartsWith("{") && value.EndsWith("}")) || 
                (value.StartsWith("[") && value.EndsWith("]")))
            {
                try
                {
                    var obj = JToken.Parse(value);
                    return true;
                } catch (JsonReaderException)
                {
                    return false;
                }
            }

            return false;
        }

        /// <summary>
        /// Extended method to get a enum description
        /// </summary>
        /// <param name="value">Enum to get description from</param>
        /// <returns>Value description</returns>
        public static string GetEnumDescription(this Enum value)
        {
            return ((DescriptionAttribute)Attribute.GetCustomAttribute(
                value.GetType().GetFields(BindingFlags.Public | BindingFlags.Static)
                    .Single(x => x.GetValue(null).Equals(value)),
                typeof(DescriptionAttribute)))?.Description ?? value.ToString();
        }
   
        /// <summary>
        /// Gets unix timestamp in milliseconds
        /// </summary>
        /// <param name="dateTime">Datetime enum</param>
        /// <returns>Timestamp</returns>
        public static string GetUnixTimestamp(this DateTime dateTime)
        {
            var datetimeOffset = new DateTimeOffset(dateTime);
            return datetimeOffset.ToUnixTimeMilliseconds().ToString();
        }
    }
}
