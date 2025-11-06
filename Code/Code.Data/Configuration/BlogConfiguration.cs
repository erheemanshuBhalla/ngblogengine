using Code.Domain.Entities;
using Code.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Data.Configuration
{
    public class BlogConfiguration : EntityTypeConfiguration<Blogmodel>
    {
        public BlogConfiguration()
        {
            ToTable("Article");
            Property(a => a.Title).IsRequired().HasMaxLength(100);
            Property(a => a.Description).IsRequired();
           
        }
    }
}
