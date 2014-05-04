using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using ContentModel1._5.Common;

namespace ContentModel1._5.CommonModel
{
    public class SqlHelper
    {
        private static SqlConnection sqlCon = null;
        protected static SqlConnection GetInstance()
        {
            if (sqlCon != null)
            {
                return sqlCon;
            }
            else
            {
                return new SqlConnection(ConfigurationManager.AppSettings["TestDBConnectionString"]);
            }
        }
        /// <summary>
        /// 插入字段
        /// </summary>
        /// <param name="TableName"></param>
        /// <param name="FieldName"></param>
        /// <param name="Type"></param>
        /// <returns></returns>
        public static ReturnType InsertField(string TableName, string FieldName, string SqlType)
        {
            SqlConnection con = GetInstance();
            string sql = string.Format("alter table App_{0} add {1} {2} null", TableName, FieldName, SqlType);
            SqlCommand com = new SqlCommand(sql, con);
            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                com.ExecuteNonQuery();
                con.Close();
                return ReturnType.Succuss;
            }
            catch (Exception ex)
            {
                con.Close();
                throw ex;
            }
        }
        /// <summary>
        /// 插入表字段
        /// </summary>
        /// <param name="MasterTableName"></param>
        /// <param name="MasterFieldName"></param>
        /// <param name="DetailTableName"></param>
        /// <param name="DetailFieldName"></param>
        /// <returns></returns>
        public static ReturnType InsertField(string MasterTableName, string MasterFieldName, string DetailTableName, string DetailFieldName)
        {
            SqlConnection con = GetInstance();
            string sql1 = string.Format("ALTER TABLE App_{0} ADD {1} nVarChar(200) null", DetailTableName, DetailFieldName);
            string sql2 = string.Format("ALTER TABLE App_{0} ADD FOREIGN KEY ({1}) REFERENCES App_{3}({2})", DetailTableName, DetailFieldName, MasterFieldName, MasterTableName);
            SqlCommand com1 = new SqlCommand(sql1, con);
            SqlCommand com2 = new SqlCommand(sql2, con);
            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                com1.ExecuteNonQuery();
                com2.ExecuteNonQuery();
                con.Close();
                return ReturnType.Succuss;
            }
            catch (Exception ex)
            {
                con.Close();
                throw ex;
            }
        }
        /// <summary>
        /// 修改已有表中的字段
        /// </summary>
        /// <param name="TableName"></param>
        /// <param name="FieldName"></param>
        /// <param name="Type"></param>
        /// <returns></returns>
        public static ReturnType UpdateField(string TableName, string FieldName, string Type)
        {
            return ReturnType.Succuss;
        }
        /// <summary>
        /// 删除已有表中的字段
        /// </summary>
        /// <param name="TableName"></param>
        /// <param name="FieldName"></param>
        /// <returns></returns>
        public static ReturnType DropField(string TableName, string FieldName)
        {
            SqlConnection con = GetInstance();

            string sql = string.Format(" alter table App_{0} drop column {1}", TableName, FieldName);
            SqlCommand com = new SqlCommand(sql, con);
            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                com.ExecuteNonQuery();
                con.Close();
                return ReturnType.Succuss;
            }
            catch (Exception)
            {
                con.Close();
                return ReturnType.Error;
            }
        }

        /// <summary>
        /// 插入新表
        /// </summary>
        /// <param name="TableName"></param>
        /// <returns></returns>
        public static ReturnType InsertModel(string TableName)
        {
            SqlConnection con = GetInstance();
            string sql = string.Format("create table App_{0}({1}ID int IDENTITY(1,1) PRIMARY KEY,{2}Code nVarChar(100) null,)", TableName, TableName, TableName);
            SqlCommand com = new SqlCommand(sql, con);
            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                com.ExecuteNonQuery();
                con.Close();
                return ReturnType.Succuss;
            }
            catch (Exception ex)
            {
                HttpContext.Current.Response.Write(ex.Message);
                con.Close();
                return ReturnType.Error;
            }
        }
        /// <summary>
        /// 删除表
        /// </summary>
        /// <param name="TableName"></param>
        /// <returns></returns>
        public static ReturnType DropModel(string TableName)
        {

            SqlConnection con = GetInstance();
            string sql = string.Format("drop table App_{0}", TableName);
            SqlCommand com = new SqlCommand(sql, con);
            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                com.ExecuteNonQuery();
                con.Close();
                return ReturnType.Succuss;
            }
            catch (Exception)
            {
                con.Close();
                return ReturnType.Error;
            }
        }

        /// <summary>
        /// 向ModuleField表中插入记录
        /// </summary>
        /// <param name="TableName"></param>
        /// <returns></returns>
        public static ReturnType InsertRecord(string sql)
        {
            SqlConnection con = GetInstance();
            SqlCommand com = new SqlCommand(sql, con);
            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                com.ExecuteNonQuery();
                con.Close();
                return ReturnType.Succuss;
            }
            catch (Exception)
            {
                con.Close();
                return ReturnType.Error;
            }
        }

        /// <summary>
        /// 向ModuleField表中更新记录
        /// </summary>
        /// <param name="TableName"></param>
        /// <returns></returns>
        public static ReturnType UpDateRecord(string sql)
        {
            SqlConnection con = GetInstance();
            SqlCommand com = new SqlCommand(sql, con);
            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                com.ExecuteNonQuery();
                con.Close();
                return ReturnType.Succuss;
            }
            catch (Exception)
            {
                con.Close();
                return ReturnType.Error;
            }
        }
        
        /// <summary>
        /// 添加表关联关系
        /// </summary>
        /// <param name="mastertablecode"></param>
        /// <param name="mastertablename"></param>
        /// <param name="detailtablecode"></param>
        /// <param name="detailtablename"></param>
        /// <returns></returns>
        public static ReturnType InsertTableRelation(string mastertablecode, string mastertablename, string detailtablecode, string detailtablename)
        {
            SqlConnection con = GetInstance();
            string sql = "INSERT INTO Base_TableRelation (MasterTableCode,MasterTableName,DetailTableCode,DetailTableName) VALUES ('" + mastertablecode + "','" + mastertablename + "','" + detailtablecode + "','" + detailtablename + "')";
            SqlCommand com = new SqlCommand(sql, con);
            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                com.ExecuteNonQuery();
                con.Close();
                return ReturnType.Succuss;
            }
            catch (Exception)
            {
                con.Close();
                return ReturnType.Error;
            }
        }
        
        /// <summary>
        /// 添加字段关联关系
        /// </summary>
        /// <param name="mastertablecode"></param>
        /// <param name="mastertablename"></param>
        /// <param name="masterfieldcode"></param>
        /// <param name="masterfieldname"></param>
        /// <param name="detailtablecode"></param>
        /// <param name="detailtablename"></param>
        /// <param name="detailfieldcode"></param>
        /// <param name="detailfieldname"></param>
        /// <returns></returns>
        public static ReturnType InsertTableFieldRelation(string mastertablecode, string mastertablename, string masterfieldcode, string masterfieldname, string detailtablecode, string detailtablename, string detailfieldcode, string detailfieldname)
        {
            SqlConnection con = GetInstance();
            string sql = "INSERT INTO Base_TableFieldRelation (MasterTableCode,MasterTableName,MasterFieldCode,MasterFieldName,DetailTableCode,DetailTableName,DetailFieldCode,DetailFieldName) VALUES ('" + mastertablecode + "','" + mastertablename + "','" + masterfieldcode + "','" + masterfieldname + "','" + detailtablecode + "','" + detailtablename + "','" + detailfieldcode + "','" + detailfieldname + "')";
            SqlCommand com = new SqlCommand(sql, con);
            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                com.ExecuteNonQuery();
                con.Close();
                return ReturnType.Succuss;
            }
            catch (Exception)
            {
                con.Close();
                return ReturnType.Error;
            }
        }
        
        public static DataSet GetDataByTableName(string TableName)
        {
            SqlConnection con = GetInstance();
            string sql = string.Format("select * from {0}",TableName);
            DataSet retDataSet = new DataSet();
            SqlDataAdapter ada = new SqlDataAdapter(sql, con);
            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                ada.Fill(retDataSet, TableName);
                con.Close();
                return retDataSet;
            }
            catch (Exception)
            {
                con.Close();
                return null;
 
            }
        }

        /// <summary>
        /// 根据sql语句获取指定table的记录
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public static DataSet GetDataBySQL(string sql,string tableName)
        {
            SqlConnection con = GetInstance();            
            DataSet retDataSet = new DataSet();
            SqlDataAdapter ada = new SqlDataAdapter(sql, con);
            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                ada.Fill(retDataSet, tableName);
                con.Close();
                return retDataSet;
            }
            catch (Exception)
            {
                con.Close();
                return null;

            }
        }
    }
}