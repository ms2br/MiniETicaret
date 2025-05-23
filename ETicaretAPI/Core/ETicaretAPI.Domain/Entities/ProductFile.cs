﻿using ETicaretAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Domain.Entities;

public class ProductFile
{
    public Guid ProductId { get; set; }
    public Product? Product { get; set; }

    public Guid FileId { get; set; }
    public ProductImageFile? ProductImageFile { get; set; }
}
