using UdemyDotNetCoreAngular.Domain;

namespace UdemyDotNetCoreAngular.DAL
{
    public class VehicleFeatureDAL
    {
        private readonly VegaDBContext db;

        public VehicleFeatureDAL(VegaDBContext db)
        {
            this.db = db;
        }
    }
}
