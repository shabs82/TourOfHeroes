using System;
using System.Collections.Generic;
using System.Text;
using TourOfHeroes.Core.Entity;

namespace TourOfHeroes.Core.ApplicationServices
{
    public interface IPhotoService
    {
        Photo Create(int Id, String Name, Double Price, String Colour,String Type,DateTime DateCreated);

        Photo ReadById(int id);
        Photo Update(Photo photo);
        Photo Delete(int id);
    }
}
