﻿using UtilityKit.Components.Pel.Infrastrcuture;

namespace UtilityKit.Components.Atl.Infrastrcuture.Migrations.Seed.DataSeeders

{
    public class UserCreator
    {
        private readonly PelDbContext _aTLDbContext;

        public UserCreator(PelDbContext aTLDbContext)
        {
            _aTLDbContext = aTLDbContext;
        }

        public void Create()
        {
            //if (_aTLDbContext.Database.EnsureCreated())
            //{
            //    var user = _aTLDbContext.Users.FirstOrDefault(u => u.Name == "admin");
            //    if (user == null)
            //    {
            //        _aTLDbContext.Users.Add(new User { Id = Guid.NewGuid(), Name = "admin" });
            //    }

            //    _aTLDbContext.SaveChanges();
            //}

        }

    }
}
