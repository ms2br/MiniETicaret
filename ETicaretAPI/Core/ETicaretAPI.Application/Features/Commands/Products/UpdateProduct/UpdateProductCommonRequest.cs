using ETicaretAPI.Application.Features.Commands.Products.CreateProduct;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.Commands.Products.UpdateProduct
{
    public class UpdateProductCommonRequest : IRequest
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
    }

    class UpdateProductCommonRequestValidation : AbstractValidator<UpdateProductCommonRequest>
    {
        public UpdateProductCommonRequestValidation()
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
