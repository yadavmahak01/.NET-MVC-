﻿using DomainClasses;
using System.Data.Entity;

namespace NinjaDomain.DataModel
{
    public class NinjaContext : DbContext
    {
        public DbSet<Ninja> Ninjas { get; set; }
        public DbSet<Clan> Clans { get; set; }
        public DbSet<NinjaEquipment> Eqipment {get;set;}
}
}