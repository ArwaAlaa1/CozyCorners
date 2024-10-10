using CozyCorners.Core.Models.Order;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CozyCorners.Repository.Data.Configurations
{
	internal class OrderConfigurations : IEntityTypeConfiguration<Order>
	{
		public void Configure(EntityTypeBuilder<Order> builder)
		{
			builder.OwnsOne(Order => Order.AddressShipping, AddressShipping => AddressShipping.WithOwner());

			builder.Property(s => s.Status)
				 .HasConversion(
				     os => os.ToString(),
					 os=>(OrderStatus)Enum.Parse(typeof(OrderStatus),os)
				 
				 );

			builder.Property(st => st.SubTotal)
				.HasColumnType("decimal(18,2)");

			builder.HasOne(o => o.DeliveryMethod).WithMany()
				.OnDelete(DeleteBehavior.SetNull);
		}
	}
}
