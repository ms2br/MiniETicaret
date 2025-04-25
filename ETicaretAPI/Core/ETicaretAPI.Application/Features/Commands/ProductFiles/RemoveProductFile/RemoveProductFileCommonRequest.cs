using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.Commands.ProductFiles.RemoveProductFile
{
    public class RemoveProductFileCommonRequest : IRequest
    {
        public string ProductId { get; set; }
        public string ImageId { get; set; }
    }
}
