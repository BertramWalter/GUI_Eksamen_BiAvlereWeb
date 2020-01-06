using System;
using System.Collections.Generic;
using System.Text;
using GUI_Eksamen_BiAvlereWeb.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GUI_Eksamen_BiAvlereWeb.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<VarroaCount> VariCounts { get; set; }
    }
}
