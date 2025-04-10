using BuildingBlocks.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Domain.Repository
{
    public interface IOrderDetailRepository : IRepository<Domain.Entities.OrderDetail>
    {
    }
}
