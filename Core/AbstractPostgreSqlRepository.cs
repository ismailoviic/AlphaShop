using Dapper;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace AlphaShop.Core
{
    public class AbstractPostgreSqlRepository
    {
        private readonly NpgsqlConnectionStringBuilder _connectionStringBuilder;

        public AbstractPostgreSqlRepository(PostgreSqlConfiguration configOptions)
        {
            var configuration = configOptions;
            _connectionStringBuilder = new NpgsqlConnectionStringBuilder
            {
                Host = configuration.Host,
                Username = configuration.Username,
                Password = configuration.Password,
                Database = configuration.Database,
                Pooling = configuration.Pooling,
                Port = configuration.Port,
                CommandTimeout = 60,
                Timeout = 30,
                MinPoolSize = 20,
                MaxPoolSize = 200,
                ConnectionIdleLifetime = 600,
                ConnectionPruningInterval = 5,
                ClientEncoding = "UTF8",
                Encoding = "UTF8",
            };
        }


        protected NpgsqlConnection GetSqlConnection() => new NpgsqlConnection(_connectionStringBuilder.ConnectionString);

        protected async Task<T> QueryFirstOrDefaultAsync<T>(string sql, object parameters = null)
        {
            await using var connection = GetSqlConnection();
            await connection.OpenAsync();
            return await connection.QueryFirstOrDefaultAsync<T>(sql.AddMetaDataToSqlRequest(), parameters);
        }

        protected async Task<T> QueryFirstAsync<T>(string sql, object parameters = null)
        {
            await using var connection = GetSqlConnection();
            await connection.OpenAsync();
            return await connection.QueryFirstAsync<T>(sql.AddMetaDataToSqlRequest(), parameters);
        }

        protected async Task<IEnumerable<T>> QueryAsync<T>(string sql, object parameters = null)
        {
            await using var connection = GetSqlConnection();
            await connection.OpenAsync();
            return await connection.QueryAsync<T>(sql.AddMetaDataToSqlRequest(), parameters);
        }

        protected async Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TReturn>(string sql,
            Func<TFirst, TSecond, TReturn> map, object parameters = null, string splitOn = "Id")
        {
            await using var connection = GetSqlConnection();
            await connection.OpenAsync();
            return await connection.QueryAsync(sql.AddMetaDataToSqlRequest(), map, parameters, null, true, splitOn);
        }

        protected async Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TReturn>(string sql,
            Func<TFirst, TSecond, TThird, TReturn> map, object parameters = null, string splitOn = "Id")
        {
            await using var connection = GetSqlConnection();
            await connection.OpenAsync();
            return await connection.QueryAsync(sql.AddMetaDataToSqlRequest(), map, parameters, null, true, splitOn);
        }

        protected async Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TFourth, TReturn>(string sql,
            Func<TFirst, TSecond, TThird, TFourth, TReturn> map, object parameters = null, string splitOn = "Id")
        {
            await using var connection = GetSqlConnection();
            await connection.OpenAsync();
            return await connection.QueryAsync(sql.AddMetaDataToSqlRequest(), map, parameters, null, true, splitOn);
        }

        protected async Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TFourth, TFifth, TReturn>(
            string sql, Func<TFirst, TSecond, TThird, TFourth, TFifth, TReturn> map, object parameters = null,
            string splitOn = "Id")
        {
            await using var connection = GetSqlConnection();
            await connection.OpenAsync();
            return await connection.QueryAsync(sql.AddMetaDataToSqlRequest(), map, parameters, null, true, splitOn);
        }

        protected async Task<T> ExecuteScalarAsync<T>(string sql, object parameters = null)
        {
            await using var connection = GetSqlConnection();
            await connection.OpenAsync();
            return await connection.ExecuteScalarAsync<T>(sql.AddMetaDataToSqlRequest(), parameters);
        }

        public async Task<int> ExecuteAsync(string sql, object parameters = null)
        {
            await using var connection = GetSqlConnection();
            await connection.OpenAsync();
            return await connection.ExecuteAsync(sql.AddMetaDataToSqlRequest(), parameters);
        }

        protected async Task<TReturn> QueryFirstComplexAsync<TFirst, TSecond, TReturn>(string sql,
            Func<TFirst, TSecond, TReturn> map, object parameters = null, string splitOn = "Id")
        {
            await using var connection = GetSqlConnection();
            await connection.OpenAsync();
            var results = await connection.QueryAsync(sql.AddMetaDataToSqlRequest(), map, parameters, null, true, splitOn);
            return results.FirstOrDefault();
        }

        protected async Task<TReturn> QueryFirstComplexAsync<TFirst, TSecond, TThird, TReturn>(string sql,
            Func<TFirst, TSecond, TThird, TReturn> map, object parameters = null, string splitOn = "Id")
        {
            await using var connection = GetSqlConnection();
            await connection.OpenAsync();
            var results = await connection.QueryAsync(sql.AddMetaDataToSqlRequest(), map, parameters, null, true, splitOn);
            return results.FirstOrDefault();
        }

        protected async Task<TReturn> QueryFirstComplexAsync<TFirst, TSecond, TThird, TFourth, TReturn>(string sql,
            Func<TFirst, TSecond, TThird, TFourth, TReturn> map, object parameters = null, string splitOn = "Id")
        {
            await using var connection = GetSqlConnection();
            await connection.OpenAsync();
            var results = await connection.QueryAsync(sql.AddMetaDataToSqlRequest(), map, parameters, null, true, splitOn);
            return results.FirstOrDefault();
        }

        protected async Task<TReturn> QueryFirstComplexAsync<TFirst, TSecond, TThird, TFourth, TFifth, TReturn>(
            string sql, Func<TFirst, TSecond, TThird, TFourth, TFifth, TReturn> map, object parameters = null,
            string splitOn = "Id")
        {
            await using var connection = GetSqlConnection();
            await connection.OpenAsync();
            var results = await connection.QueryAsync(sql.AddMetaDataToSqlRequest(), map, parameters, null, true, splitOn);
            return results.FirstOrDefault();
        }

        protected async Task<TReturn> QueryFirstComplexAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TReturn>(
            string sql, Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TReturn> map, object parameters = null,
            string splitOn = "Id")
        {
            await using var connection = GetSqlConnection();
            await connection.OpenAsync();
            var results = await connection.QueryAsync(sql.AddMetaDataToSqlRequest(), map, parameters, null, true, splitOn);
            return results.FirstOrDefault();
        }

        public async Task<bool> Check()
        {
            await using var connection = GetSqlConnection();
            await connection.OpenAsync();
            return connection.State == ConnectionState.Open || connection.State == ConnectionState.Connecting;
        }

        protected string GetInClause(IEnumerable<Guid> ids) =>
            string.Join(",", ids.Select(id => "'" + id + "'"));

        public Task Truncate(string tableName, bool cascade = false) =>
            ExecuteAsync($"TRUNCATE {tableName} {(cascade ? "CASCADE" : string.Empty)}");

    }
    public static class Extensions
    {
        public static string AddMetaDataToSqlRequest(this string sql) =>
            sql.Trim().StartsWith("SELECT") ? sql : sql.Insert(0, "/REPLICATION/ ");
    }
}