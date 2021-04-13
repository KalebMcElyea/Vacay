using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using Models;

namespace Repository
{
    public class FlightRepo
    {
        public readonly IDbConnection _db;

        public FlightRepo(IDbConnection db)
        {
            _db = db;
        }

        internal IEnumerable<Flight> GetAll()
        {
            string sql = "SELECT * FROM flight;";
            return _db.Query<Flight>(sql);
        }

        internal Flight Get(int id)
        {
            string sql = "SELECT * FROM flight WHERE id = @Id;";
            return _db.QueryFirstOrDefault<Flight>(sql, new { id });
        }

        internal Flight Create(Flight newFlight)
        {
            string sql = @"
      INSERT INTO flight
      (destination, description, price, category)
      VALUES
      (@Destination, @Description, @Price, @Category);
      SELECT LAST_INSERT_ID();";
            int id = _db.ExecuteScalar<int>(sql, newFlight);
            newFlight.Id = id;
            return newFlight;
        }


        internal void Delete(int id)
        {
            string sql = "DELETE FROM flight WHERE id = @id;";
            _db.Execute(sql, new { id });
            return;
        }

        internal Flight Edit(Flight updated)
        {
            string sql = @"
      UPDATE flight
      SET
        description = @Description,
        price = @Price,
        destination = @Destination,
        category = @Category
      WHERE id = @Id;
      SELECT * FROM flight WHERE id = @Id;";
            return _db.QueryFirstOrDefault<Flight>(sql, updated);

        }
    }
}