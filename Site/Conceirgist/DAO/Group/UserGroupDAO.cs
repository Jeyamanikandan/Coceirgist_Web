using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for UserGroupDAO
/// </summary>
public class UserGroupDAO
{
	public UserGroupDAO()
	{
	}

    /// <summary>
    /// Create User Group
    /// </summary>
    /// <param name="ObjConn">SqlConnection</param>
    /// <param name="ObjSqlCommmand">SqlCommand</param>
    /// <param name="GroupID">GroupID</param>
    /// <param name="UserID">UserID</param>
    /// <param name="LastModifiedBy">LastModifiedBy</param>
    /// <returns></returns>
    public string CreateUserGroup(Conn ObjConn, SqlCommand ObjSqlCommmand, int GroupID,int UserID, string LastModifiedBy)
    {
        return ObjConn.executescalarstringquery(ObjSqlCommmand, "INSERT INTO [GroupsToUsers]([GroupID],[UserID],[Created],[LastModifiedBy])"
                                               + " VALUES (" + GroupID + "," + UserID + ",'" +  DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "','"
                                               + LastModifiedBy + "')" + " Select @@IDENTITY");
    }

    /// <summary>
    /// Delete User Group
    /// </summary>
    /// <param name="ObjConn">SqlConnection</param>
    /// <param name="ObjSqlCommmand">SqlCommand</param>
    /// <param name="GroupID">GroupID</param>
    /// <param name="UserID">UserID</param>
    /// <returns></returns>
    public string DeleteUserGroup(Conn ObjConn, SqlCommand ObjSqlCommmand, int GroupID,int UserID)
    {
        return ObjConn.executescalarstringquery(ObjSqlCommmand, "DELETE from [GroupsToUsers] output deleted.GroupID where [GroupID] = " + GroupID.ToString() + " and [UserID] = " + UserID.ToString());
    }

    /// <summary>
    /// Delete User Group
    /// </summary>
    /// <param name="ObjConn">SqlConnection</param>
    /// <param name="ObjSqlCommmand">SqlCommand</param>
    /// <param name="GroupID">GroupID</param>
    /// <returns></returns>
    public string DeleteUserGroup(Conn ObjConn, SqlCommand ObjSqlCommmand, int GroupID)
    {
        return ObjConn.executescalarstringquery(ObjSqlCommmand, "DELETE from [GroupsToUsers] output deleted.GroupID where [GroupID] = " + GroupID.ToString());
    }

    /// <summary>
    /// Selecct User Group based on GroupID
    /// </summary>
    /// <param name="ObjConn">SqlConnection</param>
    /// <param name="ObjSqlCommmand">SqlCommand</param>
    /// <param name="GroupID">GroupID</param>
    /// <returns></returns>
    public DataTable SelecctUserGroup(Conn ObjConn, SqlCommand ObjSqlCommmand, int GroupID)
    {
        return ObjConn.executeSelectQuery(ObjSqlCommmand, "SELECT * from [GroupsToUsers] where [GroupID] = " + GroupID.ToString());
    }

    /// <summary>
    /// Is User Group Exists
    /// </summary>
    /// <param name="ObjConn">SqlConnection</param>
    /// <param name="ObjSqlCommmand">SqlCommand</param>
    /// <param name="GroupID">GroupID</param>
    /// <param name="UserID">UserID</param>
    /// <returns></returns>
    public bool IsUserGroupExists(Conn ObjConn, SqlCommand ObjSqlCommmand, int GroupID, int UserID)
    {
        int i = ObjConn.executeselectcountquery(ObjSqlCommmand, "select count(1) from [GroupsToUsers] where [GroupID] = " + GroupID.ToString() + " and [UserID] = " + UserID.ToString());
        if (i > 0)
            return true;
        else
            return false;

    }
}