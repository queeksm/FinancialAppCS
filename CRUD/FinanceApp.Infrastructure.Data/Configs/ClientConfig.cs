using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FinanceApp.Controller;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinanceApp.Infrastructure.Data.Configs
{
    class ClientConfig : IEntityTypeConfiguration<Clients>
    {
        public void Configure(EntityTypeBuilder<Clients> builder)
        {
            builder.ToTable("tblClients");
            builder.HasKey(c => c.CliId );

            builder
                .HasMany(client => client.Accounts)
                .WithOne(account => account.Client);
        }
    }
}
