using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using ZSQL.Common;

namespace ZSQL.DBAccess
{
    /// <summary>
    /// 数据库操作类（静态类）
    /// </summary>
    public static class DB
    {
        /// <summary>
        /// 插入操作
        /// </summary>
        /// <param name="model"></param>
        /// <param name="schema"></param>
        /// <returns></returns>
        public static DBExecutionResult Insert(Object model, string schema)
        {
            Type mType = model.GetType();
            string tableName = string.Empty;
            //定义了ZTableAttribute，则直接取tablename属性为表名
            ZTableAttribute tabAttr = (ZTableAttribute)Attribute.GetCustomAttribute(Assembly.GetAssembly(mType), typeof(ZTableAttribute));
            if (tabAttr != null)
            {
                tableName = tabAttr.TableName;
            }

            else
            {
                //如果没有定义，直接在类型中获取类名作为表名
                string fullName = mType.Name;
                int dhIndex = fullName.LastIndexOf(".");
                tableName = fullName.Substring(dhIndex + 1);
            }
            //获取实体属性集合
            var props = mType.GetProperties();
            //遍历属性集合
            int pCount = props.Length;
            StringBuilder sbSql = new StringBuilder("insert into " + tableName.ToLower() + " (");//初始化insert sql语句
            StringBuilder sbColumns = new StringBuilder();//列名
            StringBuilder sbValues = new StringBuilder(" values(");//列值
            for (int i = 0; i < pCount; i++)
            {
                IgnoreAttribute ig = Attribute.GetCustomAttribute(props[i], typeof(IgnoreAttribute)) as IgnoreAttribute;
                //如果设置了忽略特性，就忽略该列
                if (ig != null)
                    continue;
                //获取列名和列值
                //Type cType = .GetType();
                string cName = props[i].Name;
                object cValue = props[i].GetValue(model, null);
                sbColumns.AppendFormat("{0},", cName.ToLower());
                sbValues.AppendFormat("'{0}',", cValue.ToString().ToLower());


            }
            sbColumns = sbColumns.ToString().TrimEnd(',').ToStringBuilder();
            sbValues = sbValues.ToString().TrimEnd(',').ToStringBuilder().Append(")");
            sbSql.Append(sbColumns.ToString()).Append(")");
            sbSql.Append(sbValues.ToString());
            return new DBExecutionResult { SQLString = sbSql.ToString(), IsSuccess = true };
        }
    }
}
