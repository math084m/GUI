using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ASPNET_SmartCity_MathiasThomassen_201706287.Models;

namespace ASPNET_SmartCity_MathiasThomassen_201706287.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ASPNET_SmartCity_MathiasThomassen_201706287.Models.Sensor> Sensor { get; set; }
    }
}
