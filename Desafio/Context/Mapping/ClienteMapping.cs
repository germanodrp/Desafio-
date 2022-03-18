using Desafio.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Desafio.Context.Mapping
{
    public class ClienteMapping : IEntityTypeConfiguration<Cliente>
	{
		public void Configure(EntityTypeBuilder<Cliente> builder)
		{
			

			builder.Property(c => c.Nome);
			builder.Property(c => c.Sobrenome);
			builder.Property(c => c.Cpf);
			builder.Property(c => c.DataNascimento);

			

			builder.ToTable(name: "Cliente", schema: "dbo");
		}

	}
}
