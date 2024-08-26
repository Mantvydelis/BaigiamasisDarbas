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
    public class TestVartotojai
    {
        [Fact]
        public async Task AddUser_Buyer()
        {
            Mock<IVartotojaiEFDBRepository> _vartotojaiRepository = new Mock<IVartotojaiEFDBRepository>();
            Mock<IMongoDbCacheRepository> _mongoRepository = new Mock<IMongoDbCacheRepository>();

            IVartotojaiService vartotojaiService = new VartotojaiService(_vartotojaiRepository.Object, _mongoRepository.Object);

            Pirkejas pirkejas1 = new Pirkejas
            {
                PirkejoId = 10,
                Vardas = "Petras",
                Pavarde = "Petraitis",
                ElPastas = "PetrasPetraitis@gmail.com",
                TelNumeris = 869945446,

            };

            //Act
            vartotojaiService.AddUser(pirkejas1);
            //Assert
            _vartotojaiRepository.Verify(x => x.AddBuyer(It.IsAny<Pirkejas>()), Times.Once);
            _mongoRepository.Verify(x => x.AddBuyer(It.IsAny<Pirkejas>()), Times.Once);
            _vartotojaiRepository.Verify(x => x.AddSeller(It.IsAny<Pardavejas>()), Times.Never);
            _mongoRepository.Verify(x => x.AddSeller(It.IsAny<Pardavejas>()), Times.Never);

        }


        [Fact]
        public async Task AddUser_Seller()
        {
            Mock<IVartotojaiEFDBRepository> _vartotojaiRepository = new Mock<IVartotojaiEFDBRepository>();
            Mock<IMongoDbCacheRepository> _mongoRepository = new Mock<IMongoDbCacheRepository>();

            IVartotojaiService vartotojaiService = new VartotojaiService(_vartotojaiRepository.Object, _mongoRepository.Object);

            Pardavejas pardavejas1 = new Pardavejas
            {
                PardavejoId = 12,
                Vardas = "Kestas",
                Pavarde = "Kestutaitis",
                ElPastas = "KestasKestutaitis@gmail.com",
                TelNumeris = 869645546,

            };

            //Act
            vartotojaiService.AddUser(pardavejas1);
            //Assert
            _vartotojaiRepository.Verify(x => x.AddSeller(It.IsAny<Pardavejas>()), Times.Once);
            _mongoRepository.Verify(x => x.AddSeller(It.IsAny<Pardavejas>()), Times.Once);
            _vartotojaiRepository.Verify(x => x.AddBuyer(It.IsAny<Pirkejas>()), Times.Never);
            _mongoRepository.Verify(x => x.AddBuyer(It.IsAny<Pirkejas>()), Times.Never);

        }

        [Fact]
        public async Task TestUpdateUser_Buyer()
        {
            Mock<IVartotojaiEFDBRepository> _vartotojaiRepository = new Mock<IVartotojaiEFDBRepository>();
            Mock<IMongoDbCacheRepository> _mongoRepository = new Mock<IMongoDbCacheRepository>();

            IVartotojaiService vartotojaiService = new VartotojaiService(_vartotojaiRepository.Object, _mongoRepository.Object);

            Pirkejas pirkejas1 = new Pirkejas
            {
                PirkejoId = 10,
                Vardas = "Petras",
                Pavarde = "Petraitis",
                ElPastas = "PetrasPetraitis@gmail.com",
                TelNumeris = 869945446,

            };
            vartotojaiService.AddUser(pirkejas1);

            //Act
            await vartotojaiService.UpdateUser(pirkejas1);
            pirkejas1.Vardas = "Jonas";
            pirkejas1.Pavarde = "Jonaitis";
            pirkejas1.ElPastas = "Jonasjonaitis@gmail.com";
            pirkejas1.TelNumeris = 869945116;

            //Assert
            _vartotojaiRepository.Verify(repo => repo.UpdateBuyer(It.Is<Pirkejas>(p =>
            p.PirkejoId == pirkejas1.PirkejoId &&
            p.Vardas == "Jonas" &&
            p.Pavarde == "Jonaitis" &&
             p.ElPastas == "Jonasjonaitis@gmail.com" &&
             p.TelNumeris == 869945116
             )), Times.Once);

            _mongoRepository.Verify(repo => repo.UpdateBuyer(It.Is<Pirkejas>(p =>
            p.PirkejoId == pirkejas1.PirkejoId &&
            p.Vardas == "Jonas" &&
            p.Pavarde == "Jonaitis" &&
             p.ElPastas == "Jonasjonaitis@gmail.com" &&
             p.TelNumeris == 869945116
             )), Times.Once);


        }

        [Fact]
        public async Task TestUpdateUser_Seller()
        {
            Mock<IVartotojaiEFDBRepository> _vartotojaiRepository = new Mock<IVartotojaiEFDBRepository>();
            Mock<IMongoDbCacheRepository> _mongoRepository = new Mock<IMongoDbCacheRepository>();

            IVartotojaiService vartotojaiService = new VartotojaiService(_vartotojaiRepository.Object, _mongoRepository.Object);

            Pardavejas pardavejas1 = new Pardavejas
            {
                PardavejoId = 12,
                Vardas = "Kestas",
                Pavarde = "Kestutaitis",
                ElPastas = "KestasKestutaitis@gmail.com",
                TelNumeris = 869645546,

            };
            vartotojaiService.AddUser(pardavejas1);

            //Act
            await vartotojaiService.UpdateUser(pardavejas1);
            pardavejas1.Vardas = "Petras";
            pardavejas1.Pavarde = "Petraitis";
            pardavejas1.ElPastas = "Petraspetraitis@gmail.com";
            pardavejas1.TelNumeris = 868955116;

            //Assert
            _vartotojaiRepository.Verify(repo => repo.UpdateSeller(It.Is<Pardavejas>(p =>
            p.PardavejoId == pardavejas1.PardavejoId &&
            p.Vardas == "Petras" &&
            p.Pavarde == "Petraitis" &&
             p.ElPastas == "Petraspetraitis@gmail.com" &&
             p.TelNumeris == 868955116
             )), Times.Once);

            _mongoRepository.Verify(repo => repo.UpdateSeller(It.Is<Pardavejas>(p =>
            p.PardavejoId == pardavejas1.PardavejoId &&
            p.Vardas == "Petras" &&
            p.Pavarde == "Petraitis" &&
             p.ElPastas == "Petraspetraitis@gmail.com" &&
             p.TelNumeris == 868955116
             )), Times.Once);


        }

        [Fact]
        public async Task GetUserByIdTest_Buyer()
        {
            //Arrange
            Pirkejas pirkejas1 = new Pirkejas
            {
                PirkejoId = 10,
                Vardas = "Petras",
                Pavarde = "Petraitis",
                ElPastas = "PetrasPetraitis@gmail.com",
                TelNumeris = 869945446,

            };
            Pirkejas pirkejas2 = new Pirkejas
            {
                PirkejoId = 11,
                Vardas = "Antanas",
                Pavarde = "Antanaitis",
                ElPastas = "Antanasantanaitis@gmail.com",
                TelNumeris = 869445466,

            };

            Mock<IVartotojaiEFDBRepository> _vartotojaiRepository = new Mock<IVartotojaiEFDBRepository>();
            Mock<IMongoDbCacheRepository> _mongoRepository = new Mock<IMongoDbCacheRepository>();


            IVartotojaiService vartotojaiService = new VartotojaiService(_vartotojaiRepository.Object, _mongoRepository.Object);

            _vartotojaiRepository.Setup(x => x.GetBuyerById(10)).ReturnsAsync(pirkejas1);

            // Act
            Vartotojas vartotojas = await vartotojaiService.GetUserById(10, true);

            // Assert
            Assert.IsType<Pirkejas>(vartotojas);
            Assert.Equal(pirkejas1.PirkejoId, ((Pirkejas)vartotojas).PirkejoId);
            Assert.Equal(pirkejas1.Vardas, ((Pirkejas)vartotojas).Vardas);

        }

        [Fact]
        public async Task GetUserByIdTest_Seller()
        {
            //Arrange
            Pardavejas pardavejas1 = new Pardavejas
            {
                PardavejoId = 12,
                Vardas = "Kestas",
                Pavarde = "Kestutaitis",
                ElPastas = "KestasKestutaitis@gmail.com",
                TelNumeris = 869645546,

            };
            Pardavejas pardavejas2 = new Pardavejas
            {
                PardavejoId = 13,
                Vardas = "Petras",
                Pavarde = "Petraitis",
                ElPastas = "PetrasPetraitis@gmail.com",
                TelNumeris = 868646546,

            };

            Mock<IVartotojaiEFDBRepository> _vartotojaiRepository = new Mock<IVartotojaiEFDBRepository>();
            Mock<IMongoDbCacheRepository> _mongoRepository = new Mock<IMongoDbCacheRepository>();


            IVartotojaiService vartotojaiService = new VartotojaiService(_vartotojaiRepository.Object, _mongoRepository.Object);

            _vartotojaiRepository.Setup(x => x.GetSellerById(13)).ReturnsAsync(pardavejas2);

            // Act
            Vartotojas vartotojas = await vartotojaiService.GetUserById(13, false);

            // Assert
            Assert.IsType<Pardavejas>(vartotojas);
            Assert.Equal(pardavejas2.PardavejoId, ((Pardavejas)vartotojas).PardavejoId);
            Assert.Equal(pardavejas2.Vardas, ((Pardavejas)vartotojas).Vardas);
        }

        [Fact]
        public async Task GetAllUsersTest()
        {
            //Arrange
            Pardavejas pardavejas1 = new Pardavejas
            {
                PardavejoId = 12,
                Vardas = "Kestas",
                Pavarde = "Kestutaitis",
                ElPastas = "KestasKestutaitis@gmail.com",
                TelNumeris = 869645546,

            };

            Pirkejas pirkejas1 = new Pirkejas
            {
                PirkejoId = 10,
                Vardas = "Petras",
                Pavarde = "Petraitis",
                ElPastas = "PetrasPetraitis@gmail.com",
                TelNumeris = 869945446,

            };

            Mock<IVartotojaiEFDBRepository> _vartotojaiRepository = new Mock<IVartotojaiEFDBRepository>();
            Mock<IMongoDbCacheRepository> _mongoRepository = new Mock<IMongoDbCacheRepository>();

            List<Pirkejas> pirkejai = new List<Pirkejas> { pirkejas1 };
            List<Pardavejas> pardavejai = new List<Pardavejas> { pardavejas1 };

            _vartotojaiRepository.Setup(x => x.GetAllBuyers()).ReturnsAsync(pirkejai);
            _vartotojaiRepository.Setup(x => x.GetAllSellers()).ReturnsAsync(pardavejai);

            IVartotojaiService vartotojaiService = new VartotojaiService(_vartotojaiRepository.Object, _mongoRepository.Object);

            // Act
            var result = await vartotojaiService.GetAllUsers();

            // Assert
            Assert.Contains(result, k => k is Pirkejas && ((Pirkejas)k).PirkejoId == pirkejas1.PirkejoId);
            Assert.Contains(result, k => k is Pardavejas && ((Pardavejas)k).PardavejoId == pardavejas1.PardavejoId);


        }

        [Fact]
        public async Task DeleteUserByIdTest_Buyer()
        {
            //Arrange
            Pardavejas pardavejas1 = new Pardavejas
            {
                PardavejoId = 12,
                Vardas = "Kestas",
                Pavarde = "Kestutaitis",
                ElPastas = "KestasKestutaitis@gmail.com",
                TelNumeris = 869645546,

            };

            Pirkejas pirkejas1 = new Pirkejas
            {
                PirkejoId = 10,
                Vardas = "Petras",
                Pavarde = "Petraitis",
                ElPastas = "PetrasPetraitis@gmail.com",
                TelNumeris = 869945446,

            };

            Mock<IVartotojaiEFDBRepository> _vartotojaiRepository = new Mock<IVartotojaiEFDBRepository>();
            Mock<IMongoDbCacheRepository> _mongoRepository = new Mock<IMongoDbCacheRepository>();

            IVartotojaiService vartotojaiService = new VartotojaiService(_vartotojaiRepository.Object, _mongoRepository.Object);

            _vartotojaiRepository.Setup(x => x.GetBuyerById(10)).ReturnsAsync(pirkejas1);

            // Act
            await vartotojaiService.DeleteUserById(10, true);

            // Assert
            _vartotojaiRepository.Verify(x => x.DeleteBuyerById(10), Times.Once);
            _mongoRepository.Verify(x => x.DeleteBuyerById(10), Times.Once);


        }

        [Fact]
        public async Task DeleteUserByIdTest_Seller()
        {
            //Arrange
            Pardavejas pardavejas1 = new Pardavejas
            {
                PardavejoId = 12,
                Vardas = "Kestas",
                Pavarde = "Kestutaitis",
                ElPastas = "KestasKestutaitis@gmail.com",
                TelNumeris = 869645546,

            };

            Pirkejas pirkejas1 = new Pirkejas
            {
                PirkejoId = 10,
                Vardas = "Petras",
                Pavarde = "Petraitis",
                ElPastas = "PetrasPetraitis@gmail.com",
                TelNumeris = 869945446,

            };

            Mock<IVartotojaiEFDBRepository> _vartotojaiRepository = new Mock<IVartotojaiEFDBRepository>();
            Mock<IMongoDbCacheRepository> _mongoRepository = new Mock<IMongoDbCacheRepository>();

            IVartotojaiService vartotojaiService = new VartotojaiService(_vartotojaiRepository.Object, _mongoRepository.Object);

            _vartotojaiRepository.Setup(x => x.GetSellerById(12)).ReturnsAsync(pardavejas1);

            // Act
            await vartotojaiService.DeleteUserById(12, false);

            // Assert
            _vartotojaiRepository.Verify(x => x.DeleteSellerById(12), Times.Once);
            _mongoRepository.Verify(x => x.DeleteSellerById(12), Times.Once);



        }


    }
}
