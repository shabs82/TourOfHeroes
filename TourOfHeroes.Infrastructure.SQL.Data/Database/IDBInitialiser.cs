using System;
using System.Collections.Generic;
using System.Text;
using TourOfHeroes.Infrastructure.SQL.Data.Database;

namespace TourOfHeroes.Infrastructure.SQL.Data
{
    public interface IDBInitialiser
    {
        void Seed(PhotoDBContext context);
    }
}
