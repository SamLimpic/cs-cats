using System;
using System.Collections.Generic;
using cs_cats.DB;
using cs_cats.Models;

namespace cs_cats.Services
{
    public class CatsService
    {
        public IEnumerable<Cat> GetAll()
        {
            return FakeDB.Cats;
            // This is the temporary placeholder before using a real DB
        }

        internal Cat GetById(string id)
        {
            Cat found = FakeDB.Cats.Find(c => c.Id == id);
            if (found == null)
            {
                throw new System.Exception("Invalid Id");
            }
            return found;
        }

        internal Cat Create(Cat newCat)
        {
            FakeDB.Cats.Add(newCat);
            return newCat;
        }

        internal Cat Edit(Cat editCat)
        {
            Cat oldCat = GetById(editCat.Id);
            // This longform method is temporary, since we only have a FakeDB
            oldCat.Name = editCat.Name;
            oldCat.Age = editCat.Age;
            oldCat.IsHungry = editCat.IsHungry;
            return oldCat;
        }

        internal void DeleteCat(string id)
        {
            Cat found = GetById(id);
            FakeDB.Cats.Remove(found);
        }
    }
}