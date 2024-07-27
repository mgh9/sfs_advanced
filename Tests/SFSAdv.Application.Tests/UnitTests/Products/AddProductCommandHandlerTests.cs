using Microsoft.Extensions.Logging;
using Moq;
using SFSAdv.Application.Abstractions.Persistence;
using SFSAdv.Application.Products.Commands.AddProduct;
using SFSAdv.Domain.Abstractions.Exceptions;
using SFSAdv.Domain.Aggregates.ProductAggregate.Entities;
using SFSAdv.Domain.Aggregates.ProductAggregate.Services;

namespace SFSAdv.Application.Tests.UnitTests.Products;

public class AddProductCommandHandlerTests
{
    private readonly Mock<IProductRepository> _mockProductRepository;
    private readonly Mock<IProductService> _mockProductService;
    private readonly Mock<IUnitOfWork> _mockUnitOfWork;
    private readonly Mock<ILogger<AddProductCommandHandler>> _mockLogger;
    private readonly AddProductCommandHandler _handler;

    public AddProductCommandHandlerTests()
    {
        _mockProductRepository = new();
        _mockUnitOfWork = new();
        _mockProductService = new();
        _mockLogger = new Mock<ILogger<AddProductCommandHandler>>();
        _handler = new AddProductCommandHandler(_mockProductRepository.Object, _mockUnitOfWork.Object, _mockLogger.Object, _mockProductService.Object);

        _mockUnitOfWork.Setup(uow => uow.SaveChangesAsync(It.IsAny<CancellationToken>()))
                        .Returns(Task.FromResult(1));
    }

    [Fact]
    public async Task Handle_ShouldThrowDomainValidationException_WhenTitleIsTooLongAsync()
    {
        // Arrange
        var command = new AddProductCommand(new string('x', 41), 1, 1, 1);

        _mockProductRepository
                        .Setup(repo => repo.AddAsync(It.IsAny<Product>(), It.IsAny<CancellationToken>()))
                        .Returns(Task.CompletedTask);

        // Act
        var ex = await Assert.ThrowsAsync<DomainValidationException>(async () => await _handler.Handle(command, default));

        // Assert
        Assert.Equal("Product title must be less than 40 characters", ex.Message);
    }

    [Fact]
    public async Task Handle_ShouldAddProductSuccessfully_WhenDataIsValidAsync()
    {
        // Arrange
        var command = new AddProductCommand("valid title", 1, 1, 1);

        _mockProductService
                 .Setup(service => service.EnsureProductTitleIsUniqueAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
                 .Returns(Task.CompletedTask);

        _mockProductRepository
                .Setup(repo => repo.AddAsync(It.IsAny<Product>(), It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);

        // Act
        var result = await _handler.Handle(command, default);

        // Assert
        Assert.True(result != Guid.Empty);
    }
}
