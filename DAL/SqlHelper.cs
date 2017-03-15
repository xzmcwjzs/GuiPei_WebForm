using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Collections;

namespace DAL
{
   public class SqlHelper
    {
        private SqlConnection con;
        #region  打开连接
        /// <summary>
        /// 打开连接
        /// </summary>
        private void Open()
        {
            if (con == null) { con = new SqlConnection(ConfigurationManager.ConnectionStrings["strConn"].ConnectionString); }
            if (con.State == System.Data.ConnectionState.Closed) { con.Open(); }
        }
        #endregion

        #region   关闭连接
        /// <summary> 
        /// 关闭连接
        /// </summary>
        private void Close()
        {
            if (con != null) { con.Close(); }
        }
        #endregion

        #region   释放资源
        /// <summary>
        /// 释放资源
        /// </summary>
        public void Dispose()
        {
            if (con != null) { con.Dispose(); con = null; }
        }
        #endregion


        #region   传入参数并且转换为SqlParameter类型
        /// <summary>
        /// 转换参数
        /// </summary>
        /// <param name="ParamName">存储过程名称或命令文本</param>
        /// <param name="DbType">参数类型</param></param>
        /// <param name="Size">参数大小</param>
        /// <param name="Value">参数值</param>
        /// <returns>新的 parameter 对象</returns>
        public SqlParameter MakeInParam(string ParamName, SqlDbType DbType, int Size, object Value)
        {
            return MakeParam(ParamName, DbType, Size, ParameterDirection.Input, Value);
        }
        /// <summary>
        /// 初始化参数值
        /// </summary>
        /// <param name="ParamName">存储过程名称或命令文本</param>
        /// <param name="DbType">参数类型</param>
        /// <param name="Size">参数大小</param>
        /// <param name="Direction">参数方向</param>
        /// <param name="Value">参数值</param>
        /// <returns>新的 parameter 对象</returns>
        public SqlParameter MakeParam(string ParamName, SqlDbType DbType, Int32 Size, ParameterDirection Direction, object Value)
        {
            SqlParameter param;

            if (Size > 0)
                param = new SqlParameter(ParamName, DbType, Size);
            else
                param = new SqlParameter(ParamName, DbType);
            param.Direction = Direction;
            if (!(Direction == ParameterDirection.Output && Value == null))
                param.Value = Value;
            return param;
        }
        #endregion

        #region   执行参数命令文本(无数据库中数据返回)
        /// <summary>
        /// 执行命令
        /// </summary>
        /// <param name="procName">命令文本</param>
        /// <param name="prams">参数对象</param>
        /// <returns></returns>
        public int RunExecuteNonQuery(string procName, SqlParameter[] prams)
        {
            int count = 0;
            SqlCommand cmd = CreateCommand(procName, prams);
            count = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            this.Close();
            //得到执行成功返回值
            return count;
        }
        /// <summary>
        /// 直接执行SQL语句
        /// </summary>
        /// <param name="procName">命令文本</param>
        /// <returns></returns>
        public int RunExecuteNonQuery(string procName)
        {
            int count = 0;
            this.Open();
            SqlCommand cmd = new SqlCommand(procName, con);
            count = cmd.ExecuteNonQuery();

            this.Close();
            return count;
        }

        #endregion


        #region ExecuteReader 2种方法
        /// <summary>
        /// 返回datareader对象
        /// </summary>
        /// <param name="procName"></param>
        /// <param name="prams"></param>
        /// <returns></returns>
        public SqlDataReader RunDataReader(string procName, SqlParameter[] prams)
        {
            try
            {
                SqlCommand cmd = CreateCommand(procName, prams);

                SqlDataReader dr = cmd.ExecuteReader();
                cmd.Parameters.Clear();
                return dr;
            }
            catch (Exception)
            {
                this.Close();
                throw;
            }



        }
        public SqlDataReader RunDataReader(string procName)
        {
            try
            {
                this.Open();
                SqlCommand cmd = new SqlCommand(procName, con);
                SqlDataReader dr = cmd.ExecuteReader();

                return dr;
            }
            catch (Exception)
            {
                this.Close();
                throw;
            }


        }


        #endregion

