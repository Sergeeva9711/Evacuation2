﻿using Evacuation.Dal.Context;
using Evacuation.Dal.Entities;
using Evacuation.Dal.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evacuation.Dal.Repositories
{
    class UserRepository : IRepository<User>
    {
        private UserContext db;

        public UserRepository(UserContext context)
        {
            db = context;
        }

        public void Create(User item)
        {
            db.Users.Add(item);
        }

        public void Delete(User item)
        {
            var us = db.Users.Find(item.UserID);
            if(us!=null)
                db.Users.Remove(us);
        }

        public IEnumerable<User> Find(Func<User, bool> predicate)
        {
            return db.Users.Where(predicate).ToList();
        }

        public User Get(int id)
        {
            return db.Users.Find(id);
        }

        public IEnumerable<User> GetAll()
        {
            return db.Users;
        }

        public void Update(User item)
        {            
            var us = db.Users.Find(item.UserID);
            db.Entry(us).CurrentValues.SetValues(item);
        }
    }
}