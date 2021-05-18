using System.Collections.Generic;
using cs_cats.Models;

namespace cs_cats.DB
{
    public static class FakeDB
    {
        public static List<Cat> Cats { get; set; } = new List<Cat>()
        {
            new Cat("Phteven", 7, false)
        };
    }
}