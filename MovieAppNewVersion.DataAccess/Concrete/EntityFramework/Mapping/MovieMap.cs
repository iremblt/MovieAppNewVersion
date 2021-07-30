using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieAppNewVersion.Entities.Concrete;

namespace MovieAppNewVersion.DataAccess.Concrete.EntityFramework.Mapping
{
    public class MovieMap : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.HasKey(m => m.MovieId);
            builder.Property(m => m.MovieTitle).IsRequired();
            builder.Property(m => m.MovieTitle).HasMaxLength(50);
            builder.Property(m => m.MovieDescription).IsRequired();
        }
    }
}
