using System;
using MySql.Data;
using MySql.Data.MySqlClient;

public class ConnDB
{
    public static MySqlConnection ConnectionDB()
    {
        String connString = "Server=localhost; Database=c1608l ; Port=3306; User ID = root;Password = ";
        MySqlConnection conn = new MySqlConnection(connString);
        conn.Open();
        return conn;
    }

}
