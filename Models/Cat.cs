using System;
using System.ComponentModel.DataAnnotations;

namespace cs_cats.Models
{
    public class Cat
    {
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Range(0, int.MaxValue)]
        public int Age { get; set; }


        public bool IsHungry { get; set; } = true;
        // sets "true" as the default value


        public Cat(string name, int age, bool isHungry)
        {
            Id = Guid.NewGuid().ToString();
            // This is temporary, the DB will establish an Id automatically later on
            Name = name;
            Age = age;
            IsHungry = isHungry;
        }
    }
}