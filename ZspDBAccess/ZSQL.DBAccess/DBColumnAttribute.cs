using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZSQL.DBAccess
{
    /// <summary>
    /// 列特性
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class ZColumnAttribute : Attribute
    {
        /// <summary>
        /// 列名
        /// </summary>
        public string ColumnName { get; set; }
        public ZColumnAttribute(string columnName)
        {
            this.ColumnName = columnName;
        }
    }
    /// <summary>
    /// table特性
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class ZTableAttribute : Attribute
    {
        /// <summary>
        /// 表名
        /// </summary>
        public string TableName { get; set; }
        public ZTableAttribute(string tableName)
        {
            this.TableName = tableName;
        }
    }
}
