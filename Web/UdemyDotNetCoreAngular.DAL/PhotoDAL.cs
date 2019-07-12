using UdemyDotNetCoreAngular.Domain;
using UdemyDotNetCoreAngular.Domain.Models;

namespace UdemyDotNetCoreAngular.DAL
{
    public class PhotoDAL : IPhotoDAL
    {
        private readonly VegaDBContext db;

        public PhotoDAL(VegaDBContext db)
        {
            this.db = db;
        }

        public void AddVehicle(Photo photo)
        {
            db.Photos.Add(photo);
        }
    }
}
