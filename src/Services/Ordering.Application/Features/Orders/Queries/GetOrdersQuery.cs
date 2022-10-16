namespace Ordering.Application.Features.Orders.Queries;

public class GetOrdersQuery : IRequest<IEnumerable<OrderDto>>
{
}

public class GetBuisQueryHandler : IRequestHandler<GetOrdersQuery, IEnumerable<OrderDto>>
{
    private readonly IDataContext _dataContext;
    private readonly IMapper _mapper;

    public GetBuisQueryHandler(IDataContext dataContext, IMapper mapper)
    {
        _dataContext = dataContext;
        _mapper = mapper;
    }

    public async Task<IEnumerable<OrderDto>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
    {
        return await _dataContext.Orders
            .ProjectTo<OrderDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
    }
}
