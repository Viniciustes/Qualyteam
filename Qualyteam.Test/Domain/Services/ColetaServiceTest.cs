using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Qualyteam.Application.ViewModels;
using Qualyteam.Domain.Interfaces.Mediators;
using Qualyteam.Domain.Interfaces.Repository;
using Qualyteam.Domain.Messagens;
using Qualyteam.Domain.Models;
using Qualyteam.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Qualyteam.Test.Domain.Services
{
    [TestClass]
    public class ColetaServiceTest
    {
        private ColetaService _service;

        private Mock<IMapper> _mockMapper;
        private Mock<IMediatorHandler> _mockMediatorHandler;
        private Mock<IColetaRepository> _mockColetaRepository;
        private Mock<IIndicadorMensalRepository> _mockIndicadorMensalRepository;

        [TestInitialize]
        public void Setup()
        {
            _mockMapper = new Mock<IMapper>();
            _mockMediatorHandler = new Mock<IMediatorHandler>();
            _mockColetaRepository = new Mock<IColetaRepository>();
            _mockIndicadorMensalRepository = new Mock<IIndicadorMensalRepository>();

            _service = new ColetaService(_mockMediatorHandler.Object, _mockMapper.Object, _mockColetaRepository.Object, _mockIndicadorMensalRepository.Object);
        }

        [TestMethod]
        public async Task GetColetaTest()
        {
            // Arrange
            var indicadorMensal = new IndicadorMensal(1, "Qualyteam", DateTime.Now);

            IEnumerable<Coleta> listColeta = new List<Coleta>
            {
                new Coleta(1, 10, DateTime.Now.AddMonths(-1), indicadorMensal),
                new Coleta(2, 20, DateTime.Now.AddMonths(-2), indicadorMensal)
            };

            IEnumerable<ColetaViewModel> listColetaViewModel = new List<ColetaViewModel>
            {
                new ColetaViewModel
                {
                    Id = 1,
                    Valor = 10,
                    IndicadorMensal = new IndicadorMensalViewModel
                    {
                        Id = indicadorMensal.Id,
                        Nome = indicadorMensal.Nome,
                        DataInicio = indicadorMensal.DataInicio
                    }
                },
                 new ColetaViewModel
                {
                    Id = 2,
                    Valor = 20,
                    IndicadorMensal = new IndicadorMensalViewModel
                    {
                        Id = indicadorMensal.Id,
                        Nome = indicadorMensal.Nome,
                        DataInicio = indicadorMensal.DataInicio
                    }
                }
            };

            _mockColetaRepository.Setup(x => x.GetAsync())
               .Returns(Task.FromResult(listColeta));

            _mockMapper.Setup(x => x.Map<IEnumerable<ColetaViewModel>>(listColeta))
                .Returns(listColetaViewModel);

            // Act
            var result = await _service.Get();

            // Assert
            Assert.IsTrue(result.Count() == 2);
        }

        [TestMethod]
        public async Task GetByIdColetaTest()
        {
            // Arrange
            var indicadorMensal = new IndicadorMensal(1, "Qualyteam", DateTime.Now);

            var coleta = new Coleta(2, 20, DateTime.Now.AddMonths(-2), indicadorMensal);

            var coletaViewModel = new ColetaViewModel
            {
                Id = 2,
                Valor = 20,
                IndicadorMensal = new IndicadorMensalViewModel
                {
                    Id = indicadorMensal.Id,
                    Nome = indicadorMensal.Nome,
                    DataInicio = indicadorMensal.DataInicio
                }
            };

            _mockColetaRepository.Setup(x => x.GetByIdAsync(2))
               .Returns(Task.FromResult(coleta));

            _mockMapper.Setup(x => x.Map<ColetaViewModel>(coleta))
                .Returns(coletaViewModel);

            // Act
            var result = await _service.GetById(2);

            // Assert
            Assert.IsTrue(result.Id == 2);
        }

        [TestMethod]
        public async Task CreateColetaTestOk()
        {
            // Arrange
            var coletaRequestViewModel = new ColetaRequestViewModel
            {
                Id = 0,
                Valor = 55.5m,
                IdIndicadorMensal = 1
            };

            var indicadorMensal = new IndicadorMensal(1, "Qualyteam", DateTime.Now.AddDays(-1));

            var coletaViewModel = new ColetaViewModel
            {
                Id = 1,
                Valor = 55.5m,
                DataColeta = DateTime.Now,
                IndicadorMensal = new IndicadorMensalViewModel
                {
                    Id = indicadorMensal.Id,
                    DataInicio = indicadorMensal.DataInicio,
                    Nome = indicadorMensal.Nome
                }
            };

            var coleta = new Coleta(0, 55.5m, DateTime.Now, indicadorMensal);

            _mockMapper.Setup(x => x.Map<Coleta>(coletaRequestViewModel))
              .Returns((ColetaRequestViewModel source) => coleta);

            _mockMapper.Setup(x => x.Map<ColetaViewModel>(coleta))
              .Returns((Coleta source) => coletaViewModel);

            _mockIndicadorMensalRepository.Setup(x => x.GetByIdAsync(coletaRequestViewModel.IdIndicadorMensal))
                .Returns(Task.FromResult(indicadorMensal));

            // Act
            var result = await _service.Create(coletaRequestViewModel);

            // Assert
            Assert.IsFalse(coleta.ValidationResult == null);
            Assert.IsTrue(coleta.ValidationResult.IsValid);
        }

        [TestMethod]
        public async Task CreateColetaTestFaillQuandoDataIndicadorMaiorQueDataColeta()
        {
            // Arrange
            var coletaRequestViewModel = new ColetaRequestViewModel
            {
                Id = 0,
                Valor = 55.5m,
                IdIndicadorMensal = 1
            };

            var indicadorMensal = new IndicadorMensal(1, "Qualyteam", DateTime.Now.AddDays(1));

            var coleta = new Coleta(0, 55.5m, DateTime.Now, indicadorMensal);

            _mockMapper.Setup(x => x.Map<Coleta>(coletaRequestViewModel))
              .Returns((ColetaRequestViewModel source) => coleta);

            _mockIndicadorMensalRepository.Setup(x => x.GetByIdAsync(coletaRequestViewModel.IdIndicadorMensal))
                .Returns(Task.FromResult(indicadorMensal));

            // Act
            var result = await _service.Create(coletaRequestViewModel);

            // Assert
            Assert.IsFalse(coleta.ValidationResult.IsValid);
            Assert.IsTrue(coleta.ValidationResult.Errors.Count > 0);
            Assert.IsTrue(coleta.ValidationResult.ToString() == Messages.MSG06);
        }

        [TestMethod]
        public async Task UpdateColetaTestOk()
        {
            // Arrange
            var coletaRequestViewModel = new ColetaRequestViewModel
            {
                Id = 1,
                Valor = 55.5m,
                IdIndicadorMensal = 1
            };

            var indicadorMensal = new IndicadorMensal(1, "Qualyteam", DateTime.Now);

            var coletaViewModel = new ColetaViewModel
            {
                Id = 1,
                Valor = 55.5m,
                DataColeta = DateTime.Now.AddDays(1),
                IndicadorMensal = new IndicadorMensalViewModel
                {
                    Id = indicadorMensal.Id,
                    DataInicio = indicadorMensal.DataInicio,
                    Nome = indicadorMensal.Nome
                }
            };

            var coleta = new Coleta(1, 55.5m, DateTime.Now.AddDays(1), indicadorMensal);

            _mockMapper.Setup(x => x.Map<Coleta>(coletaRequestViewModel))
              .Returns((ColetaRequestViewModel source) => coleta);

            _mockMapper.Setup(x => x.Map<ColetaViewModel>(coleta))
              .Returns((Coleta source) => coletaViewModel);

            _mockIndicadorMensalRepository.Setup(x => x.GetByIdAsync(coletaRequestViewModel.IdIndicadorMensal))
                .Returns(Task.FromResult(indicadorMensal));

            // Act
            var result = await _service.Create(coletaRequestViewModel);

            // Assert
            Assert.IsFalse(coleta.ValidationResult == null);
            Assert.IsTrue(coleta.ValidationResult.IsValid);
        }

        [TestMethod]
        public async Task UpdateColetaTestFaillQuandoDataIndicadorMaiorQueDataColeta()
        {
            // Arrange
            var coletaRequestViewModel = new ColetaRequestViewModel
            {
                Id = 1,
                Valor = 55.5m,
                IdIndicadorMensal = 1
            };

            var indicadorMensal = new IndicadorMensal(1, "Qualyteam", DateTime.Now.AddDays(1));

            var coleta = new Coleta(1, 55.5m, DateTime.Now.AddMonths(-1), indicadorMensal);

            _mockMapper.Setup(x => x.Map<Coleta>(coletaRequestViewModel))
              .Returns((ColetaRequestViewModel source) => coleta);

            _mockIndicadorMensalRepository.Setup(x => x.GetByIdAsync(coletaRequestViewModel.IdIndicadorMensal))
                .Returns(Task.FromResult(indicadorMensal));

            // Act
            var result = await _service.Update(coletaRequestViewModel);

            // Assert
            Assert.IsFalse(coleta.ValidationResult.IsValid);
            Assert.IsTrue(coleta.ValidationResult.Errors.Count > 0);
            Assert.IsTrue(coleta.ValidationResult.ToString() == Messages.MSG06);
        }
    }
}
