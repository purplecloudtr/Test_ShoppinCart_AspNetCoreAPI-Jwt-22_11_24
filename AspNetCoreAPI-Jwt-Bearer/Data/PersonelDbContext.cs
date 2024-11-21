using AspNetCoreAPI_Jwt_Bearer.Entities;
using Microsoft.EntityFrameworkCore;


namespace AspNetCoreAPI_Jwt_Bearer.Data
{
    public class PersonelDbContext : DbContext
    {
        public PersonelDbContext(DbContextOptions<PersonelDbContext> options) : base(options)
        {  }

        public DbSet<Employee> Employees { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)

        {
            //Fluent API

            //Seed Data
            modelBuilder.Entity<Employee>().HasData(
                    new Employee() { Id = 1, FirstName = "Ali", LastName = "Uçar", Phone = "543 345 66 77", Email = "aliucar@gmail.com"},
                    new Employee() { Id = 2, FirstName = "Oya", LastName = "Koşar", Phone = "533 345 22 44", Email = "oyakosar@gmail.com" },
                    new Employee() { Id = 3, FirstName = "Zeynep", LastName = "Sever", Phone = "532 145 33 77", Email = "zeynep@gmail.com" },
                    new Employee() { Id = 4, FirstName = "Hasan", LastName = "Kaya", Phone = "545 345 11 22", Email = "hasan@gmail.com" }
                );
            base.OnModelCreating(modelBuilder);
        }      
            
       

    }
}
