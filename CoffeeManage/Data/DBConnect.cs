using System;
using System.Data.SqlClient;

namespace QLY_Coffee.Data
{
    public class DBConnect
    {
        private string Conn = @"Data Source = KURUMI\KURUMI;Initial Catalog = COFFEE_MANAGE; Persist Security Info=True;User ID = sa; Password=Tokisakikurumi1@;";

        public SqlConnection GetConnection()
        {
            return new SqlConnection(Conn);
        }
    }
}


