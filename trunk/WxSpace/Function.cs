using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Web;
using System.Text.RegularExpressions;

namespace WxSpace
{
    /// <summary>
    /// 公共方法
    /// </summary>
    public class Function
    {
        public Function()
        {

        }

        public static string BackSpaces(int NumSpaces)
        {
            string Spaces = "";
            for (int i = 0; i < NumSpaces; i++)
            {
                Spaces += "&nbsp;&nbsp;&nbsp;";
            }
            Spaces += "<font color=red>├</font>&nbsp;";
            return Spaces;
        }

        public static string BackHtmlDecodeSpace(int NumSpaces)
        {
            string Spaces = "";
            for (int i = 0; i < NumSpaces; i++)
            {
                Spaces += System.Web.HttpContext.Current.Server.HtmlDecode("&nbsp;&nbsp;&nbsp;");
            }
            Spaces += "├" + System.Web.HttpContext.Current.Server.HtmlDecode("&nbsp;");
            return Spaces;
        }


        #region ///无限级分类
        /// <summary>
        /// 处理无限级数据源
        /// </summary>
        /// <param name="ClassTable">数据表名</param>
        /// <param name="ParentidColumnsName">父系列列名</param>
        /// <param name="ClassIdColumnsName">系列编号列名</param>
        /// <param name="OrderIdColumnsName">系列排序列名</param>
        /// <param name="ChildColumnsName">系列级别列名</param>
        /// <returns></returns>
        public static DataTable UnlimitedClassSource(string ClassTable ,string ParentidColumnsName,string ClassIdColumnsName,string OrderIdColumnsName)
        {
            DataSet ds = SqlHelper.Query("select * from [" + ClassTable + "] order by " + OrderIdColumnsName + "");
            DataRow[] drSource = ds.Tables[0].Select(ParentidColumnsName + "=0");
            DataTable dtSource = new DataTable();
            dtSource = ds.Tables[0].Clone();
            if (drSource == null)
                return dtSource;
            for (int i = 0; i < drSource.Length; i++)
            {
                dtSource.ImportRow((DataRow)drSource[i]);
                UnlimitedClassSource(ds,dtSource, ParentidColumnsName, ClassIdColumnsName, Convert.ToInt16(drSource[i][ClassIdColumnsName]));
            }
            ds.Dispose();
            return dtSource;
        }

        /// <summary>
        /// 返回该系列下子系列的ID号(包括本系列号)
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="dtSource"></param>
        /// <param name="ParentidColumnsName"></param>
        /// <param name="ClassIdColumnsName"></param>
        /// <param name="ClassId"></param>
        /// <returns></returns>
        static DataTable UnlimitedClassSource(DataSet ds,DataTable dtSource, string ParentidColumnsName,string ClassIdColumnsName, int ClassId)
        {
            DataRow[] drSource = ds.Tables[0].Select(ParentidColumnsName + "=" + ClassId);
            if (drSource == null)
                return dtSource;
            for (int i = 0; i < drSource.Length; i++)
            {
                dtSource.ImportRow((DataRow)drSource[i]);
                UnlimitedClassSource(ds, dtSource, ParentidColumnsName, ClassIdColumnsName, Convert.ToInt16(drSource[i][ClassIdColumnsName]));
            }
            return dtSource;
        }

        /// <summary>
        /// 子系列ID列表
        /// </summary>
        /// <param name="ClassId">系列ID</param>
        /// <param name="TableName">表名</param>
        /// <param name="ClassIdColumnsName">系列ID列名</param>
        /// <param name="IdList"></param>
        /// <returns></returns>
        public static string SubSeriesIdList(int ClassId, string TableName, string ParentIdColumnsName, string ClassIdColumnsName)
        {
            string IdList = ClassId.ToString() + ",";
            DataSet ds = SqlHelper.Query("select * from " + TableName + "");
            DataRow[] dr = ds.Tables[0].Select("" + ParentIdColumnsName + "=" + ClassId + "");
            for (int i = 0; i < dr.Length; i++)
            {
                IdList = IdList + dr[i][ClassIdColumnsName] + ",";
                IdList = SubSeriesIdList(ds, Convert.ToInt16(dr[i][ClassIdColumnsName]), TableName, ParentIdColumnsName, ClassIdColumnsName, IdList);
            }
            return IdList;
        }

        static string SubSeriesIdList(DataSet ds, int ClassId, string TableName, string ParentIdColumnsName, string ClassIdColumnsName,string IdList)
        {
            DataRow[] dr = ds.Tables[0].Select("" + ParentIdColumnsName + "=" + ClassId + "");
            for (int i = 0; i < dr.Length; i++)
            {
                IdList = IdList + dr[i][ClassIdColumnsName] + ",";
                IdList = SubSeriesIdList(ds, Convert.ToInt16(dr[i][ClassIdColumnsName]), TableName, ParentIdColumnsName, ClassIdColumnsName, IdList);
            }
            return IdList;
        }
        ///无限结束
        #endregion 

        /// <summary>
        /// 去除HTML代码
        /// </summary>
        /// <param name="Htmlstring"></param>
        /// <returns></returns>
        public static string NoHtml(string Htmlstring)
        {
            Htmlstring = Regex.Replace(Htmlstring, @"<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"<(.[^>]*)>", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"([\r\n])[\s]+", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"-->", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"<!--.*", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(quot|#34);", "\"", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(amp|#38);", "&", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(lt|#60);", "<", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(gt|#62);", ">", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(nbsp|#160);", " ", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(iexcl|#161);", "\xa1", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(cent|#162);", "\xa2", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(pound|#163);", "\xa3", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(copy|#169);", "\xa9", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&#(\d+);", "", RegexOptions.IgnoreCase);
            Htmlstring.Replace("<", "");
            Htmlstring.Replace(">", "");
            Htmlstring.Replace("\r\n", "");
            Htmlstring = HttpContext.Current.Server.HtmlEncode(Htmlstring).Trim();
            return Htmlstring;
        }
        /// <summary>
        /// 截取字符数
        /// </summary>
        /// <param name="content"></param>
        /// <param name="cutNum"></param>
        /// <returns></returns>
        public static string CutStr(string content, int cutNum)
        {
            if (content.Length > cutNum)
                return content.Substring(0, cutNum);
            else
                return content;
        }
    }
}
