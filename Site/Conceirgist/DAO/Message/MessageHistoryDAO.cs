using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for MessageHistoryDAO
/// </summary>
public class MessageHistoryDAO
{
	public MessageHistoryDAO()
	{
	}

    public string CreateMessageHistory(Conn ObjConn, SqlCommand ObjSqlCommmand, int MessageID, string InquiryID, int FromUserID, string ExecutiveIP, int ToUserID,int MessageSequence,
                                       Int16 MessageRead)
    {
        return ObjConn.executescalarstringquery(ObjSqlCommmand, "INSERT INTO [MessageHistory]([MessageID],[ExecutiveIP],[CustomerID],[MessageSequence],[MessageRead])"
                                               + " VALUES (" + MessageID.ToString() + ",'" + InquiryID + "'," + FromUserID.ToString() + ",'" + ExecutiveIP + "'," + MessageSequence.ToString() + "','"
                                               + MessageRead.ToString() + ")" + " Select @@IDENTITY");
    }
    public string UpdateMessageHistory(Conn ObjConn, SqlCommand ObjSqlCommmand, int MessageID, int ExecutiveID, string ExecutiveIP, int CustomerID, int MessageSequence, Int16 MessageRead)
    {
        return ObjConn.executescalarstringquery(ObjSqlCommmand, "UPDATE [Message] SET [ExecutiveID] = " + ExecutiveID.ToString() + ",[ExecutiveIP] = '" + ExecutiveIP
                                               + "',[CustomerID] = " + CustomerID.ToString() + ",[MessageSequence] = " + MessageSequence.ToString() + ",[MessageRead] =" + MessageRead.ToString() + " VALUES (" + ExecutiveID.ToString() + ",'" + ExecutiveIP + "'," + CustomerID.ToString() + "," + MessageSequence.ToString() + "','"
                                               + " output inserted.MessageID where MessageID = " + MessageID);
    }

    public DataTable SelectMessageHistory(Conn ObjConn, SqlCommand ObjSqlCommmand, int MessageID)
    {
        return ObjConn.executeSelectQuery(ObjSqlCommmand, "SELECT * from [Message] where [MessageID] = " + MessageID.ToString());
    }
}