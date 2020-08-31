using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VoterProjectRegister.Models;

namespace VoterProjectRegister.Data
{
    public class VoterDBContext : IdentityDbContext
    {
        public VoterDBContext(DbContextOptions<VoterDBContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<Poll> Polls { get; set; }
        public DbSet<Choice> Choices { get; set; }
        public DbSet<OneTimeCode> OneTimeCodes { get; set; }


    }
}
