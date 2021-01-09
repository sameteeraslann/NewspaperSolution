using NewspaperSolution.EntityLayer.Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewspaperSolution.MappingLayer.Mapping
{
    public class CategoryMap:BaseMap<Category>
    {
        public CategoryMap()
        {
            Property(x => x.Name).HasMaxLength(15).HasColumnName("Category Name").IsRequired();

            HasMany(x => x.Posts)
                .WithRequired(x => x.Category)
                .HasForeignKey(x => x.CategoryId)
                .WillCascadeOnDelete(false);
        }
    }
}
