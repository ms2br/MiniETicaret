using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.Queries.ProductFiles
{
    public class GetProductFileQueryRequest : IRequest<GetProductFileQueryResponse>
    {
        public string ProductId { get; set; }
    }
}
