using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for MessageDAO
/// </summary>
public class MessageDAO
{
	public MessageDAO()
	{		
	}
    public string CreateMessage(Conn ObjConn, SqlCommand ObjSqlCommmand, int ExecutiveID, string ExecutiveIP, int CustomerID, int MessageSequence, Int16 MessageRead)
    {
        return ObjConn.executescalarstringquery(ObjSqlCommmand, "INSERT INTO [Message]([ExecutiveID],[ExecutiveIP],[CustomerID],[MessageSequence],[MessageRead])"
                                               + " VALUES (" + ExecutiveID.ToString() + ",'" + ExecutiveIP + "'," + CustomerID.ToString() + "," + MessageSequence.ToString() + "','"
                                               + MessageRead.ToString() + ")" + " Select @@IDENTITY");
    }
    public string UpdateMessage(Conn ObjConn, SqlCommand ObjSqlCommmand,int MessageID, int ExecutiveID, string ExecutiveIP, int CustomerID, int MessageSequence, Int16 MessageRead)
    {
        return ObjConn.executescalarstringquery(ObjSqlCommmand, "UPDATE [Message] SET [ExecutiveID] = " + ExecutiveID.ToString() + ",[ExecutiveIP] = '" + ExecutiveIP
                                               + "',[CustomerID] = " + CustomerID.ToString() + ",[MessageSequence] = " + MessageSequence.ToString() + ",[MessageRead] =" + MessageRead.ToString()                                               + " VALUES (" + ExecutiveID.ToString() + ",'" + ExecutiveIP + "'," + CustomerID.ToString() + "," + MessageSequence.ToString() + "','"
                                               + " output inserted.MessageID where MessageID = " + MessageID);
    }
    public string DeleteMessage(Conn ObjConn, SqlCommand ObjSqlCommmand, int MessageID)
    {
        return ObjConn.executescalarstringquery(ObjSqlCommmand, "DELETE from [Message] output deleted.MessageID where MessageID = " + MessageID);
    }

    public DataTable SelectMessage(Conn ObjConn, SqlCommand ObjSqlCommmand, int MessageID)
    {
        return ObjConn.executeSelectQuery(ObjSqlCommmand, "SELECT * from [Message] where [MessageID] = " + MessageID.ToString());
    }
}