using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace TianCheng.Model
{
    /// <summary>
    /// String -> DateTime?
    /// </summary>
    public class StringToDateTimeNullConverter : ITypeConverter<string, DateTime?>
    {
        /// <summary>
        ///  ObjectId -> String
        /// </summary>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public DateTime? Convert(string source, DateTime? destination, ResolutionContext context)
        {
            if (String.IsNullOrWhiteSpace(source))
            {
                return null;
            }
            DateTime dt;
            if (DateTime.TryParse(source, out dt))
            {
                return dt;
            }
            return null;
        }
    }
    /// <summary>
    /// DateTime? -> String
    /// </summary>
    public class DateTimeNullToStringConverter : ITypeConverter<DateTime?, string>
    {
        /// <summary>
        ///  DateTime? -> String
        /// </summary>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public string Convert(DateTime? source, string destination, ResolutionContext context)
        {
            if (source == null || source.Value == DateTime.MinValue || source.Value == DateTime.MaxValue)
            {
                return "";
            }

            return source.Value.ToString("yyyy-MM-dd HH:mm:ss");
        }
    }
}
