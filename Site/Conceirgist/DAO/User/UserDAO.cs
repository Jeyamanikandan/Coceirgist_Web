using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for UserDAO
/// </summary>
public class UserDAO
{    
	public UserDAO()
	{        
	}

    /// <summary>
    /// Create User
    /// </summary>
    /// <param name="ObjConn"></param>
    /// <param name="ObjSqlCommmand"></param>
    /// <param name="Login"></param>
    /// <param name="Password"></param>
    /// <param name="Status"></param>
    /// <param name="OnlineStatus"></param>
    /// <param name="RoleID"></param>
    /// <param name="Email"></param>
    /// <param name="Name"></param>
    /// <param name="Address"></param>
    /// <param name="Photo"></param>
    /// <param name="SessionID"></param>
    /// <param name="LastModifiedBy"></param>
    /// <returns></returns>
    public string CreateUser(Conn ObjConn,SqlCommand ObjSqlCommmand, string Login, string Password, string Status, string OnlineStatus, int RoleID, string Email,string Name,
                           string Address,string Photo,string SessionID,string LastModifiedBy)
    {
        try
        {
                    
        }
        catch (SqlException ex)
        { 
        
        }

        return ObjConn.executescalarstringquery(ObjSqlCommmand, " INSERT INTO [User]([Login],[Password],[Status],[OnlineStatus],[RoleID],[Email],[Name],[Address],[Photo],[SessionID],[Created],[LastModifiedBy])"
                                               +" VALUES ('" + Login + "','" + Password +"','" + Status + "','" + OnlineStatus + "'," +RoleID+ ",'" + Email + "','" + Name + "','"
                                               + Address + "','" + Photo + "','" + SessionID + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "','" + LastModifiedBy + "')"
                                               + " Select @@IDENTITY");        
    }

    /// <summary>
    /// Update User
    /// </summary>
    /// <param name="ObjConn"></param>
    /// <param name="ObjSqlCommmand"></param>
    /// <param name="Password"></param>
    /// <param name="Status"></param>
    /// <param name="OnlineStatus"></param>
    /// <param name="RoleID"></param>
    /// <param name="Email"></param>
    /// <param name="Name"></param>
    /// <param name="Address"></param>
    /// <param name="Photo"></param>
    /// <param name="SessionID"></param>
    /// <param name="LastModifiedBy"></param>
    /// <returns></returns>
    public string UpdateUser(Conn ObjConn, SqlCommand ObjSqlCommmand,int UserID, string Password, string Status, string OnlineStatus, int RoleID, string Email, string Name,
                           string Address, string Photo, string SessionID, string LastModifiedBy)
    {
        return ObjConn.executescalarstringquery(ObjSqlCommmand, " UPDATE [User]  SET [Password] = '" + Password + "',[Status] = '" + Status + "',[OnlineStatus] = '" + OnlineStatus + "',[RoleID] = " + RoleID
                                               + ",[Email] = '" + Email + "',[Name] = '" + Name + "',[Address] = '" + Address + "',[Photo] = '" + Photo + "',[SessionID] = '" + SessionID + "',"
                                               + "[Modified] = '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "',[LastModifiedBy] = '" + LastModifiedBy 
                                               + "' output inserted.UserID where [UserID] = " + UserID.ToString());
    } 

    /// <summary>
    /// Delete User
    /// </summary>
    /// <param name="ObjConn">SqlConnection</param>
    /// <param name="ObjSqlCommmand">SqlCommand</param>
    /// <param name="UserID">UserID</param>
    /// <returns>UserID</returns>
    public string DeleteUser(Conn ObjConn, SqlCommand ObjSqlCommmand, int UserID)
    {
        return ObjConn.executescalarstringquery(ObjSqlCommmand, "Delete from [User] output deleted.UserID where [UserID] = " + UserID);
    }

