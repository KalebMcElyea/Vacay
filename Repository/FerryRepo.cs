using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using Models;

namespace Repository
{
    public class FerryRepo
    {

        public readonly IDbConnection _db;

        public FerryRepo(IDbConnection db)
        {
            _db = db;
        }

        internal IEnumerable<Ferry> GetAll()
        {
            string sql = "SELECT * FROM ferry;";
            return _db.Query<Ferry>(sql);
        }
    }
}