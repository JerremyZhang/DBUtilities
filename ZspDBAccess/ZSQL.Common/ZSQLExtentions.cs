using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZSQL.Common
{
    /// <summary>
    /// ZSQL扩展方法
    /// </summary>
    public static class ZSQLExtentions
    {
        /// <summary>
        /// 转换string为StringBuilder
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static StringBuilder ToStringBuilder(this string str)
        {
            return new StringBuilder(str);
        }
    }
}
