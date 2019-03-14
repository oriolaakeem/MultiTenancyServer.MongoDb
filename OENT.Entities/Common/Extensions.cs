using System;
using System.Collections.Generic;
using System.Text;

namespace OENT.Entities.Common
{
    public static class Extensions
    {
        public static T ParseEnum<T>(this string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }
    }
}
