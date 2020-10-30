using System;
using System.Collections.Generic;
using System.Text;
using TourOfHeroes.Core.DomainServices;
using TourOfHeroes.Core.Entity;

namespace TourOfHeroes.Core.ApplicationServices.Services
{
    public class PhotoService : IPhotoService
    {
        private readonly IPhotoRepository _photoRepository;// initialising the variable

        public PhotoService(IPhotoRepository photoRepository)
        {
            _photoRepository = photoRepository;//assigning the variable
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
