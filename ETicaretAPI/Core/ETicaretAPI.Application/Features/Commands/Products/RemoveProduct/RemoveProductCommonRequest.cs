﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.Commands.Products.RemoveProduct
{
    public class RemoveProductCommonRequest : IRequest
    {
        public string  Id { get; set; }
    }
}
