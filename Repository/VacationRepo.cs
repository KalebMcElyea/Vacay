using System;
using System.Data;
using Dapper;
using Models;

namespace Repository
{
    public class VacationRepo
    {
        private readonly IDbConnection _db;

        public VacationRepo(IDbConnection db)
        {
            _db = db;
        }

        internal object GetAll()
        {
            string sql = @"SELECT
            flight.destination,
            flight.price,
            flight.description,
            flight.category,
            flight.id FROM flight
            UNION SELECT
            ferry.destination,
            ferry.price, 
            ferry.description,
            ferry.category,
            ferry.id FROM ferry
            ";
            return _db.Query<Vacations>(sql);
        }
    }
}