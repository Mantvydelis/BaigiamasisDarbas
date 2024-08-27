using Moq;
using Parduotuve.Core.Contracts;
using Parduotuve.Core.Models;
using Parduotuve.Core.Services;

namespace ParduotuveTest
{
    public class TestProduktai
    {
        [Fact]
        public async Task TestAddProduct()
        {
            Mock<IProduktaiEFDBRepository> _produktaiRepository = new Mock<IProduktaiEFDBRepository>();
            Mock<IMongoDbCacheRepository> _mongoRepository = new Mock<IMongoDbCacheRepository>();

            IProduktaiService produktaiService = new ProduktaiService(_produktaiRepository.Object, _mongoRepository.Object);

            Produktas produktas1 = new Produktas
            {
                ProduktoId = 11,
                Pavadinimas = "Arbuzas",
                Kaina = 5,
                Kategorija = Parduotuve.Core.Enums.PrekiuKategorija.Maistas,
                KiekisSandelyje = 20,

            };
            //Act
            produktaiService.AddProduct(produktas1);
            //Assert
            _produktaiRepository.Verify(x => x.AddProduct(It.IsAny<Produktas>()), Times.Once);

        }

        [Fact]
        public async Task TestUpdateProduct()
        {
            Mock<IProduktaiEFDBRepository> _produktaiRepository = new Mock<IProduktaiEFDBRepository>();
            Mock<IMongoDbCacheRepository> _mongoRepository = new Mock<IMongoDbCacheRepository>();

            IProduktaiService produktaiService = new ProduktaiService(_produktaiRepository.Object, _mongoRepository.Object);

            Produktas produktas1 = new Produktas
            {
                ProduktoId = 11,
                Pavadinimas = "Arbuzas",
                Kaina = 5,
                Kategorija = Parduotuve.Core.Enums.PrekiuKategorija.Maistas,
                KiekisSandelyje = 20,

            };
            produktaiService.AddProduct(produktas1);

            //Act
            await produktaiService.UpdateProduct(produktas1);
            produktas1.Pavadinimas = "Kriause";
            produktas1.Kaina = 6;
            produktas1.Kategorija = Parduotuve.Core.Enums.PrekiuKategorija.Maistas;
            produktas1.KiekisSandelyje = 25;

            //Assert
            _produktaiRepository.Verify(repo => repo.UpdateProduct(It.Is<Produktas>(p =>
            p.ProduktoId == produktas1.ProduktoId &&
            p.Pavadinimas == "Kriause" &&
            p.Kaina == 6 &&
             p.KiekisSandelyje == 25
             )), Times.Once);

            _mongoRepository.Verify(repo => repo.UpdateProduct(It.Is<Produktas>(p =>
                p.ProduktoId == produktas1.ProduktoId &&
                p.Pavadinimas == "Kriause" &&
                p.Kaina == 6 &&
                p.KiekisSandelyje == 25
            )), Times.Once);


        }


        [Fact]
        public async Task TestGetAllProducts()
        {
            //Arrange
            Produktas produktas1 = new Produktas
            {
                ProduktoId = 11,
                Pavadinimas = "Arbuzas",
                Kaina = 5,
                Kategorija = Parduotuve.Core.Enums.PrekiuKategorija.Maistas,
                KiekisSandelyje = 20,

            };

            Produktas produktas2 = new Produktas
            {
                ProduktoId = 10,
                Pavadinimas = "Lempa",
                Kaina = 30,
                Kategorija = Parduotuve.Core.Enums.PrekiuKategorija.Kita,
                KiekisSandelyje = 25,

            };

            Mock<IProduktaiEFDBRepository> _produktaiRepository = new Mock<IProduktaiEFDBRepository>();
            Mock<IMongoDbCacheRepository> _mongoRepository = new Mock<IMongoDbCacheRepository>();

            IProduktaiService produktaiService = new ProduktaiService(_produktaiRepository.Object, _mongoRepository.Object);

            List<Produktas> produktai = new List<Produktas> { produktas1, produktas2 };

            _produktaiRepository.Setup(x => x.GetAllProducts().Result).Returns(produktai);


            //Act
            var result = produktaiService.GetAllProducts().Result;

            //Assert
            Assert.Contains(result, k => k.ProduktoId == produktas1.ProduktoId);
            Assert.Contains(result, k => k.ProduktoId == produktas2.ProduktoId);



        }

        [Fact]
        public async Task TestGetProductById()
        {
            //Arrange
            Produktas produktas1 = new Produktas
            {
                ProduktoId = 11,
                Pavadinimas = "Arbuzas",
                Kaina = 5,
                Kategorija = Parduotuve.Core.Enums.PrekiuKategorija.Maistas,
                KiekisSandelyje = 20,

            };

            Produktas produktas2 = new Produktas
            {
                ProduktoId = 10,
                Pavadinimas = "Lempa",
                Kaina = 30,
                Kategorija = Parduotuve.Core.Enums.PrekiuKategorija.Kita,
                KiekisSandelyje = 25,

            };

            var _produktaiRepository = new Mock<IProduktaiEFDBRepository>();
            var _mongoRepository = new Mock<IMongoDbCacheRepository>();

            _mongoRepository.Setup(x => x.GetProductById(10)).ReturnsAsync(produktas2);
            _produktaiRepository.Setup(x => x.GetProductById(10)).ReturnsAsync(produktas2);

            var service = new ProduktaiService(_produktaiRepository.Object, _mongoRepository.Object);

            // Act
            var result = await service.GetProductById(10);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(produktas2.ProduktoId, result.ProduktoId);



        }


        [Fact]
        public async Task TestDeleteProductById()
        {
            Mock<IProduktaiEFDBRepository> _produktaiRepository = new Mock<IProduktaiEFDBRepository>();
            Mock<IMongoDbCacheRepository> _mongoRepository = new Mock<IMongoDbCacheRepository>();

            IProduktaiService produktaiService = new ProduktaiService(_produktaiRepository.Object, _mongoRepository.Object);

            Produktas produktas1 = new Produktas
            {
                ProduktoId = 11,
                Pavadinimas = "Arbuzas",
                Kaina = 5,
                Kategorija = Parduotuve.Core.Enums.PrekiuKategorija.Maistas,
                KiekisSandelyje = 20,

            };

            // Act
            await produktaiService.AddProduct(produktas1);
            await produktaiService.DeleteProductById(11);

            //Assert
            var produktasDB = await produktaiService.GetProductById(11);
            Assert.Null(produktasDB);

        }

       


    }


}