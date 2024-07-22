using FirstApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FirstApi.Infrastructure.Data.Map
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
        builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Email).IsRequired();
            builder.Property(x => x.Password).IsRequired();
            builder.ToTable("Users")
                .OwnsOne(x => x.Endereco, x =>
                {
                    x.Property(a => a.Unidade)
                    .HasColumnName("unidade")
                    .IsRequired();
                    x.Property(a => a.Complemento)
                    .HasColumnName("complemento")
                    .IsRequired();
                    x.Property(a => a.Cep)
                    .HasColumnName("cep")
                    .IsRequired();
                    x.Property(a => a.Bairro)
                    .HasColumnName("bairro")
                    .IsRequired();
                    x.Property(a => a.Logradouro)
                    .HasColumnName("logradouro")
                    .IsRequired();
                    x.Property(a => a.Uf)
                    .HasColumnName("uf")
                    .IsRequired();
                    x.Property(a => a.Localidade)
                    .HasColumnName("localidade")
                    .IsRequired();
                });
        }
    }
}
