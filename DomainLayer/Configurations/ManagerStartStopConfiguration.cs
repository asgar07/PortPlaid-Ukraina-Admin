using DomainLayer.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Configurations
{
    public class ManagerStartStopConfiguration : IEntityTypeConfiguration<ManagerStartStop>
    {
        public void Configure(EntityTypeBuilder<ManagerStartStop> builder)
        {
            //builder.Property(m => m.Name).IsRequired();
        }
    }
}
