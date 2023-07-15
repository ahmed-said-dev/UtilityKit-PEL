using UtilityKit.Components.Pel.Infrastrcuture;

namespace UtilityKit.Components.Pel.Infrastrcuture.Migrations.Seed.DataSeeders
{
    public class InitialDbBuilder
    {
        private readonly PelDbContext  _context;

        public InitialDbBuilder(PelDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            //new UserCreator(_context).Create();
          
            _context.SaveChanges();
        }
    }
}
