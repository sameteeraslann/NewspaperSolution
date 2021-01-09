using NewspaperSolution.EntityLayer.Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewspaperSolution.MappingLayer.Mapping
{
    public class AppUserMap: BaseMap<AppUser>
    {
        public AppUserMap()
        {
            Property(x => x.FirstName).HasMaxLength(20).HasColumnName("First Name").IsRequired();
            Property(x => x.LastName).HasMaxLength(15).HasColumnName("Last Name").IsRequired();
            Property(x => x.UserName).HasMaxLength(10).HasColumnName("User Name").IsRequired();
            Property(x => x.Password).HasMaxLength(13).HasColumnName("Password").IsRequired();
            Property(x => x.Role).HasColumnName("Role").IsRequired();

            HasMany(x => x.Posts)
                .WithRequired(x => x.AppUser)
                .HasForeignKey(x => x.AppUserId)
                .WillCascadeOnDelete(false); //Database ile kendi oluşturduğumuz mapping arasında çatışma yaşanmaması için kullanılmıştır.

            HasMany(x => x.Comments)
                .WithRequired(x => x.AppUser)
                .HasForeignKey(x => x.AppUserId)
                .WillCascadeOnDelete(false);

        }
    }
}
