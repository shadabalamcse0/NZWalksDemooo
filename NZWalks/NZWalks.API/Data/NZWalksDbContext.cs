using Microsoft.EntityFrameworkCore;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Data
{
    public class NZWalksDbContext :DbContext
    {
        public NZWalksDbContext(DbContextOptions  dbContextOptions):  base(dbContextOptions)
        {

            
        }

        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //seed datafor diffulties 
            //Easy , Medium , Hard

            var difficulties = new List<Difficulty>()
            {
                new Difficulty()
                {
                    Id = Guid.Parse("f531e97a-4768-48d4-9fa7-e9efc6de70d7"),
                    Name = "Easy"
                },

                new Difficulty()
                {
                    Id= Guid.Parse("d228706e-d4ef-4d84-9e62-caf3a60178cb"),
                    Name ="Medium"
                },

                new Difficulty ()
                {
                    Id =Guid.Parse("b117a07c-6b9c-4207-9720-ba5142c3c587"),
                    Name ="Hard"
                },
               
            };
            //seed difficulties to the database
            modelBuilder.Entity<Difficulty>().HasData(difficulties);

            //seed data for regions
            var regions = new List<Region>
            {
                new Region()
                {
                    Id=Guid.Parse("f1c1bd1f-f7c0-4a8e-b3d2-ae03b71c5895"),
                    Name = "Auckland",
                    Code =  "AKL",
                    RegionImageUrl=" aucklandseaimage.jpg"
                },

                new Region()
                {
                    Id =Guid.Parse("5f2cb01e-9a47-4753-b6c7-1d4025ab83a4"),
                    Name ="Northland",
                    Code  = "NTL",
                    RegionImageUrl = null
                },

                new Region ()
                {
                    Id = Guid.Parse("4d382db1-36fe-41fe-b3f9-3b3290334080"),
                    Name =  "Boy of Plenty",
                    Code = "BOP",
                    RegionImageUrl =  null
                },

                new Region()
                {
                    Id = Guid.Parse("7b4b1dd9-3e7c-4038-8859-f0acf84350e4"),
                    Name ="Wellington",
                    Code = "WGN",
                    RegionImageUrl ="wellingtonimage.jpg"
                },

                new Region ()
                {
                    Id=Guid.Parse("eb86604d-bb3a-4fab-a03a-80008de50949"),
                    Name = "Nelson",
                    Code = "NSN",
                    RegionImageUrl="nelsonimage.jpg"

                },

                new Region()
                {
                    Id = Guid.Parse("4b5f3ebc-9101-4528-ada9-06fb9d410916"),
                    Name ="SouthLand",
                    Code ="STL",
                    RegionImageUrl = null
                },

            };

            //seed  data for regions
            modelBuilder.Entity<Region>().HasData(regions);

        }
    }
}
