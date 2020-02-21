using System.Collections.Generic;
using Npgsql;
using web_test_api.models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using web_test_api.Interfaces;

namespace WebApiIntroAssignment.Services
{
    public class Database : IDatabase
    {
        private readonly NpgsqlConnection _connection;

        public Database(NpgsqlConnection connection)
        {
            _connection = connection;
            _connection.Open();
        }

        public void Create(Members data)
        {
            var command = _connection.CreateCommand();
            command.CommandText =
                "INSERT INTO Members (username,password,email,full_name,popularity) VALUES (@username, @password, @email, @full_name, @popularity) RETURNING id";
            command.Parameters.AddWithValue("@username", data.Username);
            command.Parameters.AddWithValue("@password", data.Password);
            command.Parameters.AddWithValue("@email", data.Email);
            command.Parameters.AddWithValue("@full_name", data.Full_name);
            command.Parameters.AddWithValue("@popularity", data.Popularity);
            command.ExecuteNonQuery();
            _connection.Close();
        }

        public List<Members> Read()
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

        public void Update(int id, [FromBody]JsonPatchDocument<Members> data)
        {
            var command = _connection.CreateCommand();
            var member = ReadById(id);
            _connection.Open();
            data.ApplyTo(member);
            command.CommandText =
                $"UPDATE Members SET (username,password,email,full_name,popularity) = (@username, @password, @email, @full_name, @popularity) WHERE id = {id}";
            command.Parameters.AddWithValue("@username", member.Username);
            command.Parameters.AddWithValue("@password", member.Password);
            command.Parameters.AddWithValue("@email", member.Email);
            command.Parameters.AddWithValue("@full_name", member.Full_name);
            command.Parameters.AddWithValue("@popularity", member.Popularity);
            command.ExecuteNonQuery();
            _connection.Close();
        }

        public Members ReadById(int id)
        {
            var command = _connection.CreateCommand();
            command.CommandText =
                $"SELECT * FROM Members WHERE id = {id}";
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

        public void Delete(int id)
        {
            var command = _connection.CreateCommand();
            command.CommandText =
                $"DELETE FROM Members WHERE id = {id}";
            command.ExecuteNonQuery();
            _connection.Close();
        }
    }
}