        #region ExecuteScalar 2种方法 object
        /// <summary>
        /// 执行ExecuteScalar
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="cmdType"></param>
        /// <param name="cmdText"></param>
        /// <param name="cmdParms"></param>
        /// <returns></returns>
        public object RunExecuteScalar(string procName, SqlParameter[] prams)
        {

            this.Open();
            SqlCommand cmd = CreateCommand(procName, prams);
            object val = cmd.ExecuteScalar();
            cmd.Parameters.Clear();
            this.Close();
            return val;
        }

        public object RunExecuteScalar(string procName)
        {

            Open();
            SqlCommand cmd = new SqlCommand(procName, con);
            object val = cmd.ExecuteScalar();
            this.Close();
            return val;
        }
        #endregion

        #region  ExcuteDataSet 2种方法
        /// <summary>
        /// 执行查询命令文本，并且返回DataSet数据集
        /// </summary>
        /// <param name="procName">命令文本</param>
        /// <param name="prams">参数对象</param>
        /// <param name="tbName">数据表名称</param>
        /// <returns></returns>
        public DataSet RunDataSet(string procName, SqlParameter[] prams, string tbName)
        {
            SqlDataAdapter dap = CreateDataAdaper(procName, prams);
            DataSet ds = new DataSet();
            dap.Fill(ds, tbName);

            this.Close();
            //得到执行成功返回值
            return ds;
        }

        /// <summary>
        /// 执行命令文本，并且返回DataSet数据集
        /// </summary>
        /// <param name="procName">命令文本</param>
        /// <param name="tbName">数据表名称</param>
        /// <returns>DataSet</returns>
        public DataSet RunDataSet(string procName, string tbName)
        {
            SqlDataAdapter dap = CreateDataAdaper(procName, null);
            DataSet ds = new DataSet();
            dap.Fill(ds, tbName);
            this.Close();
            //得到执行成功返回值
            return ds;
        }

        #endregion


        #region ExecuteDataTable 2种方法
        /// <summary>
        /// 
        /// </summary>
        /// <param name="procName"></param>
        /// <returns></returns>
        public DataTable RunDataTable(string procName)
        {

            DataTable dt = new DataTable();
            Open();
            SqlDataAdapter dap = CreateDataAdaper(procName, null);
            dap.Fill(dt);
            this.Close();
            return dt;

        }
        public DataTable RunDataTable(string procName, SqlParameter[] prams)
        {

            DataTable dt = new DataTable();
            Open();
            SqlDataAdapter dap = CreateDataAdaper(procName, prams);
            dap.Fill(dt);

            this.Close();
            return dt;

        }
        #endregion

        #region 将命令文本添加到SqlDataAdapter
        /// <summary>
        /// 创建一个SqlDataAdapter对象以此来执行命令文本
        /// </summary>
        /// <param name="procName">命令文本</param>
        /// <param name="prams">参数对象</param>
        /// <returns></returns>
        private SqlDataAdapter CreateDataAdaper(string procName, SqlParameter[] prams)
        {
            this.Open();
            SqlDataAdapter dap = new SqlDataAdapter(procName, con);
            dap.SelectCommand.CommandType = CommandType.Text;  //执行类型：命令文本
            if (prams != null)
            {
                foreach (SqlParameter parameter in prams)
                    dap.SelectCommand.Parameters.Add(parameter);
            }
            //加入返回参数
            dap.SelectCommand.Parameters.Add(new SqlParameter("ReturnValue", SqlDbType.Int, 4,
                ParameterDirection.ReturnValue, false, 0, 0,
                string.Empty, DataRowVersion.Default, null));

            return dap;
        }
        #endregion

        #region   将命令文本添加到SqlCommand
        /// <summary>
        /// 创建一个SqlCommand对象以此来执行命令文本
        /// </summary>
        /// <param name="procName">命令文本</param>
        /// <param name="prams"命令文本所需参数</param>
        /// <returns>返回SqlCommand对象</returns>
        private SqlCommand CreateCommand(string procName, SqlParameter[] prams)
        {
            // 确认打开连接
            this.Open();
            SqlCommand cmd = new SqlCommand(procName, con);
            cmd.CommandType = CommandType.Text;　　　　 //执行类型：命令文本

            // 依次把参数传入命令文本
            if (prams != null)
            {
                foreach (SqlParameter parameter in prams)
                    cmd.Parameters.Add(parameter);
            }
            // 加入返回参数
            cmd.Parameters.Add(
                new SqlParameter("ReturnValue", SqlDbType.Int, 4,
                ParameterDirection.ReturnValue, false, 0, 0,
                string.Empty, DataRowVersion.Default, null));

            return cmd;
        }
        #endregion

