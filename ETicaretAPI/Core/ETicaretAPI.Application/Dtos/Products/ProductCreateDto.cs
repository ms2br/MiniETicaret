using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Dtos.Products
{
    public class ProductCreateDto
    {
        public string Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
    }

    public class ProductCreateDtoValidation : AbstractValidator<ProductCreateDto>
    {
        public ProductCreateDtoValidation()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull()
                .MaximumLength(150)
                .MinimumLength(3);

            RuleFor(x => x.Price)
                .NotNull()
                .NotEmpty()
                .Must(x => x > 0);

            RuleFor(x => x.Stock)
                .NotEmpty()
                .NotNull()
                .Must(x => x > 0);
        }
    }
}
