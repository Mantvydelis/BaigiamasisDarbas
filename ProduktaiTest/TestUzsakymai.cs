using Moq;
using Parduotuve.Core.Contracts;
using Parduotuve.Core.Models;
using Parduotuve.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParduotuveTest
{
    public class TestUzsakymai
    {
        [Fact]
        public async Task TestAddOrder()
        {
            Mock<IUzsakymaiEFDBRepository> _uzskymaiRepository = new Mock<IUzsakymaiEFDBRepository>();
            Mock<IMongoDbCacheRepository> _mongoRepository = new Mock<IMongoDbCacheRepository>();

            IUzsakymaiService uzsakymaiService = new UzsakymaiService(_uzskymaiRepository.Object, _mongoRepository.Object);

            Uzsakymas uzsakymas1 = new Uzsakymas
            {
                UzsakymoId = 12,
                PardavejoId = 1,
                PirkejoId = 5,
                ProduktoId = 3,
                UzsakymoData = DateOnly.Parse("2024-08-25"),
                Kiekis = 3

            };
            //Act
            uzsakymaiService.AddOrder(uzsakymas1);
            //Assert
            _uzskymaiRepository.Verify(x => x.AddOrder(It.IsAny<Uzsakymas>()), Times.Once);

        }

        [Fact]
        public async Task TestUpdateOrder()
        {
            Mock<IUzsakymaiEFDBRepository> _uzskymaiRepository = new Mock<IUzsakymaiEFDBRepository>();
            Mock<IMongoDbCacheRepository> _mongoRepository = new Mock<IMongoDbCacheRepository>();

            IUzsakymaiService uzsakymaiService = new UzsakymaiService(_uzskymaiRepository.Object, _mongoRepository.Object);

            Uzsakymas uzsakymas1 = new Uzsakymas
            {
                UzsakymoId = 12,
                PardavejoId = 1,
                PirkejoId = 5,
                ProduktoId = 3,
                UzsakymoData = DateOnly.Parse("2024-08-25"),
                Kiekis = 3

            };

            uzsakymaiService.AddOrder(uzsakymas1);

            //Act
            await uzsakymaiService.UpdateOrder(uzsakymas1);
            uzsakymas1.PardavejoId = 1;
            uzsakymas1.PirkejoId = 6;
            uzsakymas1.ProduktoId = 2;
            uzsakymas1.UzsakymoData = DateOnly.Parse("2024-09-25");
            uzsakymas1.Kiekis = 2;


            //Assert
            _uzskymaiRepository.Verify(repo => repo.UpdateOrder(It.Is<Uzsakymas>(p =>
            p.UzsakymoId == uzsakymas1.UzsakymoId &&
            p.PirkejoId == 6 &&
            p.ProduktoId == 2 &&
             p.UzsakymoData == DateOnly.Parse("2024-09-25") &&
             p.Kiekis == 2
             )), Times.Once);

            _mongoRepository.Verify(repo => repo.UpdateOrder(It.Is<Uzsakymas>(p =>
            p.UzsakymoId == uzsakymas1.UzsakymoId &&
            p.PirkejoId == 6 &&
            p.ProduktoId == 2 &&
             p.UzsakymoData == DateOnly.Parse("2024-09-25") &&
             p.Kiekis == 2
             )), Times.Once);


        }

        [Fact]
        public async Task TestGetAllOrders()
        {
            //Arrange
            Uzsakymas uzsakymas1 = new Uzsakymas
            {
                UzsakymoId = 12,
                PardavejoId = 1,
                PirkejoId = 5,
                ProduktoId = 3,
                UzsakymoData = DateOnly.Parse("2024-08-25"),
                Kiekis = 3

            };

            Uzsakymas uzsakymas2 = new Uzsakymas
            {
                UzsakymoId = 11,
                PardavejoId = 3,
                PirkejoId = 1,
                ProduktoId = 4,
                UzsakymoData = DateOnly.Parse("2023-09-21"),
                Kiekis = 5

            };

            Mock<IUzsakymaiEFDBRepository> _uzsakymaiRepository = new Mock<IUzsakymaiEFDBRepository>();
            Mock<IMongoDbCacheRepository> _mongoRepository = new Mock<IMongoDbCacheRepository>();

            List<Uzsakymas> uzsakymai = new List<Uzsakymas> { uzsakymas1, uzsakymas2 };

            _uzsakymaiRepository.Setup(x => x.GetAllOrders().Result).Returns(uzsakymai);


            //Act
            var result = _uzsakymaiRepository.Object.GetAllOrders().Result;

            //Assert
            Assert.Contains(result, k => k.UzsakymoId == uzsakymas1.UzsakymoId);
            Assert.Contains(result, k => k.UzsakymoId == uzsakymas2.UzsakymoId);



        }

        [Fact]
        public async Task TestGetOrderById()
        {
            //Arrange
            Uzsakymas uzsakymas1 = new Uzsakymas
            {
                UzsakymoId = 12,
                PardavejoId = 1,
                PirkejoId = 5,
                ProduktoId = 3,
                UzsakymoData = DateOnly.Parse("2024-08-25"),
                Kiekis = 3

            };

            Uzsakymas uzsakymas2 = new Uzsakymas
            {
                UzsakymoId = 11,
                PardavejoId = 3,
                PirkejoId = 1,
                ProduktoId = 4,
                UzsakymoData = DateOnly.Parse("2023-09-21"),
                Kiekis = 5

            };

            var _uzsakymaiRepository = new Mock<IUzsakymaiEFDBRepository>();
            var _mongoRepository = new Mock<IMongoDbCacheRepository>();

            _mongoRepository.Setup(x => x.GetOrderById(12)).ReturnsAsync(uzsakymas1);
            _uzsakymaiRepository.Setup(x => x.GetOrderById(12)).ReturnsAsync(uzsakymas1);

            var service = new UzsakymaiService(_uzsakymaiRepository.Object, _mongoRepository.Object);

            // Act
            var result = await service.GetOrderById(12);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(uzsakymas1.UzsakymoId, result.UzsakymoId);



        }

        [Fact]
        public async Task TestDeleteOrderById()
        {
            Mock<IUzsakymaiEFDBRepository> _uzsakymaiRepository = new Mock<IUzsakymaiEFDBRepository>();
            Mock<IMongoDbCacheRepository> _mongoRepository = new Mock<IMongoDbCacheRepository>();

            IUzsakymaiService uzsakymaiService = new UzsakymaiService(_uzsakymaiRepository.Object, _mongoRepository.Object);

            Uzsakymas uzsakymas1 = new Uzsakymas
            {
                UzsakymoId = 12,
                PardavejoId = 1,
                PirkejoId = 5,
                ProduktoId = 3,
                UzsakymoData = DateOnly.Parse("2024-08-25"),
                Kiekis = 3

            };

            // Act
            await uzsakymaiService.AddOrder(uzsakymas1);
            await uzsakymaiService.DeleteOrderById(12);

            //Assert
            var uzsakymasDB = await uzsakymaiService.GetOrderById(12);
            Assert.Null(uzsakymasDB);


        }




    }
}
