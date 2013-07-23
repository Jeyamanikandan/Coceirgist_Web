using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;

public class Conn
{
    SqlDataAdapter _dataAdap = null;
    SqlConnection _connection = null;
    SqlCommand ObjCommand = null;

    public Conn()
    {
        _dataAdap = new SqlDataAdapter();
        _connection = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);
    }

    /// <summary>
    /// Open DB Conncetion
    /// </summary>
    /// <returns>SqlConnection</returns>
    public SqlConnection ConnectionOpen()
    {
        if (_connection.State == ConnectionState.Broken || _connection.State == ConnectionState.Closed)
        {
            _connection.Open();
        }
        return _connection;
    }

    /// <summary>
    /// Close Database Connection
    /// </summary>
    /// <returns>SqlConnection</returns>
    public SqlConnection ConnectionClose()
    {
        if (_connection.State == ConnectionState.Broken || _connection.State == ConnectionState.Open)
        {
            _connection.Close();
        }
        return _connection;
    }

    /// <summary>
    /// Execute Select Query
    /// </summary>
    /// <param name="query">Query</param>
    /// <param name="sqlparams">Parameters</param>
    /// <returns></returns>
    public DataTable executeSelectQuery(SqlCommand ObjCommand,string query, SqlParameter[] sqlparams)
    {
        DataTable _datatable = new DataTable();
        DataSet _dataset = new DataSet();
        _datatable = null;
        try
        {
            //ObjCommand.Connection = ConnectionOpen();
            ObjCommand.CommandText = query;
            ObjCommand.Parameters.AddRange(sqlparams);
            ObjCommand.ExecuteNonQuery();
            _dataAdap.SelectCommand = ObjCommand;
            _dataAdap.Fill(_dataset);
            _datatable = _dataset.Tables[0];
        }
        catch (SqlException ex)
        {
        }
        ObjCommand.Connection = ConnectionClose();
        return _datatable;
    }

    /// <summary>
    /// Execute Select Query
    /// </summary>
    /// <param name="query">Query</param>
    /// <returns></returns>
    public string executeselectstringquery(SqlCommand ObjCommand, string query)
    {
        string status = string.Empty;
        try
        {
            //ObjCommand.Connection = ConnectionOpen();
            ObjCommand.CommandText = query;
            SqlDataReader dr = ObjCommand.ExecuteReader();
            while (dr.Read())
            {
                status = dr["status"].ToString();
            }
        }
        catch (SqlException ex)
        {
        }
        ObjCommand.Connection = ConnectionClose();
        return status;
    }

    /// <summary>
    /// Execute Select Query
    /// </summary>
    /// <param name="query"></param>
    /// <returns></returns>
    public DataTable executeSelectQuery(SqlCommand ObjCommand, string query)
    {
        ObjCommand = new SqlCommand();
        DataTable _datatable = new DataTable();
        DataSet _dataset = new DataSet();
        _datatable = null;
        try
        {
            //ObjCommand.Connection = ConnectionOpen();
            ObjCommand.CommandText = query;
            //ObjCommand.Parameters.AddRange(sqlparams);
            ObjCommand.ExecuteNonQuery();
            _dataAdap.SelectCommand = ObjCommand;
            _dataAdap.Fill(_dataset);
            _datatable = _dataset.Tables[0];
        }
        catch (SqlException ex)
        {

        }
        ObjCommand.Connection = ConnectionClose();
        return _datatable;
    }

    public DataSet executeSelectQueryfull(SqlCommand ObjCommand, string query)
    {
        ObjCommand = new SqlCommand();
        DataTable _datatable = new DataTable();
        DataSet _dataset = new DataSet();
        _datatable = null;
        try
        {
            //ObjCommand.Connection = ConnectionOpen();
            ObjCommand.CommandText = query;
            ObjCommand.ExecuteNonQuery();
            _dataAdap.SelectCommand = ObjCommand;
            _dataAdap.Fill(_dataset);

        }
        catch (SqlException ex)
        {

        }
        ObjCommand.Connection = ConnectionClose();
        return _dataset;
    }
    public int executeselectcountquery(SqlCommand ObjCommand, string query)
    {
        ObjCommand = new SqlCommand();
        int count = 0;
        try
        {
            //ObjCommand.Connection = ConnectionOpen();
            ObjCommand.CommandText = query;
            _dataAdap.SelectCommand = ObjCommand;            
            count = Convert.ToInt32(ObjCommand.ExecuteScalar());

        }
        catch (SqlException ex)
        {

        }
        ObjCommand.Connection = ConnectionClose();
        return count;
    }

    /// <summary>
    /// Execute insert Query
    /// </summary>
    /// <param name="ObjCommand">SqlCommand</param>
    /// <param name="query">query</param>
    /// <param name="sqlparams">sqlparams</param>
    /// <returns>True/False</returns>
    public bool executeInsertQuery(SqlCommand ObjCommand, string query, SqlParameter[] sqlparams)
    {
        ObjCommand = new SqlCommand();
        _dataAdap = new SqlDataAdapter();
        try
        {
            //ObjCommand.Connection = ConnectionOpen();
            ObjCommand.CommandText = query;
            ObjCommand.Parameters.AddRange(sqlparams);
            _dataAdap.InsertCommand = ObjCommand;
            ObjCommand.ExecuteNonQuery();
        }
        catch (SqlException ex)
        {
        }
        ObjCommand.Connection = ConnectionClose();
        return true;
    }

    /// <summary>
    /// Execute Update Query
    /// </summary>
    /// <param name="ObjCommand">SqlCommand</param>
    /// <param name="query">query</param>
    /// <param name="sqlparams">sqlparams</param>
    /// <returns>True/False</returns>
    public bool executeUpdateQuery(SqlCommand ObjCommand, string query, SqlParameter[] sqlparams)
    {
        ObjCommand = new SqlCommand();
        _dataAdap = new SqlDataAdapter();
        try
        {
            //ObjCommand.Connection = ConnectionOpen();
            ObjCommand.CommandText = query;
            ObjCommand.Parameters.AddRange(sqlparams);
            _dataAdap.UpdateCommand = ObjCommand;
            ObjCommand.ExecuteNonQuery();
        }
        catch (SqlException ex)
        {
        }
        ObjCommand.Connection = ConnectionClose();
        return true;
    }

    public bool executeDeleteQuery(SqlCommand ObjCommand, string query, SqlParameter[] sqlparams)
    {
        ObjCommand = new SqlCommand();
        _dataAdap = new SqlDataAdapter();
        try
        {
            //ObjCommand.Connection = ConnectionOpen();
            ObjCommand.CommandText = query;
            ObjCommand.Parameters.AddRange(sqlparams);
            _dataAdap.DeleteCommand = ObjCommand;
            ObjCommand.ExecuteNonQuery();
        }
        catch (SqlException ex)
        {
        }
        ObjCommand.Connection = ConnectionClose();
        return true;
    }
    public bool executeDeleteQueryfull(SqlCommand ObjCommand, string query)
    {
        ObjCommand = new SqlCommand();
        _dataAdap = new SqlDataAdapter();
        try
        {
            //ObjCommand.Connection = ConnectionOpen();
            ObjCommand.CommandText = query;
            _dataAdap.DeleteCommand = ObjCommand;
            ObjCommand.ExecuteNonQuery();
        }
        catch (SqlException ex)
        {
        }
        ObjCommand.Connection = ConnectionClose();
        return true;
    }
    string pass;
    public string executescalarstringquery(SqlCommand ObjCommand, string query, SqlParameter[] param)
    {

        ObjCommand = new SqlCommand();
        try
        {
            //ObjCommand.Connection = ConnectionOpen();
            ObjCommand.CommandText = query;
            ObjCommand.Parameters.AddRange(param);
            //ObjCommand.Parameters = param;
            pass = ObjCommand.ExecuteScalar().ToString();

        }
        catch (SqlException ex)
        {

        }
        ObjCommand.Connection = ConnectionClose();
        return pass;
    }
    public string executescalarstringquery(SqlCommand ObjCommand, string query)
    {
        ObjCommand = new SqlCommand();
        try
        {
            //ObjCommand.Connection = ConnectionOpen();
            ObjCommand.CommandText = query;
            //ObjCommand.Parameters = param;
            object obj = ObjCommand.ExecuteScalar();
            if (obj != null)
                pass = obj.ToString();
        }
        catch (SqlException ex)
        {

        }
        ObjCommand.Connection = ConnectionClose();
        return pass;
    }
    public DataSet executeSelectQueryfull(SqlCommand ObjCommand, string query, SqlParameter[] param)
    {
        ObjCommand = new SqlCommand();
        ObjCommand.Parameters.AddRange(param);
        DataTable _datatable = new DataTable();
        DataSet _dataset = new DataSet();
        _datatable = null;
        try
        {
            ObjCommand.Connection = ConnectionOpen();
            ObjCommand.CommandText = query;
            ObjCommand.ExecuteNonQuery();
            _dataAdap.SelectCommand = ObjCommand;
            _dataAdap.Fill(_dataset);

        }
        catch (SqlException ex)
        {

        }
        ObjCommand.Connection = ConnectionClose();
        return _dataset;
    }

}

