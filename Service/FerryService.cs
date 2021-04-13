using System;
using System.Collections.Generic;
using Models;
using Repository;

namespace Service
{
    public class FerryService
    {
        private readonly FerryRepo _repo;

        public FerryService(FerryRepo repo)
        {
            _repo = repo;
        }

        internal IEnumerable<Ferry> GetAll()
        {
            return _repo.GetAll();
        }
    }
}