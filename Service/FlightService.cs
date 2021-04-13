using System;
using System.Collections.Generic;
using Models;
using Repository;

namespace Service
{
    public class FlightService
    {
        private readonly FlightRepo _repo;

        public FlightService(FlightRepo repo)
        {
            _repo = repo;
        }

        internal IEnumerable<Flight> GetAll()
        {
            return _repo.GetAll();
        }

        internal Flight Get(int id)
        {
            Flight flight = _repo.Get(id);
            if (flight == null)
            {
                throw new Exception("invalid id");
            }
            return flight;
        }

        internal Flight Create(Flight newFlight)
        {
            return _repo.Create(newFlight);
        }

        internal string Delete(int id)
        {
            Flight original = Get(id);
            _repo.Delete(id);
            return "Successfully Deleted";
        }

        internal Flight Edit(Flight updated)
        {
            Flight data = Get(updated.Id);

            data.Destination = updated.Destination != null ? updated.Destination : data.Destination;
            data.Description = updated.Description != null ? updated.Description : data.Description;
            data.Price = updated.Price;
            data.Category = updated.Category != null ? updated.Category : data.Category;


            return _repo.Edit(data);
        }
    }
}