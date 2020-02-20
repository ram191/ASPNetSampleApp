using System.Collections.Generic;
using System.Linq;
using Npgsql;
using web_test_api.models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using web_test_api.Controllers;

namespace WebApiIntroAssignment.Services
{
    public interface IDatabase
    {
        // public List<Members> Get();
        public void Post(Members data);
        // public void Delete(int id);
        // public Members Patch(int id, Members data);
        public List<Members> GetMembers();
        public Members GetSpecificMember(int id);
        public void DeleteMember(int id);
    }
    public class Database : IDatabase
    {
        private readonly IDatabase _database;
        private readonly NpgsqlConnection _connection;

        public Database(NpgsqlConnection connection)
        {
            _connection = connection;
            _connection.Open();
        }
        public void Post(Members data)
        {
            var command = _connection.CreateCommand();
            command.CommandText = "INSERT INTO Members (username,password,email,full_name,popularity) VALUES (@username, @password, @email, @full_name, @popularity) RETURNING id";
            command.Parameters.AddWithValue("@username", data.Username);
            command.Parameters.AddWithValue("@password", data.Password);
            command.Parameters.AddWithValue("@email", data.Email);
            command.Parameters.AddWithValue("@full_name", data.Full_name);
            command.Parameters.AddWithValue("@popularity", data.Popularity);
            var result = command.ExecuteScalar();
            _connection.Close();
        } 
        public List<Members> GetMembers()
        {
            var command = _connection.CreateCommand();
            command.CommandText = "SELECT * FROM Members";
            var result = command.ExecuteReader();
            var User = new List<Members>();
            while (result.Read())
                User.Add(new Members() { Id = (int)result[0], Username = (string)result[1], Password = (string)result[2], Email = (string)result[3], Full_name = (string)result[4], Popularity = (int)result[5] });
            _connection.Close();
            return User;
        }
        // public Members PatchMember(int id, Members data)
        // {
        //     var command = _connection.CreateCommand();
        //     command.CommandText = "UPDATE Members SET ";
        //     var result = command.ExecuteReader();
        //     var User = new List<Members>();
        //     while (result.Read())
        //         User.Add(new Members() { Id = (int)result[0], Username = (string)result[1], Password = (string)result[2], Email = (string)result[3], Full_name = (string)result[4], Popularity = (int)result[5] });
        //     _connection.Close();
        //     return User;
        // }
        public Members GetSpecificMember(int id)
        {
            var command = _connection.CreateCommand();
            command.CommandText = $"SELECT * FROM Members WHERE id = {id}";
            var result = command.ExecuteReader();
            result.Read();
            var member = new Members()
            {
                Id = (int)result[0], 
                Username = (string)result[1], 
                Password = (string)result[2], 
                Email = (string)result[3], 
                Full_name = (string)result[4], 
                Popularity = (int)result[5]
            };
            _connection.Close();
            return member;
        }

        public void DeleteMember(int id)
        {
            var command = _connection.CreateCommand();
            command.CommandText = $"DELETE FROM Members WHERE id = {id}";
            command.ExecuteNonQuery();
            _connection.Close();
        }
    }
}