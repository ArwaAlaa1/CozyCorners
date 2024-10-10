using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CozyCorners.Core.Models.Order
{
	public enum OrderStatus
	{
		[EnumMember(Value ="Pending")]
		Pending,
		[EnumMember(Value = "Processing")]
		Processing,
		[EnumMember(Value = "Shipped")]
		Shipped,
		[EnumMember(Value = "Cancelled")]
		Cancelled,
		[EnumMember(Value = "Deliverd")]
		Deliverd,
		[EnumMember(Value = "PaymentSucceded")]
		PaymentSucceded,
		[EnumMember(Value = "PaymentFailed")]
		PaymentFailed,
	}
}
