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
	internal class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
	{
		public void Configure(EntityTypeBuilder<OrderItem> builder)
		{
			builder.OwnsOne(orderitem => orderitem.Product, Product => Product.WithOwner());

			builder.Property(OPrice=>OPrice.PriceAtPurchase)
				.HasColumnType("decimal(18,2)");
		}
	}
}
