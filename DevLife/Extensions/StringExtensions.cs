using System;

namespace DevLife.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Provides an easy way to cast a string to another type.
        /// <example>
        /// int settingsValue = AppSettings.MyIntValue.Cast&lt;int&gt;();
        /// </example>
        /// /// <example>
        /// int settingsValue = AppSettings.MyIntValue.Cast&lt;int&gt;(defaultValue: 10, throwIfException: false);
        /// </example>
        /// </summary>
        /// <typeparam name="T">The type to which the string will be converted</typeparam>
        /// <param name="value">The string value to be converted</param>
        /// <param name="defaultValue">
        /// Optional parameter that will be returned if the string cannot be converted to type T.
        /// This value will only be returned if 'throwIfException' is false
        /// </param>
        /// <param name="throwIfException">Determines if an exception will be thrown if the conversion fails</param>
        /// <returns></returns>
        public static T Cast<T>(this string value, T defaultValue = default(T), bool throwIfException = true)
        {
            Exception exception;

            if (string.IsNullOrWhiteSpace(value))
                return defaultValue;

            try
            {
                Type type = typeof(T);
                Type nullableType = Nullable.GetUnderlyingType(type);
                if (nullableType != null)
                {
                    return (T)Convert.ChangeType(value, nullableType);
                }

                return (T)Convert.ChangeType(value, type);
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            if (exception != null && throwIfException)
                throw exception;

            return defaultValue;
        }

        /// <summary>
        /// Returns an ellipsed string if 'value' is greater than 'limit'.
        /// <example>
        /// string ellipsed = "my really really really long string".Ellipsed(limit: 15);
        /// Assert.AreEqual("my really reall...", ellipsed);
        /// </example>
        /// </summary>
        /// <param name="value">The string to be ellipsed</param>
        /// <param name="limit">
        /// Optional parameter determining the non-inclusive length of 'value' before it will be ellipsed
        /// </param>
        /// <returns></returns>
        public static string Ellipsed(this string value, int limit = 50)
        {
            return value != null && value.Length > limit ? value.Substring(0, limit) + "..." : value;
        }

        /// <summary>
        /// Replaces one string 'value' with another string 'ifEmpty' if 'value' is null or white space.
        /// <example>
        /// string result = "".ReplaceWithIfEmpty(ifEmpty: "I am not empty");
        /// Assert.AreEqual("I am not empty", result);
        /// </example>
        /// </summary>
        /// <param name="value"></param>
        /// <param name="ifEmpty"></param>
        /// <returns></returns>
        public static string ReplaceWithIfEmpty(this string value, string ifEmpty)
        {
            return !string.IsNullOrWhiteSpace(value) ? value : ifEmpty;
        }
    }
}