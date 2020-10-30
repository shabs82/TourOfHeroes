using System;
using System.Collections.Generic;
using System.Text;
using TourOfHeroes.Core.DomainServices;
using TourOfHeroes.Core.Entity;
using TourOfHeroes.Infrastructure.SQL.Data.Database;

namespace TourOfHeroes.Infrastructure.SQL.Data.Repositories
{
    public class PhotoRepository : IPhotoRepository
    {
        private PhotoDBContext _context;

        public PhotoRepository(PhotoDBContext context)
        {
            _context = context;
        }
        public Photo Create(int Id, string Name, double Price, string Colour, string Type, DateTime DateCreated)
        {
            throw new NotImplementedException();
        }

        public Photo Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Photo> ReadAllPhoto()
        {
            throw new NotImplementedException();
        }

        public Photo ReadById(int id)
        {
            throw new NotImplementedException();
        }

        public Photo Update(Photo photo)
        {
            throw new NotImplementedException();
        }
    }
}
