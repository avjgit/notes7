using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace mvc_music_store.Models
{
    public class StoreRecords : DbContext
    {
        public DbSet<Album> Albums { get; set; }
        public DbSet<Genre> Genre { get; set; }
    }
}