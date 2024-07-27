using Microsoft.Extensions.Logging;
using SFSAdv.Application.Abstractions.Commands;
using SFSAdv.Application.Abstractions.Persistence;
using SFSAdv.Domain.Abstractions.Exceptions;
using SFSAdv.Domain.Aggregates.OrderAggregate;
using SFSAdv.Domain.Aggregates.OrderAggregate.Entities;
using SFSAdv.Domain.Aggregates.ProductAggregate.Entities;
using SFSAdv.Domain.Aggregates.UserAggregate;

namespace SFSAdv.Application.Products.Commands.AddProduct;

internal class BuyProductCommandHandler : CommandHandler<BuyProductCommand, Guid>
{
    private readonly IProductRepository _productRepository;
    private readonly IUserRepository _userRepository;
    private readonly IOrderRepository _orderRepository;
    private readonly ILogger<BuyProductCommandHandler> _logger;

    public BuyProductCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork
                                        , ILogger<BuyProductCommandHandler> logger
                                        , IUserRepository userRepository, IOrderRepository orderRepository)
        : base(unitOfWork)
    {
        _productRepository = productRepository;
        _logger = logger;
        _userRepository = userRepository;
        _orderRepository = orderRepository;
    }

    protected override async Task<Guid> HandleAsync(BuyProductCommand request, CancellationToken cancellationToken)
    {
        var theProduct = await _productRepository.GetAsync(request.ProductId, cancellationToken);
        _ = theProduct ?? throw new NotFoundException("Product not found");

        var theUser = await _userRepository.GetAsync(request.BuyerUserId, cancellationToken);
        _ = theUser ?? throw new NotFoundException("User (Buyer) not found");

        theProduct!.ReduceInventory();
        var order = Order.CreateDefault(theProduct!, theUser!);

        await _orderRepository.AddAsync(order, cancellationToken);
        _productRepository.Update(theProduct);

        await UnitOfWork.SaveChangesAsync(cancellationToken);
        _logger.LogInformation("Order `{orderId}` created for the User `{userId}` and Product `{productId}`", order.Id, theUser!.Id, theProduct.Id);

        return order.Id;
    }
}
