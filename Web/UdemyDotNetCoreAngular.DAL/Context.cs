using UdemyDotNetCoreAngular.Domain;

namespace UdemyDotNetCoreAngular.DAL
{
    public class Context : IContext
    {
        private readonly VegaDBContext db;

        public Context(VegaDBContext db)
        {
            this.db = db;
        }
        public void CompleteChanges()
        {
            db.SaveChanges();
        }
    }
}
