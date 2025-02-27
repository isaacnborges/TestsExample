﻿using System.Linq;
using System.Threading;
using Features.Clientes;
using MediatR;
using Moq;
using Xunit;

namespace Features.Tests
{
    [Collection(nameof(ClienteAutoMockerCollection))]
    public class ClienteServiceAutoMockerFixtureTests
    {
        readonly ClienteTestsAutoMockerFixture _clienteTestsAutoMockerFixture;

        private readonly CustomerService _clienteService;

        public ClienteServiceAutoMockerFixtureTests(ClienteTestsAutoMockerFixture clienteTestsFixture)
        {
            _clienteTestsAutoMockerFixture = clienteTestsFixture;
            _clienteService = _clienteTestsAutoMockerFixture.ObterClienteService();
        }

        [Fact(DisplayName = "Adicionar Cliente com Sucesso")]
        [Trait("Categoria", "Cliente Service AutoMockFixture Tests")]
        public void ClienteService_Adicionar_DeveExecutarComSucesso()
        {
            // Arrange
            var cliente = _clienteTestsAutoMockerFixture.GerarClienteValido();

            // Act
            _clienteService.Add(cliente);

            // Assert
            Assert.True(cliente.IsValid());
            _clienteTestsAutoMockerFixture.Mocker.GetMock<ICustomerRepository>().Verify(r => r.Add(cliente),Times.Once);
            _clienteTestsAutoMockerFixture.Mocker.GetMock<IMediator>().Verify(m=>m.Publish(It.IsAny<INotification>(),CancellationToken.None),Times.Once);
        }

        [Fact(DisplayName = "Adicionar Cliente com Falha")]
        [Trait("Categoria", "Cliente Service AutoMockFixture Tests")]
        public void ClienteService_Adicionar_DeveFalharDevidoClienteInvalido()
        {
            // Arrange
            var cliente = _clienteTestsAutoMockerFixture.GerarClienteInvalido();

            // Act
            _clienteService.Add(cliente);

            // Assert
            Assert.False(cliente.IsValid());
            _clienteTestsAutoMockerFixture.Mocker.GetMock<ICustomerRepository>().Verify(r => r.Add(cliente), Times.Never);
            _clienteTestsAutoMockerFixture.Mocker.GetMock<IMediator>().Verify(m => m.Publish(It.IsAny<INotification>(), CancellationToken.None), Times.Never);
        }

        [Fact(DisplayName = "Obter Clientes Ativos")]
        [Trait("Categoria", "Cliente Service AutoMockFixture Tests")]
        public void ClienteService_ObterTodosAtivos_DeveRetornarApenasClientesAtivos()
        {
            // Arrange
            _clienteTestsAutoMockerFixture.Mocker.GetMock<ICustomerRepository>().Setup(c => c.GetAll())
                .Returns(_clienteTestsAutoMockerFixture.ObterClientesVariados());

            // Act
            var clientes = _clienteService.GetAllActive();

            // Assert 
            _clienteTestsAutoMockerFixture.Mocker.GetMock<ICustomerRepository>().Verify(r => r.GetAll(), Times.Once);
            Assert.True(clientes.Any());
            Assert.False(clientes.Count(c=>!c.Active) > 0);
        }
    }
}