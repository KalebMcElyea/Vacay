using System;
using Repository;

namespace Service
{
    public class VacationService
    {
        private readonly VacationRepo _repo;

        public VacationService(VacationRepo repo)
        {
            _repo = repo;
        }

        internal object getAll()
        {
            var data = _repo.GetAll();
            return data;
        }
    }
}