﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqliteDateTimeGrid
{
    class SqliteService
    {
        public string DbPath { get; set; }
        public string TableName { get; set; }

        public SqliteService(string dbPath, string tableName)
        {
            DbPath = dbPath;
            TableName = tableName;
        }
        
        public void FillDataTable(DataTable dataTable)
        {
            var query = $"select * from {TableName}";

            using (SQLiteConnection connection = GetConnection())
            using (var adapter = new SQLiteDataAdapter(query, connection))
            {
                adapter.Fill(dataTable);
            }
        }

        public void Update(DataTable dataTable)
        {
            var query = $"select * from {TableName}";

            using (SQLiteConnection connection = GetConnection())
            using (var adapter = new SQLiteDataAdapter(query, connection))
            using (var commandBuilder = new SQLiteCommandBuilder(adapter))
            {
                adapter.UpdateCommand = commandBuilder.GetUpdateCommand();
                adapter.DeleteCommand = commandBuilder.GetDeleteCommand();
                adapter.InsertCommand = commandBuilder.GetInsertCommand();
                adapter.Update(dataTable);
            }
        }

        private SQLiteConnection GetConnection()
        {
            var connection = new SQLiteConnection($"Data Source={DbPath}");
            connection.Open();
            return connection;
        }
    }
}
