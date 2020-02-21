using System.Collections.Generic;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using web_test_api.models;

namespace web_test_api.Interfaces
{
    public interface IDatabase
    {
        public void Create(Members data);
        public void Update(int id, [FromBody]JsonPatchDocument<Members> data);
        public List<Members> Read();
        public Members ReadById(int id);
        public void Delete(int id);
    }
}
