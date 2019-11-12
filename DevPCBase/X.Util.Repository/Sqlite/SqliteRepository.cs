﻿using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace X.Util.Repository.Sqlite
{
    public class SqliteRepository<TEntity, TKey> : ISqliteRepository<TEntity, TKey>
       where TEntity : SqliteEntity<TKey>
    {
        public string _connectString;
        public SqliteRepository(string databasePath)
        {
            _connectString = databasePath;
        }

        public bool Delete(string sqlText, object param = null)
        {
            using (var conn = this.GetConnection())
            {
                var result = conn.Execute(sqlText, param);
            }
            return true;
        }

        public void Execute(string sqlText, object param = null)
        {
            using (var conn = this.GetConnection())
            {
                var result = conn.Execute(sqlText, param);
            }
        }

        public bool Insert(string sqlText, object param = null)
        {
            using (var conn = this.GetConnection())
            {
                var result = conn.Execute(sqlText, param);
            }
            return true;
        }

        public TEntity Query(string sqlText, object param = null)
        {
            TEntity result = null;
            using (var conn = this.GetConnection())
            {
                result = conn.QueryFirstOrDefault<TEntity>(sqlText, param);

            }
            return result;
        }

        public IList<TEntity> QueryMutiple(string sqlText, object param = null)
        {
            IEnumerable<TEntity> result = null;
            using (var conn = this.GetConnection())
            {
                result = conn.Query<TEntity>(sqlText, param);

            }
            return result.ToList();
        }

        public void Update(string sqlText, object param = null)
        {
            using (var conn = this.GetConnection())
            {
                var result = conn.Execute(sqlText, param);
            }
        }

        public SQLiteConnection GetConnection()
        {
            SQLiteConnection conn = new SQLiteConnection(_connectString);
            if (conn.State != System.Data.ConnectionState.Open)
            {
                conn.Open();
            }
            return conn;
        }
    }
}
