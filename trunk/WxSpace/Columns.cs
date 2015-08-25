using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;

namespace WxSpace
{
    /// <summary>
    /// 网站后台导航
    /// </summary>
    public class Columns
    {
        #region Columns 变量
        private int _Manage_Id;
        public int Manage_Id
        {
            get { return _Manage_Id; }
            set { _Manage_Id = value; }
        }

        private string _Manage_Name;
        public string Manage_Name
        {
            get { return _Manage_Name; }
            set { _Manage_Name = value; }
        }

        private string _Manage_Url;
        public string Manage_Url
        {
            get { return _Manage_Url; }
            set { _Manage_Url = value; }
        }

        private string _Manage_Target;
        public string Manage_Target
        {
            get { return _Manage_Target; }
            set { _Manage_Target = value; }
        }

        private string _Manage_CollapseImage;
        public string Manage_CollapseImage
        {
            get { return _Manage_CollapseImage; }
            set { _Manage_CollapseImage = value; }
        }

        private string _Manage_OpenImage;
        public string Manage_OpenImage
        {
            get { return _Manage_OpenImage; }
            set { _Manage_OpenImage = value; }
        }

        private bool _Manage_Show;
        public bool Manage_Show
        {
            get { return _Manage_Show; }
            set { _Manage_Show = value; }
        }

        private int _Manage_ParentId;
        public int Manage_ParentId
        {
            get { return _Manage_ParentId; }
            set { _Manage_ParentId = value; }
        }

        private int _Manage_OrderId;
        public int Manage_OrderId
        {
            get { return _Manage_OrderId; }
            set { _Manage_OrderId = value; }
        }

        private int _Manage_Child;
        public int Manage_Child
        {
            get { return _Manage_Child; }
            set { _Manage_Child = value; }
        }

        #endregion

