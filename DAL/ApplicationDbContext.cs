using System;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
	public class ApplicationDbContext : DbContext
	{
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=.;Database=BlazorLab;user id=sa;password=NeoFalcon13;TrustServerCertificate=True;Encrypt=False");

        //}

        public DbSet<Product> Products { get; set; }

	}
}

