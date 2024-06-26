﻿using Balaji.Common.Models;
using Balaji.Core.Repository;
using Dapper;
using MySqlConnector;

namespace Balaji.Infrastructure.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity>
    {
        public BaseRepository() { }
        public virtual async Task<dynamic> InsertAsync(Session session, TEntity model, string sql)
        {
            int rowsAffected;
            string? connectionString = session?.ConnectionString;

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new Exception("Empty Connection string");
            }

            using (var connection = new MySqlConnection(connectionString))
            {
                await connection.OpenAsync().ConfigureAwait(false);

                rowsAffected = await connection.ExecuteAsync(sql, model);

                await connection.CloseAsync();
            }

            return new
            {
                IsSuccess = rowsAffected > 0,
                RowsAffewcted = rowsAffected
            };
        }

        public virtual async Task<dynamic> InsertAsync(PublicSession session, TEntity model, string sql)
        {
            int rowsAffected;
            string? connectionString = session?.ConnectionString;

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new Exception("Empty Connection string");
            }

            using (var connection = new MySqlConnection(connectionString))
            {
                await connection.OpenAsync().ConfigureAwait(false);

                rowsAffected = await connection.ExecuteAsync(sql, model);

                await connection.CloseAsync();
            }

            return new
            {
                IsSuccess = rowsAffected > 0,
                RowsAffewcted = rowsAffected
            };
        }

        public virtual async Task<dynamic> UpdateAsync(Session session, TEntity model, string sql)
        {
            int rowsAffected;
            string? connectionString = session.ConnectionString;

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new Exception("Connection string is empty ");
            }
            using (var connection = new MySqlConnection())
            {
                await connection.OpenAsync().ConfigureAwait(false);

                rowsAffected = await connection.ExecuteAsync(sql, model);
            }

            return new
            {
                IsSuccess = rowsAffected > 0,
                RowsAffewcted = rowsAffected
            };
        }

        public virtual async Task<List<TEntity>> SelectAsync(PublicSession session, TEntity model, string sql)
        {
            try
            {
                string? connectionString = session.ConnectionString;
                List<TEntity> data;

                if (string.IsNullOrEmpty(connectionString))
                {
                    throw new Exception("ConnectionString is null or empty");
                }

                using (var connection = new MySqlConnection(connectionString))
                {
                    await connection.OpenAsync();

                    var result = await connection.QueryAsync<TEntity>(sql, model);
                    data = result.ToList();

                    await connection.CloseAsync();
                }

                return data;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual async Task<List<TEntity>> SaveAsync(Session session, TEntity model, string sql)
        {
            try
            {
                string? connectionString = session.ConnectionString;
                List<TEntity> data;

                if (string.IsNullOrEmpty(connectionString))
                {
                    throw new Exception("ConnectionString is null or empty");
                }

                using (var connection = new MySqlConnection(connectionString))
                {
                    await connection.OpenAsync();

                    var result = await connection.QueryAsync<TEntity>(sql, model);
                    data = result.ToList();

                    await connection.CloseAsync();
                }

                return data;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