    /// <summary>
    /// Select User bys UserID
    /// </summary>
    /// <param name="ObjConn">SqlConnection</param>
    /// <param name="ObjSqlCommmand">SqlCommand</param>
    /// <param name="UserID">UserID</param>
    /// <returns>User Details</returns>
    public DataTable SelectUser(Conn ObjConn, SqlCommand ObjSqlCommmand, int UserID)
    {
        return ObjConn.executeSelectQuery(ObjSqlCommmand, "select * from [User] where [UserID] = " + UserID);            
    }

    /// <summary>
    /// Select all Users
    /// </summary>
    /// <param name="ObjConn">SqlConnection</param>
    /// <param name="ObjSqlCommmand">SqlCommand</param>
    /// <returns>User Table</returns>
    public DataTable SelectUser(Conn ObjConn, SqlCommand ObjSqlCommmand)
    {
        return ObjConn.executeSelectQuery(ObjSqlCommmand, "select * from [User]");
    }

    /// <summary>
    /// Is User Exists
    /// </summary>
    /// <param name="ObjConn">SqlConnection</param>
    /// <param name="ObjSqlCommmand">SqlCommand</param>
    /// <param name="Login">Login</param>
    /// <returns>True/False</returns>
    public bool IsUserExists(Conn ObjConn, SqlCommand ObjSqlCommmand,string Login)
    {
       int i = ObjConn.executeselectcountquery(ObjSqlCommmand, "select COUNT(1) from [User] where [Login] = '" + Login + "'");
       if (i > 0)
           return true;
       else
           return false;

    }

    /// <summary>
    /// Insert User Settings
    /// </summary>
    /// <param name="ObjConn">SqlConnection</param>
    /// <param name="ObjSqlCommmand">SqlCommand</param>
    /// <param name="UserID">UserID</param>
    /// <param name="AttentionSound">AttentionSound</param>
    /// <param name="NewMessageSound">NewMessageSound</param>
    /// <param name="ThemeID">ThemeID</param>
    /// <param name="LastModifiedBy">LastModifiedBy</param>
    /// <returns></returns>
    public string InsertUserSettings(Conn ObjConn, SqlCommand ObjSqlCommmand, int UserID, string AttentionSound, string NewMessageSound, int ThemeID,string LastModifiedBy)
    {
        return ObjConn.executescalarstringquery(ObjSqlCommmand, " INSERT INTO [UserSettings]([UserID],[AttentionSound],[NewMessageSound],[ThemeID],[Created],[LastModifiedBy])"
                                               + " VALUES (" + UserID + ",'" + AttentionSound + "','" + NewMessageSound + "'," + ThemeID + "," 
                                               + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "','" + LastModifiedBy + "')"
                                               + " Select @@IDENTITY");
    }

    public string UpdateUserSettings(Conn ObjConn, SqlCommand ObjSqlCommmand, int UserID, string AttentionSound, string NewMessageSound, int ThemeID, string LastModifiedBy)
    {
        return ObjConn.executescalarstringquery(ObjSqlCommmand, " UPDATE [UserSettings] SET [AttentionSound] = '" + AttentionSound + "',[NewMessageSound]='" + NewMessageSound + "',"
                                               + "[ThemeID]=" + ThemeID + ",[Modified]='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "',[LastModifiedBy]='" + LastModifiedBy + "'"
                                               + " output inserted.UserID where [UserID] =" + UserID);                                              
    }

    /// <summary>
    /// Delete User Settings
    /// </summary>
    /// <param name="ObjConn">SqlConnection</param>
    /// <param name="ObjSqlCommmand">SqlCommand</param>
    /// <param name="UserID">UserID</param>
    /// <returns>UserID</returns>
    public string DeleteUserSettings(Conn ObjConn, SqlCommand ObjSqlCommmand, int UserID)
    {
        return ObjConn.executescalarstringquery(ObjSqlCommmand, "Delete from [UserSettings] output deleted.UserID where [UserID] = " + UserID);
    }

    public DataTable SelectUserSettings(Conn ObjConn, SqlCommand ObjSqlCommmand, int UserID)
    {
        return ObjConn.executeSelectQuery(ObjSqlCommmand, "select * from [UserSettings] where [UserID] = " + UserID);
    }
}