using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Microsoft.EntityFrameworkCore;
using FinanceApp.Controller;
using FinanceApp.Infrastructure.Data.Configs;
using Microsoft.Extensions.Configuration;


namespace FinanceApp.Infrastructure.Data.Context
{
    public class ClientContext : DbContext
    {
        public DbSet<Clients> Clients { get; set; }

        public DbSet<Accounts> Accounts { get; set; }

        public DbSet<Transactions> Transactions { get; set; }
       

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            IConfigurationBuilder configurationBuilder = new ConfigurationBuilder().AddJsonFile("appconfig.json");
            IConfiguration configuration=  configurationBuilder.Build();
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnectionString"));
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new ClientConfig());
            builder.ApplyConfiguration(new AccountsConfigs());
            builder.ApplyConfiguration(new TransactionConfigs());

        }

    }
}
