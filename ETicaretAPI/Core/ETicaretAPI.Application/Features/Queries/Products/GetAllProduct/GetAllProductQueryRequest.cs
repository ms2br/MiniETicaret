using ETicaretAPI.Application.RequestParameters;
using MediatR;


namespace ETicaretAPI.Application.Features.Queries.Products.GetAllProduct;

public class GetAllProductQueryRequest : IRequest<GetAllProductQueryResponse>
{
    public Pagination? pagination { get; set; }
}
