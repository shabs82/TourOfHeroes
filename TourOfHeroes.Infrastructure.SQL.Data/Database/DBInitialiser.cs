using System;
using System.Collections.Generic;
using System.Text;
using TourOfHeroes.Core.Entity;
using TourOfHeroes.Infrastructure.SQL.Data.Database;

namespace TourOfHeroes.Infrastructure.SQL.Data
{
    public class DBInitialiser : IDBInitialiser
    {
        public void Seed(PhotoDBContext context)
        {
           Photo pic1 = new Photo()
            {
                Name = "Italia",
                Colour = " Grey",
                Price = 55,
                DateCreated = DateTime.Parse("2018-11-29"),
                Type = "Portrait",
              
            };
           context.Photo.Add(pic1);
           context.SaveChanges();
        }
    }
}
