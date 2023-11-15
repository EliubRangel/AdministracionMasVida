using System;
using AdministracionMasVidaDbContext.Entities;
using Microsoft.EntityFrameworkCore;

namespace AdministracionMasVidaDbContext.DbContexts
{
    public class AdministracionMasVidaDbcontext : DbContext
    {
        public DbSet<GrupoPequeno> GrupoPequeno { get; set; }
        public DbSet<Mentor> Mentor { get; set; }
        public DbSet<Miembro> Miembro { get; set; }
        public DbSet<Servidor> Servidor { get; set; }


        public AdministracionMasVidaDbcontext(DbContextOptions<AdministracionMasVidaDbcontext> options)
         : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var constr = "server=localhost;database=AdministracionMasVidaDbcontext ;uid=root;pwd=pwd123;port=3306;";
            optionsBuilder.UseMySql(constr, ServerVersion.AutoDetect(constr));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<GrupoPequeno>()
                .HasMany<Servidor>(x => x.Lideres)
                .WithOne(x => x.LiderGrupo);
        }

    }
}

