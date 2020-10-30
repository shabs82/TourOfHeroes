using System;
using System.Collections.Generic;
using System.Text;
using TourOfHeroes.Core.Entity;

namespace TourOfHeroes.Core.DomainServices
{
    public interface IPhotoRepository
    {
        Photo Create(int Id, String Name, Double Price, String Colour, String Type, DateTime DateCreated);

        Photo ReadById(int id);

        List<Photo> ReadAllPhoto();
        Photo Update(Photo photo);
        Photo Delete(int id);
    }
}
