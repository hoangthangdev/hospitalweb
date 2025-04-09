using BuildingCore.Data.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingCore.Data
{
    public class HospitalDbContext : IdentityDbContext <User>, IApplicationDbContext
    {
        public HospitalDbContext(DbContextOptions<HospitalDbContext> options)
        : base(options)
        {
        }
        public DbSet<CustomerModel> Customers { get; } = null!;

        public DbSet<User> Users { get; }

        public DbSet<Doctor> Doctors { get; }

        public DbSet<Patient> Patients { get; }
    }
}
