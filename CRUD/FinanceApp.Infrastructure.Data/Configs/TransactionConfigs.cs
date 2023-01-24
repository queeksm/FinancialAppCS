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
    internal class TransactionConfigs : IEntityTypeConfiguration<Transactions>
    {
        public void Configure(EntityTypeBuilder<Transactions> builder)
        {
            builder.ToTable("tblTransactions");
            builder.HasKey(c => c.Id);

            builder
                .HasOne(transaction => transaction.SendingAccount)
                .WithMany(account => account.Transactions);
        }
    }
}
