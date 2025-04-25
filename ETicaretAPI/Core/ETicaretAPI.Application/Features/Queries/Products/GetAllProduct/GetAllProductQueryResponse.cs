using ETicaretAPI.Application.RequestParameters;

namespace ETicaretAPI.Application.Features.Queries.Products.GetAllProduct;

public class GetAllProductQueryResponse
{
    public object ListProduct { get; set; }
    public int TotalCount { get; set; }
}
