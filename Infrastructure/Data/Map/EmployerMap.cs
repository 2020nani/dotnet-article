using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using FirstApi.Domain.Entities;
using FirstApi.Domain.ValueObjects;

namespace FirstApi.Infrastructure.Data.Map
{
    public class EmployerMap : IEntityTypeConfiguration<Employer>
    {
        public void Configure(EntityTypeBuilder<Employer> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(255);
            builder.Property(x => x.cargo).IsRequired().HasMaxLength(255);
            builder.Property(x => x.paymentTotal).IsRequired();
            builder.ToTable("Employers")
                .OwnsOne(x => x.payment, x =>
                {
                    x.Property(a => a.salary)
                    .HasColumnName("salary")
                    .IsRequired();
                    x.Property(a => a.benefits)
                    .HasColumnName("benefits")
                    .IsRequired()
                    .HasDefaultValue(0);
                });
        }
    }
}
