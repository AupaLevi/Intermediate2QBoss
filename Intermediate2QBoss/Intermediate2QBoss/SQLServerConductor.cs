﻿using System;
using Oracle.ManagedDataAccess.Client;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intermediate2QBoss
{
    class SQLServerConductor
    {
        private SqlConnection sqlConnection;
        private string actionResult;
        private int deletedRows;

        string sql;

        public SQLServerConductor()
        {
            Initializer();
        }

        private void Initializer()
        {
            SqlConnectionStringBuilder Builder = new SqlConnectionStringBuilder();
            Builder.DataSource = "AUPA-EAI\\SQLEXPRESSINV";
            Builder.InitialCatalog = "EI_intermediate";
            Builder.UserID = "sa";
            Builder.Password = "#Aupa=234";
            String sqlConnectionString = Builder.ConnectionString;
            sqlConnection = new SqlConnection(sqlConnectionString);
        }

        private bool OpenConnection()
        {
            try
            {
                sqlConnection.Open();
                return true;
            }
            catch (SqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        //MessageBox.Show("Cannot connect to server.  Contact administrator");
                        break;
                    case 53:
                        Console.WriteLine("40 - 無法開啟至 SQL Server 的連接");
                        break;
                    case 1045:
                        //MessageBox.Show("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }

        private bool CloseConnection()
        {
            try
            {
                sqlConnection.Close();
                return true;
            }
            catch (SqlException ex)
            {
                //MessageBox.Show(ex.Message);
                Console.Write("MySqlException :" + ex.Message);
                return false;
            }
        }
        /*------------------
        public DataTable GetDataTable(String sql)
        {
            DataTable dataTable = null;
            OpenConnection();
            try
            {
                string name = sqlConnection.ServiceName;
                CommonUntil commonUntil = new CommonUntil();
                //int year = commonUntil.getYear();
                OracleCommand command = new OracleCommand(sql, this.connection);
                command.Connection = connection;
                command.CommandText = sql;
                command.CommandType = CommandType.Text;
                //OracleParameter[] parameters = new OracleParameter[] {
                //    new OracleParameter("val01",year),
                //    new OracleParameter("val02",month)
                //};
                //command.Parameters.AddRange(parameters);
                //sql = "SELECT * FROM tc_ome_file " +
                //        " WHERE tc_ome06 = '1' ";
                //OracleCommand command = new OracleCommand(sql, this.connection);
                OracleDataReader oracleDataReader = command.ExecuteReader();

                dataTable = new DataTable();
                dataTable.Load(oracleDataReader);
            }
            catch (Exception ex)
            {
                Console.WriteLine("OraDBConductor Excetpion" + ex.Message);
                PostalService postalService = new PostalService();
                postalService.SendMail("Levi.Huang@aupa.com.tw", "Intermediate Data Copier Alert", ex.Message);
            }
            finally
            {
                CloseOracleConnection();
            }


            return dataTable;
        }
        -------------------*/
    }
}