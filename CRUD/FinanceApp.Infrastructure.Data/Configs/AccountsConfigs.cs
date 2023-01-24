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
    class AccountsConfigs : IEntityTypeConfiguration<Accounts>
    {
        public void Configure(EntityTypeBuilder<Accounts> builder)
        {
            builder.ToTable("tblAccounts");
            builder.HasKey(c => c.AccId);

            builder
                .HasOne(account => account.Client)
                .WithMany(client => client.Accounts);

            builder
                .HasMany(account => account.Transactions)
                .WithOne(transaction => transaction.SendingAccount);
        }
    }
}
