using DataLayer.Entities;
using DataLayer.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataLayer.ModelConfigurations;

public class ExpensesConf:IEntityTypeConfiguration<Expenses>
{
    public void Configure(EntityTypeBuilder<Expenses> builder)
    {
        builder.Property(e=>e.Koe).HasConversion(kindOfExpenses => kindOfExpenses.ToString(),
            empGender=>(KindOfExpenses)Enum.Parse(typeof(KindOfExpenses), empGender));
    }
}