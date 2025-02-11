using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Web.UI.WebControls;

namespace GroupCourseWork.Models
{
    public class DatabaseController
    {
        public class DB
        {
            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

            public void initDbConnection()
            {
                if (sqlConnection.State == ConnectionState.Closed)
                {
                    sqlConnection.Open();
                }
            }
            public void ExecuteSqlQuery( string SqlQuery)
            {
                this.initDbConnection();
                SqlCommand sqlCommand   =   new SqlCommand(SqlQuery, sqlConnection);
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }

            public SqlDataReader AddToDropDown(string SqlQuery)
            {
                sqlConnection.Close();
                this.initDbConnection();
                SqlCommand sqlCommand = new SqlCommand(SqlQuery, sqlConnection);
                SqlDataReader downList = sqlCommand.ExecuteReader();
                return downList;
            }

            public DataTable Get( string SqlQuery )
            {
                if (sqlConnection.State == ConnectionState.Closed)
                {
                    sqlConnection.Open();
                }
                SqlCommand cmd = new SqlCommand(SqlQuery, sqlConnection);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }

            public int InsertedID( string sql)
            {
                int primaryKey;
                this.initDbConnection();
                SqlCommand myCommand = new SqlCommand(sql, sqlConnection);
                primaryKey = Convert.ToInt32(myCommand.ExecuteScalar());
                sqlConnection.Close();
                return primaryKey;
            }
        }
    }
}