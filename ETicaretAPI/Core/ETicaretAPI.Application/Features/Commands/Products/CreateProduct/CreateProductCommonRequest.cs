using ETicaretAPI.Application.Dtos.Products;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.Commands.Products.CreateProduct
{
    public class CreateProductCommonRequest : IRequest
    {
        public string Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
    }

    class CreateProductCommonRequestValidation : AbstractValidator<CreateProductCommonRequest>
    {
        public CreateProductCommonRequestValidation()
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
