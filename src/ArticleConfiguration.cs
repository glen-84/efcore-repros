using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api;

public sealed class ArticleConfiguration : IEntityTypeConfiguration<Article>
{
    public void Configure(EntityTypeBuilder<Article> builder)
    {
        // Table.

        builder.ToTable("articles");

        // Properties.

        builder
            .Property(a => a.Title)
            .HasConversion(
                x => x.Value,
                x => ArticleTitle.From(x))
            .HasMaxLength(100);
    }
}
