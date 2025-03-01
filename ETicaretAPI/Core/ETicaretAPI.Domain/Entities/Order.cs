using ETicaretAPI.Domain.Entities.Common;
using ETicaretAPI.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Domain.Entities
{
    public class Order : BaseEntity
    {
        public string Description { get; set; }
        public Guid CustomerId { get; set; }
        public Customer? Customer { get; set; }
        public Address? Address { get; set; }
        public ICollection<ProductOrder>? Products { get; set; }
        public DateTime DeliveryDate { get; set; }
    }
}
