using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.Commands.ProductFiles.CreateProductFile
{
    public class CreateProductFileCommonRequest : IRequest
    {
        public string  ProductId { get; set; }
    }
}
