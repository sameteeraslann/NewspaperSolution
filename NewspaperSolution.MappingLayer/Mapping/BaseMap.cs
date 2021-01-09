using NewspaperSolution.EntityLayer.Entites.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewspaperSolution.MappingLayer.Mapping
{
    public class BaseMap<T>:EntityTypeConfiguration<T> where T:BaseEntity
    {
        public BaseMap()
        {
            // Id Identity verildi.
            Property(x => x.Id).HasColumnName("Id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            // CreateDate Boş geçilemez olarak atandı.
            Property(x => x.CreateDate).HasColumnName("CreateDate").IsRequired();
            // Updatedate Nullable olarak atandı.
            Property(x => x.UpdateDate).HasColumnName("UpdateDate").IsOptional();
            //PassiveDate Nullable olarak atandı.
            Property(x => x.PassiveDate).HasColumnName("PassiveDate").IsOptional();
            // Status boş geçilemez olarak atandı.
            Property(x => x.Status).HasColumnName("Status").IsRequired();
        }
    }
}
