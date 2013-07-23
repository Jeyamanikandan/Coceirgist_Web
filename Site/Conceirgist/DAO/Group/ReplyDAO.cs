using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for ReplyDAO
/// </summary>
public class ReplyDAO
{
	public ReplyDAO()
	{		
    }

    /// <summary>
    /// Create Reply
    /// </summary>
    /// <param name="ObjConn">SqlConnection</param>
    /// <param name="ObjSqlCommmand">SqlCommand</param>
    /// <param name="GroupID">GroupID</param>
    /// <param name="UserID">UserID</param>
    /// <param name="ReplyName">ReplyName</param>
    /// <param name="ReplyDesc">ReplyDesc</param>
    /// <param name="ReplyType">ReplyType</param>
    /// <returns></returns>
    public string CreateReply(Conn ObjConn, SqlCommand ObjSqlCommmand, int GroupID, int UserID, string ReplyName, string ReplyDesc, string ReplyType)
    {
        return ObjConn.executescalarstringquery(ObjSqlCommmand, "INSERT INTO [Reply]([GroupID],[UserID],[ReplyName],[ReplyDesc],[ReplyType])"
                                               + " VALUES (" + GroupID.ToString() + "," + UserID.ToString() + ",'" + ReplyName + "','" + ReplyDesc + "','"
                                               + ReplyType + "')" + " Select @@IDENTITY");
    }

    /// <summary>
    /// Select Reply based on ReplyID
    /// </summary>
    /// <param name="ObjConn">SqlConnection</param>
    /// <param name="ObjSqlCommmand">SqlCommand</param>
    /// <param name="ReplyID">ReplyID</param>
    /// <returns></returns>
    public DataTable SelectReply(Conn ObjConn, SqlCommand ObjSqlCommmand, int ReplyID)
    {
        return ObjConn.executeSelectQuery(ObjSqlCommmand, "SELECT * from [Reply] where [ReplyID] = " + ReplyID.ToString());
    }


    /// <summary>
    /// Select Reply based on GroupID and UserID
    /// </summary>
    /// <param name="ObjConn">SqlConnection</param>
    /// <param name="ObjSqlCommmand">SqlCommand</param>
    /// <param name="GroupID">GroupID</param>
    /// <param name="UserID">UserID</param>
    /// <returns></returns>
    public DataTable SelectReply(Conn ObjConn, SqlCommand ObjSqlCommmand, int GroupID, int UserID)
    {
        return ObjConn.executeSelectQuery(ObjSqlCommmand, "SELECT * from [Reply] where [GroupID] = " + GroupID.ToString() + " and [UserID] = " + UserID.ToString());
    }
}