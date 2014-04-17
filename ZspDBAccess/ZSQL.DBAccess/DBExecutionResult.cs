using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZSQL.DBAccess
{
    /// <summary>
    /// 数据库操作执行结果
    /// </summary>
    public class DBExecutionResult
    {
        /// <summary>
        /// 返回的sql语句
        /// </summary>
        public string SQLString { get; set; }
        /// <summary>
        /// 是否执行成功
        /// </summary>
        public Boolean IsSuccess { get; set; }
        //TODO:待扩展

    }
}
