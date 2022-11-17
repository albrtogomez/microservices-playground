namespace Ordering.Application.Features.Orders.Queries;

public class GetUserOrdersQuery : IRequest<IEnumerable<OrderDto>>
{
    public string UserId { get; set; }

    public GetUserOrdersQuery(string userId)
    {
        if (string.IsNullOrEmpty(userId))
            throw new ArgumentNullException(nameof(userId));

        UserId = userId;
    }
}

public class GetBuisQueryHandler : IRequestHandler<GetUserOrdersQuery, IEnumerable<OrderDto>>
{
    private readonly IDataContext _dataContext;
    private readonly IMapper _mapper;

    public GetBuisQueryHandler(IDataContext dataContext, IMapper mapper)
    {
        _dataContext = dataContext;
        _mapper = mapper;
    }

    public async Task<IEnumerable<OrderDto>> Handle(GetUserOrdersQuery request, CancellationToken cancellationToken)
    {
        return await _dataContext.Orders
            .Where(o => o.CustomerId == request.UserId)
            .OrderByDescending(o => o.OrderId)
            .ProjectTo<OrderDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
    }
}
