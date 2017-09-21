using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;


namespace TianCheng.Model
{
    /// <summary>
    /// String -> DateTime?
    /// </summary>
    public class StringToDateTimeConverter : ITypeConverter<string, DateTime>
    {
        /// <summary>
        ///  ObjectId -> String
        /// </summary>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public DateTime Convert(string source, DateTime destination, ResolutionContext context)
        {
            if (String.IsNullOrWhiteSpace(source))
            {
                return DateTime.MinValue;
            }
            DateTime dt;
            if (DateTime.TryParse(source, out dt))
            {
                return dt;
            }
            return DateTime.MinValue;
        }
    }
    /// <summary>
    /// DateTime? -> String
    /// </summary>
    public class DateTimeToStringConverter : ITypeConverter<DateTime, string>
    {
        /// <summary>
        ///  DateTime? -> String
        /// </summary>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public string Convert(DateTime source, string destination, ResolutionContext context)
        {
            if (source == null || source == DateTime.MinValue || source == DateTime.MaxValue)
            {
                return "";
            }

            return source.ToString("yyyy-MM-dd HH:mm:ss");
        }
    }
}
