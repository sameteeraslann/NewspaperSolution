using NewspaperSolution.EntityLayer.Entites.Concrete;

namespace NewspaperSolution.MappingLayer.Mapping
{
    public class PostMap:BaseMap<Post>
    {
        public PostMap()
        {
            Property(x => x.Header).HasColumnName("Header").HasMaxLength(100).IsRequired();
            Property(x => x.Content).HasMaxLength(500).HasColumnName("Content").IsRequired();

            HasRequired(x => x.AppUser)
                .WithMany(x => x.Posts)
                .HasForeignKey(x => x.AppUserId)
                .WillCascadeOnDelete(false);

            HasRequired(x => x.Category)
                .WithMany(x => x.Posts)
                .HasForeignKey(x => x.CategoryId)
                .WillCascadeOnDelete(false);

            HasMany(x => x.Comments)
                .WithRequired(x => x.Post)
                .HasForeignKey(x => x.PostId)
                .WillCascadeOnDelete(false);
           
        }
    }
}
