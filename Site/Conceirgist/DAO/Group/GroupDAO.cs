using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for GroupDAO
/// </summary>
public class GroupDAO
{
	public GroupDAO()
	{		
	}

    /// <summary>
    /// Create Group
    /// </summary>
    /// <param name="ObjConn">SqlConnection</param>
    /// <param name="ObjSqlCommmand">SqlCommand</param>
    /// <param name="GroupName">GroupName</param>
    /// <param name="GroupEmail">GroupEmail</param>
    /// <param name="Status">Status</param>
    /// <param name="LastModifiedBy">LastModifiedBy</param>
    /// <returns></returns>
    public string CreateGroup(Conn ObjConn, SqlCommand ObjSqlCommmand, string GroupName, string GroupEmail, string Status,string LastModifiedBy)
    {
        return ObjConn.executescalarstringquery(ObjSqlCommmand, "INSERT INTO [Group]([GroupName],[GroupEmail],[Status],[Created],[LastModifiedBy])"
                                               + " VALUES ('" + GroupName + "','" + GroupEmail + "','" + Status + "',GETDATE(),'" 
                                               + LastModifiedBy + "')"+ " Select @@IDENTITY");
    }

    /// <summary>
    /// Update Group
    /// </summary>
    /// <param name="ObjConn">SqlConnection</param>
    /// <param name="ObjSqlCommmand">SqlCommand</param>
    /// <param name="GroupName">GroupName</param>
    /// <param name="GroupEmail">GroupEmail</param>
    /// <param name="Status">Status</param>
    /// <param name="LastModifiedBy">LastModifiedBy</param>
    /// <returns></returns>
    public string UpdateGroup(Conn ObjConn, SqlCommand ObjSqlCommmand,int GroupID, string GroupName, string GroupEmail, string Status, string LastModifiedBy)
    {
        return ObjConn.executescalarstringquery(ObjSqlCommmand, "UPDATE [Group] SET [GroupName] = '" + GroupName + "',[GroupEmail]='" + GroupEmail + "',[Status]='" + Status
                                               + "',[Modified]=GETDATE(),[LastModifiedBy]='"
                                               + LastModifiedBy + "' output inserted.GroupID where GroupID = " + GroupID.ToString());
    }

    /// <summary>
    /// Delete Group
    /// </summary>
    /// <param name="ObjConn">SqlConnection</param>
    /// <param name="ObjSqlCommmand">SqlCommand</param>
    /// <param name="GroupID">GroupID</param>
    /// <returns></returns>
    public string DeleteGroup(Conn ObjConn, SqlCommand ObjSqlCommmand, int GroupID)
    {
        return ObjConn.executescalarstringquery(ObjSqlCommmand, "DELETE from [Group] output deleted.GroupID where [GroupID] = " + GroupID.ToString());
    }

    /// <summary>
    /// Select Group based on GroupID
    /// </summary>
    /// <param name="ObjConn">SqlConnection</param>
    /// <param name="ObjSqlCommmand">SqlCommand</param>
    /// <param name="GroupID">GroupID</param>
    /// <returns></returns>
    public DataTable SelectGroup(Conn ObjConn, SqlCommand ObjSqlCommmand, int GroupID)
    {
        return ObjConn.executeSelectQuery(ObjSqlCommmand, "SELECT * from [Group] where [GroupID] = " + GroupID.ToString());
    }

    /// <summary>
    /// Select all Group 
    /// </summary>
    /// <param name="ObjConn">SqlConnection</param>
    /// <param name="ObjSqlCommmand">SqlCommand</param>
    /// <returns></returns>
    public DataTable SelectGroup(Conn ObjConn, SqlCommand ObjSqlCommmand)
    {
        return ObjConn.executeSelectQuery(ObjSqlCommmand, "SELECT * from [Group]");
    }

    /// <summary>
    /// Is Group Exists
    /// </summary>
    /// <param name="ObjConn">SqlConnection</param>
    /// <param name="ObjSqlCommmand">SqlCommand</param>
    /// <param name="GroupName">GroupName</param>
    /// <returns></returns>
    public bool IsGroupExists(Conn ObjConn, SqlCommand ObjSqlCommmand, string GroupName)
    {
        int i = ObjConn.executeselectcountquery(ObjSqlCommmand, "select count(1) from [User] where GroupName = '" + GroupName + "'");
        if (i > 0)
            return true;
        else
            return false;

    }

    /// <summary>
    /// Insert Group Settings
    /// </summary>
    /// <param name="ObjConn">SqlConnection</param>
    /// <param name="ObjSqlCommmand">SqlCommand</param>
    /// <param name="GroupID">GroupID</param>
    /// <param name="ExpiryTime">ExpiryTime</param>
    /// <param name="RoutingType">RoutingType</param>
    /// <param name="RoutingTime">RoutingTime</param>
    /// <param name="LastModifiedBy">LastModifiedBy</param>
    /// <returns></returns>
    public string InsertGroupSettings(Conn ObjConn, SqlCommand ObjSqlCommmand, int GroupID, int ExpiryTime, string RoutingType, int RoutingTime, string LastModifiedBy)
    {
        return ObjConn.executescalarstringquery(ObjSqlCommmand, " INSERT INTO [GroupSettings]([GroupID],[ExpiryTime],[RoutingType],[RoutingTime],[Created],[LastModifiedBy])"
                                               + " VALUES (" + GroupID + "," + ExpiryTime + ",'" + RoutingType + "'," + RoutingTime + ",GETDATE(),'"
                                               + LastModifiedBy + "')"
                                               + " Select @@IDENTITY");
    }

    /// <summary>
    /// Update Group Settings
    /// </summary>
    /// <param name="ObjConn">SqlConnection</param>
    /// <param name="ObjSqlCommmand">SqlCommand</param>
    /// <param name="GroupID">GroupID</param>
    /// <param name="ExpiryTime">ExpiryTime</param>
    /// <param name="RoutingType">RoutingType</param>
    /// <param name="RoutingTime">RoutingTime</param>
    /// <param name="LastModifiedBy">LastModifiedBy</param>
    /// <returns></returns>
    public string UpdateGroupSettings(Conn ObjConn, SqlCommand ObjSqlCommmand, int GroupID, int ExpiryTime, string RoutingType, int RoutingTime, string LastModifiedBy)
    {
        return ObjConn.executescalarstringquery(ObjSqlCommmand, " UPDATE [GroupSettings] SET [ExpiryTime] = '" + ExpiryTime + "',[RoutingType]='" + RoutingType + "',"
                                               + "[RoutingTime]=" + RoutingTime + ",[Modified]=GETDATE(),[LastModifiedBy]='" + LastModifiedBy + "'"
                                               + " output inserted.GroupID  where [GroupID] =" + GroupID);                                              
    }

    /// <summary>
    /// Delete Gorup Settings
    /// </summary>
    /// <param name="ObjConn">SqlConnection</param>
    /// <param name="ObjSqlCommmand">SqlCommand</param>
    /// <param name="GroupID">GroupID</param>
    /// <returns></returns>
    public string DeleteGorupSettings(Conn ObjConn, SqlCommand ObjSqlCommmand, int GroupID)
    {
        return ObjConn.executescalarstringquery(ObjSqlCommmand, "Delete from [GroupSettings] output deleted.GroupID where [GroupID] = " + GroupID);
    }
}