using System;
using System.Collections.Generic;
using ContextPizza;


namespace PizzaLibrary
{
    public class PizzaRepository
    {
        private readonly pizzadatabaseContext _db;


        public PizzaRepository(pizzadatabaseContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public IEnumerable<pizzadatabaseContext> GetDatabase()
        {
            return null;
            // disable pointless tracking for performance
           // return Mapper.Map(_db.Restaurant.Include(r => r.Review).AsNoTracking());
        }


        public void Save()
        {
            _db.SaveChanges();
        }
    }
}

