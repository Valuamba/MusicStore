using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicStore.Models
{
    public class MusicStoreEntities : DbContext
    {
        public DbSet<Album> Album { get; set; }
        public DbSet<Genre> Genre { get; set; }
        public DbSet<Artist> Artist { get; set; }
        public DbSet<ChangePasswordModel> ChangePassword { get; set; }
        public DbSet<LogOnModel> Logons { get; set; }
        public DbSet<RegisterModel> Register { get; set; }
        public DbSet<Peoples> Peoples { get; set; }
        public DbSet<States> States { get; set; }

        public MusicStoreEntities(DbContextOptions<MusicStoreEntities> options) : base(options)
        {
        }

    }
}
