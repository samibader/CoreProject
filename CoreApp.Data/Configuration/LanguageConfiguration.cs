using CoreApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreApp.Data.Configuration
{
    internal class LanguageConfiguration : EntityTypeConfiguration<Language>
    {
        internal LanguageConfiguration()
        {
            ToTable("Language");
         

            HasKey(x => x.Id)
                .Property(x => x.Id)
                .HasColumnName("Id")
                .HasColumnType("int")
                .IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Code)
                .HasColumnName("Code")
                .HasColumnType("nvarchar")
                .HasMaxLength(2)
                .IsRequired();

            Property(x => x.ArabicName)
                .HasColumnName("ArabicName")
                .HasColumnType("nvarchar")
                .HasMaxLength(100)
                .IsRequired();

            Property(x => x.EnglishName)
                .HasColumnName("EnglishName")
                .HasColumnType("nvarchar")
                .HasMaxLength(100)
                .IsRequired();

        }
    }
}
