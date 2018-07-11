using ContextPizza;
using PizzaLibrary.Classes;
using System;
using System.Collections.Generic;
using PizzaLibrary;

namespace pizzalibrary
{
    public class pizzarepository
    {
        private readonly pizzadatabaseContext _db;


        public pizzarepository(pizzadatabaseContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public pizzarepository()
        {
        }

        public string findnamewithid(int userid)
        {
            var users = _db.User;
            foreach (var user in users)
            {
                if (user.UserId == userid)
                {
                    return user.Firstname + user.Lastname;
                }
            }
            return "user not found";

        }

        public int findidwithname(string fn, string ln)
        {
            var users = _db.User;
            foreach (var user in users)
            {
                if ((user.Firstname == fn && user.Lastname == ln))
                {
                    return user.UserId;
                }
            }
            return -1;
        }

        public void useradd(PizzaLibrary.Classes.User user)
        {

            _db.Add(Mapper.Map(user));

        }

        public void addorder(PizzaLibrary.Classes.Order order)
        {
            _db.Add(Mapper.Map(order));
        }


        public void save()
        {
            _db.SaveChanges();
        }

    }
}

