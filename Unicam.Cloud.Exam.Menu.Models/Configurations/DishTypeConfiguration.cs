
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicam.Cloud.Exam.Menu.Models.Entities;

namespace Unicam.Cloud.Exam.Menu.Models.Configurations {
    public class DishTypeConfiguration : IEntityTypeConfiguration<DishType> {
        public void Configure(EntityTypeBuilder<DishType> builder) {
            builder.ToTable("DishType");
            builder.HasKey(d => d.Id);
            builder.Property(d => d.Typology)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