        #region IInsert 成员
        /// <summary>
        /// 添加栏目 返回是否添加成功
        /// 初始化字段名
        /// Manage_ParentId      父目录ID
        /// Manage_Name          栏目名称
        /// Manage_Target        Target
        /// Manage_Url           Url地址
        /// Manage_CollapseImage 折叠图片
        /// Manage_OpenImage     打开图片
        /// Manage_Show          是否显示
        /// </summary>
        /// <returns></returns>
        public int AddData()
        {
            this._Manage_Id = 1;
            ///获取系列最大ID+1
            object obj = SqlHelper.GetSingle("select max(Manage_Id) from ManageList");
            if (obj != null)
                this._Manage_Id = Convert.ToInt16(obj) + 1;

            ///获取同一级别的排序号
            this._Manage_OrderId = 1;
            obj = SqlHelper.GetSingle("select max(Manage_OrderId)+1 from ManageList where Manage_ParentId=" + _Manage_ParentId + "");
            if (obj != null)
                this._Manage_OrderId = Convert.ToInt16(obj);

            ///设置该系列级别
            if (_Manage_ParentId == 0)
                _Manage_Child = 0;
            else
            {
                obj = SqlHelper.GetSingle("select Manage_Child+1 from ManageList where Manage_Id=" + _Manage_ParentId + "");
                _Manage_Child = Convert.ToInt16(obj);
            }

            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into ManageList(Manage_Id,Manage_Name,Manage_Url,Manage_Target,Manage_CollapseImage,");
            strSql.Append("Manage_OpenImage,Manage_Show,Manage_ParentId,Manage_OrderId,Manage_Child)");
            strSql.Append(" values(@Id,@Name,@Url,@Target,@CollapseImage,@OpenImage,@Show,@ParentId,@OrderId,@Child)");
            OleDbParameter[] par ={new OleDbParameter("@Id",OleDbType.Integer,8),
                                     new OleDbParameter("@Name",OleDbType.VarChar,50),
                                     new OleDbParameter("@Url",OleDbType.VarChar,50),
                                     new OleDbParameter("@Target",OleDbType.VarChar,50),
                                     new OleDbParameter("@CollapseImage",OleDbType.VarChar,50),
                                     new OleDbParameter("@OpenImage",OleDbType.VarChar,50),
                                     new OleDbParameter("@Show",OleDbType.Boolean,1),
                                     new OleDbParameter("@ParentId",OleDbType.Integer,8),
                                     new OleDbParameter("@OrderId",OleDbType.Integer,8),
                                     new OleDbParameter("@Child",OleDbType.Integer,8)};
            par[0].Value = _Manage_Id;
            par[1].Value = _Manage_Name;
            par[2].Value = _Manage_Url;
            par[3].Value = _Manage_Target;
            par[4].Value = _Manage_CollapseImage;
            par[5].Value = _Manage_OpenImage;
            par[6].Value = _Manage_Show;
            par[7].Value = _Manage_ParentId;
            par[8].Value = _Manage_OrderId;
            par[9].Value = _Manage_Child;

            try
            {
                SqlHelper.ExecuteSql(strSql.ToString(), par);
            }
            catch
            {
                throw new NotImplementedException();
            }
            return 1;
        }

        #endregion

        #region IUpdate 成员

        public int ModifiedData()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IDelete 成员

        public static void RemoveData(int dataId)
        {
            StringBuilder idList = new StringBuilder();
            idList.Append(Function.SubSeriesIdList(dataId, "ManageList", "Manage_ParentId", "Manage_Id"));
            idList.Append("0");
            SqlHelper.ExecuteSql("delete from ManageList where Manage_Id in (" + idList.ToString() + ")");
        }

        #endregion

        #region IView 成员

        public static DataTable ViewData(int dataId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from ManageList where Manage_Id=");
            strSql.Append(dataId);
            DataTable dt = SqlHelper.Query(strSql.ToString()).Tables[0];
            return dt;
        }

        #endregion

        #region Columns 返回数据源

        /// <summary>
        /// GridView数据源
        /// </summary>
        /// <returns></returns>
        public static DataTable GridViewSource()
        {
            return Function.UnlimitedClassSource("ManageList", "Manage_ParentId", "Manage_Id", "Manage_OrderId");
        }

        /// <summary>
        /// 返回DropDownList数据源
        /// </summary>
        /// <returns></returns>
        public static DataTable DropDownListSource()
        {
            DataTable DtSource = new DataTable();
            DtSource.Columns.Add("Manage_Id", System.Type.GetType("System.Int32"));
            DtSource.Columns.Add("Manage_Name", System.Type.GetType("System.String"));
            DataTable Dt = new DataTable();
            Dt = Function.UnlimitedClassSource("ManageList", "Manage_ParentId", "Manage_Id", "Manage_OrderId");
            for (int i = 0; i < Dt.Rows.Count; i++)
            {
                DataRow dr = DtSource.NewRow();
                dr[0] = Dt.Rows[i]["Manage_Id"];
                dr[1] = Function.BackHtmlDecodeSpace(Convert.ToInt16(Dt.Rows[i]["Manage_Child"])) + Dt.Rows[i]["Manage_Name"];
                DtSource.Rows.Add(dr);
            }
            Dt.Dispose();
            return DtSource;
        }

        #endregion

        #region MoveUp MoveDown 移动系列
        /// <summary>
        /// 向上移动系列
        /// 
        /// </summary>
        /// <returns></returns>
        public int MoveUp()
        {
            OleDbConnection conn = new OleDbConnection(SqlHelper.connectionString);
            conn.Open();
            OleDbCommand cmd = new OleDbCommand("select * from ManageList where Manage_Id=" + _Manage_Id + "", conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                this._Manage_ParentId = Convert.ToInt16(reader["Manage_ParentId"]);
                this._Manage_OrderId = Convert.ToInt16(reader["Manage_OrderId"]);
            }
            else
            {
                reader.Dispose();
                reader.Close();
                cmd.Dispose();
                conn.Dispose();
                conn.Close();
                return 0;
            }
            cmd = new OleDbCommand("select * from ManageList where Manage_ParentId=" + _Manage_ParentId + " and Manage_OrderId < " + _Manage_OrderId + " order by Manage_OrderId desc", conn);
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                SqlHelper.ExecuteSql("update ManageList set Manage_OrderId=" + _Manage_OrderId + " where Manage_Id=" + reader["Manage_Id"] + "");
                SqlHelper.ExecuteSql("update ManageList set Manage_OrderId=" + reader["Manage_OrderId"] + " where Manage_Id=" + _Manage_Id + "");
                reader.Dispose();
                reader.Close();
                cmd.Dispose();
                conn.Dispose();
                conn.Close();
                return 1;
            }
            reader.Dispose();
            reader.Close();
            cmd.Dispose();
            conn.Dispose();
            conn.Close();
            return 2;
        }

        /// <summary>
        /// 向下移动系列
        /// </summary>
        /// <returns></returns>
        public int MoveDown()
        {
            OleDbConnection conn = new OleDbConnection(SqlHelper.connectionString);
            conn.Open();
            OleDbCommand cmd = new OleDbCommand("select * from ManageList where Manage_Id=" + _Manage_Id + "", conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                this._Manage_ParentId = Convert.ToInt16(reader["Manage_ParentId"]);
                this._Manage_OrderId = Convert.ToInt16(reader["Manage_OrderId"]);
            }
            else
            {
                reader.Dispose();
                reader.Close();
                cmd.Dispose();
                conn.Dispose();
                conn.Close();
                return 0;
            }
            cmd = new OleDbCommand("select * from ManageList where Manage_ParentId=" + _Manage_ParentId + " and Manage_OrderId > " + _Manage_OrderId + " order by Manage_OrderId asc", conn);
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                SqlHelper.ExecuteSql("update ManageList set Manage_OrderId=" + _Manage_OrderId + " where Manage_Id=" + reader["Manage_Id"] + "");
                SqlHelper.ExecuteSql("update ManageList set Manage_OrderId=" + reader["Manage_OrderId"] + " where Manage_Id=" + _Manage_Id + "");
                reader.Dispose();
                reader.Close();
                cmd.Dispose();
                conn.Dispose();
                conn.Close();
                return 1;
            }
            reader.Dispose();
            reader.Close();
            cmd.Dispose();
            conn.Dispose();
            conn.Close();
            return 2;
        }

        #endregion

    }
}
