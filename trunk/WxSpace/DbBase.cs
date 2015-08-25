using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Configuration;

namespace WxSpace
{
    /// <summary>
    /// 数据访问的一个基类
    /// </summary>
    public class DbBase
    {
        #region 成员定义
        /// <summary>
        /// 默认的连接字符串，从webconfig获取
        /// </summary>
        private static string _ConnStr = ConfigurationManager.AppSettings["dataSource"] + System.Web.HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["lang_zh_cn"].ToString());

        /// <summary>
        /// 提取webconfig里的数据库类型
        /// </summary>
        private static string _StaticDataType = ConfigurationManager.AppSettings["DataType"].ToString(); //Access
        /// <summary>
        /// 数据库的类型，默认是Access
        /// </summary>
        private string _DataType = _StaticDataType;

        /// <summary>
        /// 出现异常时，记录出错信息，包括访问的网页，SQL语句，错误原因，访问时间等。
        /// </summary>
        protected string _ErrorMsg;

        /// <summary>
        /// 获取执行SQL语句后影响的行数。
        /// </summary>
        protected int _ExecuteRowCount;

        /// <summary>
        /// 标记是否已经启用了ado.net 事务
        /// </summary>
        public bool isUserTrans;

        #endregion

        #region 属性


        #endregion
    }
}
