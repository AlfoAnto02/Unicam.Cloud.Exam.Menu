using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;
using Unicam.Cloud.Exam.Menu.Models.Entities;

namespace Unicam.Cloud.Exam.Menu.Models.Configurations {
    public class DishConfiguration : IEntityTypeConfiguration<Dish>{
        public void Configure(EntityTypeBuilder<Dish> builder) {
            builder.ToTable("Dish");
            builder.HasKey(d => d.Id);
            builder.Property(d => d.Name)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(d => d.Price).IsRequired();
            builder.HasOne(d => d.Type)
                .WithMany(p => p.Dishes)
                .HasForeignKey(d => d.TypeId);
        }
    }
}