        #region 东软代码生成器可做，用于insert、update、delete（ExecuteSql）
        /// <summary>
        /// 用于insert、update、delete
        /// </summary>
        /// <param name="SQLString"></param>
        /// <param name="cmdParms"></param>
        /// <returns></returns>
        public  int ExecuteSql(string SQLString, params SqlParameter[] cmdParms)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["strConn"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    try
                    {
                        PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                        int rows = cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                        return rows;
                    }
                    catch (System.Data.SqlClient.SqlException e)
                    {
                        throw e;
                    }
                }
            }
        }
        
        private static void PrepareCommand(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, string cmdText, SqlParameter[] cmdParms)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            if (trans != null)
                cmd.Transaction = trans;
            cmd.CommandType = CommandType.Text;//cmdType;
            if (cmdParms != null)
            {


                foreach (SqlParameter parameter in cmdParms)
                {
                    if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) &&
                        (parameter.Value == null))
                    {
                        parameter.Value = DBNull.Value;
                    }
                    cmd.Parameters.Add(parameter);
                }
            }
        }
        #endregion

        #region 由Object取值
        /// <summary>
        /// 取得Int值,如果为Null 则返回０
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static int GetInt(object obj)
        {
            if (obj.ToString() != "")
                return int.Parse(obj.ToString());
            else
                return 0;
        }

        /// <summary>
        /// 取得byte值
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static byte Getbyte(object obj)
        {
            if (obj.ToString() != "")
                return byte.Parse(obj.ToString());
            else
                return 0;
        }

        /// <summary>
        /// 获得Long值
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static long GetLong(object obj)
        {
            if (obj.ToString() != "")
                return long.Parse(obj.ToString());
            else
                return 0;
        }

        /// <summary>
        /// 取得Decimal值
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static decimal GetDecimal(object obj)
        {
            if (obj.ToString() != "")
                return decimal.Parse(obj.ToString());
            else
                return 0;
        }

        /// <summary>
        /// 取得Guid值
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static Guid GetGuid(object obj)
        {
            if (obj.ToString() != "")
                return new Guid(obj.ToString());
            else
                return Guid.Empty;
        }

        /// <summary>
        /// 取得DateTime值
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static DateTime GetDateTime(object obj)
        {
            if (obj.ToString() != "")
                return DateTime.Parse(obj.ToString());
            else
                return DateTime.MinValue;
        }

        /// <summary>
        /// 取得bool值
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool GetBool(object obj)
        {
            if (obj.ToString() == "1" || obj.ToString().ToLower() == "true")
                return true;
            else
                return false;
        }

        /// <summary>
        /// 取得byte[]
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static Byte[] GetByte(object obj)
        {
            if (obj.ToString() != "")
            {
                return (Byte[])obj;
            }
            else
                return null;
        }

        /// <summary>
        /// 取得string值
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string GetString(object obj)
        {
            if (obj != null && obj != DBNull.Value)
                return obj.ToString();
            else
                return "";
        }
        #endregion

        #region 执行分页存储过程，并返回总行数和总页数
        /// <summary>
        /// 执行分页存储过程，并返回总行数和总页数
        /// </summary>
        /// <param name="proName">存储过程名</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">页容量</param>
        /// <param name="rowCount">总行数</param>
        /// <param name="pageCount">总页数</param>
        /// <returns></returns>
        public DataTable RunPagedDataPro(string proName, string SelectList, string tablename, string where, string OrderExpression, string CountId, int pageIndex, int pageSize, out int rowCount, out int pageCount)
        {

            Open();
            rowCount = 0;
            pageCount = 0;
            SqlParameter[] prams = { 
                                   new SqlParameter("@SelectList",SelectList),
                                   new SqlParameter("@TableSource",tablename),
                                   new SqlParameter("@SearchCondition",where),
                                   new SqlParameter("@OrderExpression",OrderExpression),
                                   new SqlParameter("@CountId",CountId),
                                   new SqlParameter("@PageIndex",pageIndex),
                                   new SqlParameter("@PageSize",pageSize),
                                   new SqlParameter("@RowCount",rowCount),
                                   new SqlParameter("@PageCount",pageCount)
                                   };
            //必须为连个存储过程输出参数 设置方向为 输出
            prams[7].Direction = ParameterDirection.Output;
            prams[8].Direction = ParameterDirection.Output;
            SqlDataAdapter dap = CreateDataAdaper(proName, prams);
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;//设值使用存储过程
            DataTable dt = new DataTable();
            dap.Fill(dt);
            this.Close();
            //接收 存储过程的输出参数
            rowCount = Convert.ToInt16(prams[7].Value);
            pageCount = Convert.ToInt16(prams[8].Value);
            return dt;

        }
        #endregion

        #region 分页存储过程

        #region  sql 2000 分页存储过程
        /*
     * 
     * CREATE  PROCEDURE [dbo].[ProcCustomPage]
		(
		    @Table_Name               varchar(5000),      	    --表名
		    @Sign_Record              varchar(50),       		--主键
		    @Filter_Condition         varchar(1000),     	    --筛选条件,不带where
		    @Page_Size                int,               		--页大小
		    @Page_Index               int,          			--页索引     			
	        @TaxisField               varchar(1000),            --排序字段
		    @Taxis_Sign               int,               		--排序方式 1为 DESC, 0为 ASC
            @Find_RecordList          varchar(1000),        	--查找的字段
		    @Record_Count             int                		--总记录数
		 )
		 AS
			BEGIN 
			DECLARE  @Start_Number          int
			DECLARE  @End_Number            int
			DECLARE  @TopN_Number           int
		 DECLARE  @sSQL                  varchar(8000)
                 if(@Find_RecordList='')
                 BEGIN
                      SELECT @Find_RecordList='*'
                 END
		 SELECT @Start_Number =(@Page_Index-1) * @Page_Size
			IF @Start_Number<=0
		 SElECT @Start_Number=0
			SELECT @End_Number=@Start_Number+@Page_Size
			IF @End_Number>@Record_Count
		 SELECT @End_Number=@Record_Count
		 SELECT @TopN_Number=@End_Number-@Start_Number
		 IF @TopN_Number<=0
		 SELECT @TopN_Number=0
			print @TopN_Number
		 print @Start_Number
		 print @End_Number
		 print @Record_Count
                 IF @TaxisField=''
                 begin
                    select  @TaxisField=@Sign_Record
                 end
		 IF @Taxis_Sign=0
		  	BEGIN
		 		IF @Filter_Condition=''
				 BEGIN
		 			SELECT @sSQL='SELECT '+@Find_RecordList+' FROM '+@Table_Name+' 
		     			WHERE '+@Sign_Record+' in (SELECT TOP '+CAST(@TopN_Number AS VARCHAR(10))+' '+@Sign_Record+' FROM '+@Table_Name+' 
		    			 WHERE '+@Sign_Record+' in (SELECT TOP '+CAST(@End_Number AS VARCHAR(10))+' '+@Sign_Record+' FROM '+@Table_Name+' 
		    		 ORDER BY '+@TaxisField+') order by '+@TaxisField+' DESC)order by '+@TaxisField
		 		END
				ELSE
				BEGIN
				SELECT @sSQL='SELECT '+@Find_RecordList+' FROM '+@Table_Name+' 
		     WHERE '+@Sign_Record+' in (SELECT TOP '+CAST(@TopN_Number AS VARCHAR(10))+' '+@Sign_Record+' FROM '+@Table_Name+' 
		     WHERE '+@Sign_Record+' in (SELECT TOP '+CAST(@End_Number AS VARCHAR(10))+' '+@Sign_Record+' FROM '+@Table_Name+' 
		     WHERE '+@Filter_Condition+' ORDER BY '+@TaxisField+') and '+@Filter_Condition+' order by '+@TaxisField+' DESC) and '+@Filter_Condition+' order by '+@TaxisField
				 END
			END
		ELSE
			BEGIN
			IF @Filter_Condition=''
				BEGIN
					SELECT @sSQL='SELECT '+@Find_RecordList+' FROM '+@Table_Name+' 
		         WHERE '+@Sign_Record+' in (SELECT TOP '+CAST(@TopN_Number AS VARCHAR(10))+' '+@Sign_Record+' FROM '+@Table_Name+' 
		         WHERE '+@Sign_Record+' in (SELECT TOP '+CAST(@End_Number AS VARCHAR(10))+' '+@Sign_Record+' FROM '+@Table_Name+' 
		         ORDER BY '+@TaxisField+' DESC) order by '+@TaxisField+')order by '+@TaxisField+' DESC'
		     END
			ELSE
			BEGIN
				SELECT @sSQL='SELECT '+@Find_RecordList+' FROM '+@Table_Name+' 
		     WHERE '+@Sign_Record+' in (SELECT TOP '+CAST(@TopN_Number AS VARCHAR(10))+' '+@Sign_Record+' FROM '+@Table_Name+' 
		     WHERE '+@Sign_Record+' in (SELECT TOP '+CAST(@End_Number AS VARCHAR(10))+' '+@Sign_Record+' FROM '+@Table_Name+' 
		     WHERE '+@Filter_Condition+' ORDER BY '+@TaxisField+' DESC) and '+@Filter_Condition+' order by '+@TaxisField+') and '+@Filter_Condition+' order by '+@TaxisField+' DESC'
		 END
			END
			EXEC (@sSQL)
			IF @@ERROR<>0
			RETURN -3              
		 RETURN 0
		 END
		 
		 PRINT  @sSQL
        GO

     * */


        #endregion

        #region SQL2005 分页存储过程
        /*
     * 
   CREATE PROCEDURE [dbo].[GetRecordFromPage] 
    @SelectList            VARCHAR(2000),    --欲选择字段列表
    @TableSource        VARCHAR(100),    --表名或视图表 
    @SearchCondition    VARCHAR(2000),    --查询条件
    @OrderExpression    VARCHAR(1000),    --排序表达式
    @PageIndex            INT = 1,        --页号,从0开始
    @PageSize            INT = 10        --页尺寸
AS 
BEGIN
    IF @SelectList IS NULL OR LTRIM(RTRIM(@SelectList)) = ''
    BEGIN
        SET @SelectList = '*'
    END
    PRINT @SelectList
    
    SET @SearchCondition = ISNULL(@SearchCondition,'')
    SET @SearchCondition = LTRIM(RTRIM(@SearchCondition))
    IF @SearchCondition <> ''
    BEGIN
        IF UPPER(SUBSTRING(@SearchCondition,1,5)) <> 'WHERE'
        BEGIN
            SET @SearchCondition = 'WHERE ' + @SearchCondition
        END
    END
    PRINT @SearchCondition

    SET @OrderExpression = ISNULL(@OrderExpression,'')
    SET @OrderExpression = LTRIM(RTRIM(@OrderExpression))
    IF @OrderExpression <> ''
    BEGIN
        IF UPPER(SUBSTRING(@OrderExpression,1,5)) <> 'WHERE'
        BEGIN
            SET @OrderExpression = 'ORDER BY ' + @OrderExpression
        END
    END
    PRINT @OrderExpression

    IF @PageIndex IS NULL OR @PageIndex < 1
    BEGIN
        SET @PageIndex = 1
    END
    PRINT @PageIndex
    IF @PageSize IS NULL OR @PageSize < 1
    BEGIN
        SET @PageSize = 10
    END
    PRINT  @PageSize

    DECLARE @SqlQuery VARCHAR(4000)

    SET @SqlQuery='SELECT '+@SelectList+',RowNumber 
    FROM 
        (SELECT ' + @SelectList + ',ROW_NUMBER() OVER( '+ @OrderExpression +') AS RowNumber 
          FROM '+@TableSource+' '+ @SearchCondition +') AS RowNumberTableSource 
    WHERE RowNumber BETWEEN ' + CAST(((@PageIndex - 1)* @PageSize+1) AS VARCHAR) 
    + ' AND ' + 
    CAST((@PageIndex * @PageSize) AS VARCHAR) 
--    ORDER BY ' + @OrderExpression
    PRINT @SqlQuery
    SET NOCOUNT ON
    EXECUTE(@SqlQuery)
    SET NOCOUNT OFF
 
    RETURN @@RowCount
END
     **/

        #endregion

        #region 分页存储过程最终版
        /*
  
ALTER PROCEDURE [dbo].[GetPageList]
	-- Add the parameters for the stored procedure here
	 @SelectList            nVARCHAR(2000),    --欲选择字段列表
    @TableSource        nVARCHAR(100),    --表名或视图表 
    @SearchCondition    nVARCHAR(2000),    --查询条件
    @OrderExpression    nVARCHAR(1000),    --排序表达式
    @PageIndex            INT = 1,        --页号,从0开始
    @PageSize            INT = 15 ,       --页尺寸
    @CountId          varchar(100),       --用于输出总行数的标识
    @RowCount                 int output,    --总行数
    @PageCount              int output         --总页数
AS 
   declare @RowCountSql nvarchar(4000) 
BEGIN
     
     --declare @RowNum float
     set @RowCountSql='select @RowCount=COUNT(['+@CountId+']),@PageCountSql=CEILING((count('+@CountId+')+0.0)/'+
     cast(@PageSize as varchar)+') from '+@TableSource
     if LEN(@SearchCondition)>1
		set @RowCountSql=@RowCountSql+' where '+@SearchCondition
	--if LEN(@OrderExpression)>1
		--set @RowCountSql=@RowCountSql+'ORDER BY ' + @OrderExpression
		
	exec sp_executesql @RowCountSql,N'@RowCount float output,@PageCountSql int output',@RowCount output,@PageCount output
end
begin    
    --execute sp_executesql @RowCountSql,N'@RowNum float output',@RowNum output
   -- set @RowCount=@RowNum
    
    --SELECT @RowCount=COUNT (*) from GP_Training_Base
    --select @PageCount=CEILING(@RowCount/@PageSize)
    
    IF @SelectList IS NULL OR LTRIM(RTRIM(@SelectList)) = ''
    BEGIN
        SET @SelectList = '*'
    END
    PRINT @SelectList
    
    SET @SearchCondition = ISNULL(@SearchCondition,'')
    SET @SearchCondition = LTRIM(RTRIM(@SearchCondition))
    IF @SearchCondition <> ''
    BEGIN
        IF UPPER(SUBSTRING(@SearchCondition,1,5)) <> 'WHERE'
        BEGIN
            SET @SearchCondition = 'WHERE ' + @SearchCondition
        END
    END
    PRINT @SearchCondition

    SET @OrderExpression = ISNULL(@OrderExpression,'')
    SET @OrderExpression = LTRIM(RTRIM(@OrderExpression))
    IF @OrderExpression <> ''
    BEGIN
        IF UPPER(SUBSTRING(@OrderExpression,1,5)) <> 'WHERE'
        BEGIN
            SET @OrderExpression = 'ORDER BY ' + @OrderExpression
        END
    END
    PRINT @OrderExpression

    IF @PageIndex IS NULL OR @PageIndex < 1
    BEGIN
        SET @PageIndex = 1
    END
    PRINT @PageIndex
    IF @PageSize IS NULL OR @PageSize < 1
    BEGIN
        SET @PageSize = 10
    END
    PRINT  @PageSize

    DECLARE @SqlQuery VARCHAR(4000)

    SET @SqlQuery='SELECT '+@SelectList+',RowNumber 
    FROM 
        (SELECT ' + @SelectList + ',ROW_NUMBER() OVER( '+ @OrderExpression +') AS RowNumber 
          FROM '+@TableSource+' '+ @SearchCondition +') AS RowNumberTableSource 
    WHERE RowNumber BETWEEN ' + CAST(((@PageIndex - 1)* @PageSize+1) AS VARCHAR) 
    + ' AND ' + 
    CAST((@PageIndex * @PageSize) AS VARCHAR) 
--    ORDER BY ' + @OrderExpressio
    PRINT @SqlQuery
    SET NOCOUNT ON
    EXECUTE(@SqlQuery)
    SET NOCOUNT OFF
 
    RETURN @@RowCount
    
    
   
END

*/


        #endregion

        #endregion

        #region  执行一些互相联系需要一次成功的sql语句，使用事务操作


        //执行一些互相联系需要一次成功的sql语句，使用事务操作
        public static bool ExecuteStoreProcedure(String[] SqlStrings, SqlParameter[][] cmdParms)
        {
            bool success = true;
            SqlCommand cmd = new SqlCommand();
            int i = 0;
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["strConn"].ConnectionString))
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction(); /*开始事务*/
                cmd.Connection = conn;
                cmd.Transaction = trans;
                try
                {
                    foreach (String sqlstr in SqlStrings)
                    {
                        cmd.CommandText = sqlstr;
                        if (cmdParms != null)
                        {
                            foreach (SqlParameter parm in cmdParms[i])
                                cmd.Parameters.Add(parm);
                        }
                        cmd.ExecuteNonQuery();
                        i++;
                    }
                    cmd.Parameters.Clear();
                    trans.Commit();
                }
                catch
                {
                    success = false;
                    trans.Rollback();
                }
                finally
                {
                    conn.Close();
                }
            }
            return success;
        }

        #endregion


        #region 执行多条SQL语句，实现数据库事务。static int ExecuteSqlTran(List<String> SQLStringList)
        /// <summary>
        /// 执行多条SQL语句，实现数据库事务。
        /// </summary>
        /// <param name="SQLStringList">多条SQL语句</param>		
        public int ExecuteSqlTran(List<String> SQLStringList)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["strConn"].ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                SqlTransaction tx = conn.BeginTransaction();
                cmd.Transaction = tx;
                try
                {
                    int count = 0;
                    for (int n = 0; n < SQLStringList.Count; n++)
                    {
                        string strsql = SQLStringList[n];
                        if (strsql.Trim().Length > 1)
                        {
                            cmd.CommandText = strsql;
                            count += cmd.ExecuteNonQuery();
                        }
                    }
                    tx.Commit();
                    return count;
                }
                catch
                {
                    tx.Rollback();
                    return 0;
                }
            }
        } 
        #endregion


        #region 事务Hash
        /// 执行多条SQL语句，实现数据库事务。
        /// </summary>
        /// <param name="SQLStringList">SQL语句的哈希表（key为sql语句，value是该语句的SqlParameter[]）</param>
        public static void ExecuteSqlTran(Hashtable SQLStringList)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["strConn"].ConnectionString))
            {
                conn.Open();//打开数据库连接
                using (SqlTransaction trans = conn.BeginTransaction())//开始数据库事务
                {
                    SqlCommand cmd = new SqlCommand();//创建SqlCommand命令
                    try
                    {
                        //循环
                        foreach (DictionaryEntry myDE in SQLStringList)//循环哈希表（本例中 即，循环执行添加在哈希表中的sql语句
                        {
                            string cmdText = myDE.Key.ToString();//获取键值（本例中 即，sql语句）
                            SqlParameter[] cmdParms = (SqlParameter[])myDE.Value;//获取键值（本例中 即，sql语句对应的参数）
                            prepareCommand(cmd, conn, trans, cmdText, cmdParms); //调用PrepareCommand()函数，添加参数
                            int val = cmd.ExecuteNonQuery();//调用增删改函数ExcuteNoQuery()，执行哈希表中添加的sql语句
                            cmd.Parameters.Clear(); //清除参数
                        }
                        trans.Commit();//提交事务
                    }
                    catch //捕获异常
                    {
                        trans.Rollback(); //事务回滚
                        throw; //抛出异常
                    }
                }
            }
        }
        //添加参数
        private static void prepareCommand(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, string cmdText, SqlParameter[] cmdParms)
        {
            if (conn.State != ConnectionState.Open)//如果数据库连接为关闭状态
                conn.Open();//打开数据库连接
            cmd.Connection = conn;//设置命令连接
            cmd.CommandText = cmdText;//设置执行命令的sql语句
            if (trans != null)//如果事务不为空
                cmd.Transaction = trans;//设置执行命令的事务
            cmd.CommandType = CommandType.Text;//设置解释sql语句的类型为“文本”类型（也是就说该函数不适用于存储过程）
            if (cmdParms != null)//如果参数数组不为空
            {
                foreach (SqlParameter parameter in cmdParms) //循环传入的参数数组
                {
                    if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) &&
                        (parameter.Value == null))
                    {
                        parameter.Value = DBNull.Value; //获取参数的值
                    }
                    cmd.Parameters.Add(parameter);//添加参数
                }
            }
        }
        
        #endregion


    }
}

