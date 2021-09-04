using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Login.Models
{
    public class ContextDB : DbContext
    {
        public DbSet<UserModel> user { set; get; }
        public DbSet<MessageFormModel> message { set; get; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-LRDEE5N\\MSS;Database=myDataBase;Trusted_Connection=True;");
        }
        string strConnection;
        public ContextDB(string strConnection)
        {
            this.strConnection = strConnection;
        }
    }
}
