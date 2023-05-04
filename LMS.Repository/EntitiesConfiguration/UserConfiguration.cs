using LMS.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Repository.EntitiesConfiguration {
    public class UserConfiguration : IEntityTypeConfiguration<User> {
        public void Configure(EntityTypeBuilder<User> builder) {

            builder.ToTable("ent_user");

            builder.HasKey(x => x.Id);

            builder.HasIndex(x => x.Login).IsUnique();
            builder.HasIndex(x => x.Email).IsUnique();

            builder.Property(x => x.Login).HasMaxLength(32);
            builder.Property(x => x.Name).HasMaxLength(120);
            builder.Property(x => x.Email).HasMaxLength(70);
            builder.Property(x => x.Password).HasMaxLength(32);

        }
    }
}
