using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Qualyteam.Application.ViewModels;
using Qualyteam.Application.ViewModels.Filters;
using Qualyteam.Domain.Interfaces.Mediators;
using Qualyteam.Domain.Interfaces.Repository;
using Qualyteam.Domain.Messagens;
using Qualyteam.Domain.Models;
using Qualyteam.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Qualyteam.Test.Domain.Services
{
    [TestClass]
    public class IndicadorMensalServiceTest
    {
        private IndicadorMensalService _service;

        private Mock<IMapper> _mockMapper;
        private Mock<IMediatorHandler> _mockMediatorHandler;
        private Mock<IIndicadorMensalRepository> _mockRepository;

        [TestInitialize]
        public void Setup()
        {
            _mockMapper = new Mock<IMapper>();
            _mockMediatorHandler = new Mock<IMediatorHandler>();
            _mockRepository = new Mock<IIndicadorMensalRepository>();

            _service = new IndicadorMensalService(_mockMediatorHandler.Object, _mockMapper.Object, _mockRepository.Object);
        }

        [TestMethod]
        public async Task SearchIndicadorMensalTestOk()
        {
            // Arrange
            var filter = new FilterIndicadorMensalViewModel
            {
                Id = 2,
                Nome = "Qualy",
                DataInicio = DateTime.Now,
            };

            IEnumerable<IndicadorMensal> listModels = new List<IndicadorMensal>
            {
                new IndicadorMensal(1, "Ipsum", DateTime.Now.Date.AddDays(1)),
                new IndicadorMensal(2, "Qualy", DateTime.Now.Date),
                new IndicadorMensal(3, "Team", DateTime.Now.Date.AddDays(-1))
            };

            List<IndicadorMensalViewModel> listViewModel = new List<IndicadorMensalViewModel>
            {
                new IndicadorMensalViewModel { Id = 1, Nome = "Ipsum", DataInicio = DateTime.Now.Date.AddDays(1) },
                new IndicadorMensalViewModel { Id = 2, Nome = "Qualy", DataInicio = DateTime.Now.Date },
                new IndicadorMensalViewModel { Id = 3, Nome = "Team", DataInicio = DateTime.Now.Date.AddDays(-1) }
            };

            _mockRepository.Setup(m => m.SearchAsync(It.IsAny<Expression<Func<IndicadorMensal, bool>>>()))
                .Returns(Task.FromResult(listModels));

            _mockMapper.Setup(x => x.Map<IEnumerable<IndicadorMensalViewModel>>(listModels))
               .Returns(listViewModel);

            // Act
            var result = await _service.Search(filter);

            // Assert
            Assert.IsTrue(result.Count() == 3);
        }

        [TestMethod]
        public async Task CreateIndicadorMensalTestOk()
        {
            // Arrange
            var viewModel = new IndicadorMensalViewModel
            {
                Id = 0,
                Nome = "Qualyteam",
                DataInicio = DateTime.Now.Date
            };

            var model = new IndicadorMensal(0, "Qualyteam", DateTime.Now.Date);

            _mockMapper.Setup(x => x.Map<IndicadorMensal>(viewModel))
               .Returns((IndicadorMensalViewModel source) => model);

            _mockMapper.Setup(x => x.Map<IndicadorMensalViewModel>(model))
               .Returns((IndicadorMensal source) => viewModel);

            // Act
            var result = await _service.Create(viewModel);

            // Assert
            Assert.IsFalse(model.ValidationResult == null);
            Assert.IsTrue(model.ValidationResult.IsValid);
        }

        [TestMethod]
        public void CreateIndicadorMensalTestFaillQuandoDataInicioMaiorQueDataAtual()
        {
            // Arrange
            var viewModel = new IndicadorMensalViewModel
            {
                Id = 0,
                Nome = "Qualyteam",
                DataInicio = DateTime.Now.Date.AddDays(1)
            };

            var model = new IndicadorMensal(0, "Qualyteam", DateTime.Now.Date.AddDays(1));

            _mockMapper.Setup(x => x.Map<IndicadorMensal>(viewModel))
               .Returns((IndicadorMensalViewModel source) => model);

            _mockMapper.Setup(x => x.Map<IndicadorMensalViewModel>(model))
               .Returns((IndicadorMensal source) => viewModel);

            // Act
            var result = _service.Create(viewModel);

            // Assert
            Assert.IsFalse(model.ValidationResult.IsValid);
            Assert.IsTrue(model.ValidationResult.Errors.Count > 0);
            Assert.IsTrue(model.ValidationResult.ToString() == Messages.MSG02);
        }

        [TestMethod]
        public void CreateIndicadorMensalTestFaillQuandoNomeNaoForInformado()
        {
            // Arrange
            var viewModel = new IndicadorMensalViewModel
            {
                Id = 0,
                Nome = "",
                DataInicio = DateTime.Now.Date
            };

            var model = new IndicadorMensal(0, "", DateTime.Now.Date);

            _mockMapper.Setup(x => x.Map<IndicadorMensal>(viewModel))
               .Returns((IndicadorMensalViewModel source) => model);

            _mockMapper.Setup(x => x.Map<IndicadorMensalViewModel>(model))
               .Returns((IndicadorMensal source) => viewModel);

            // Act
            var result = _service.Create(viewModel);

            // Assert
            Assert.IsFalse(model.ValidationResult.IsValid);
            Assert.IsTrue(model.ValidationResult.Errors.Count > 0);
            Assert.IsTrue(model.ValidationResult.ToString() == Messages.MSG01);
        }

        [TestMethod]
        public async Task UpdateIndicadorMensalTestOk()
        {
            // Arrange
            var viewModel = new IndicadorMensalViewModel
            {
                Id = 1,
                Nome = "Qualyteam",
                DataInicio = DateTime.Now.Date
            };

            var model = new IndicadorMensal(1, "Qualyteam", DateTime.Now.Date);

            _mockMapper.Setup(x => x.Map<IndicadorMensal>(viewModel))
               .Returns((IndicadorMensalViewModel source) => model);

            _mockMapper.Setup(x => x.Map<IndicadorMensalViewModel>(model))
               .Returns((IndicadorMensal source) => viewModel);

            // Act
            var result = await _service.Update(viewModel);

            // Assert
            Assert.IsFalse(model.ValidationResult == null);
            Assert.IsTrue(model.ValidationResult.IsValid);
        }

        [TestMethod]
        public void UpdateIndicadorMensalTestFaillQuandoDataInicioMaiorQueDataAtual()
        {
            // Arrange
            var viewModel = new IndicadorMensalViewModel
            {
                Id = 1,
                Nome = "Qualyteam",
                DataInicio = DateTime.Now.Date.AddDays(1)
            };

            var model = new IndicadorMensal(1, "Qualyteam", DateTime.Now.Date.AddDays(1));

            _mockMapper.Setup(x => x.Map<IndicadorMensal>(viewModel))
               .Returns((IndicadorMensalViewModel source) => model);

            _mockMapper.Setup(x => x.Map<IndicadorMensalViewModel>(model))
               .Returns((IndicadorMensal source) => viewModel);

            // Act
            var result = _service.Update(viewModel);

            // Assert
            Assert.IsFalse(model.ValidationResult.IsValid);
            Assert.IsTrue(model.ValidationResult.Errors.Count > 0);
            Assert.IsTrue(model.ValidationResult.ToString() == Messages.MSG02);
        }

        [TestMethod]
        public void UpdateIndicadorMensalTestFaillQuandoNomeNaoForInformado()
        {
            // Arrange
            var viewModel = new IndicadorMensalViewModel
            {
                Id = 1,
                Nome = "",
                DataInicio = DateTime.Now.Date
            };

            var model = new IndicadorMensal(1, "", DateTime.Now.Date);

            _mockMapper.Setup(x => x.Map<IndicadorMensal>(viewModel))
               .Returns((IndicadorMensalViewModel source) => model);

            _mockMapper.Setup(x => x.Map<IndicadorMensalViewModel>(model))
               .Returns((IndicadorMensal source) => viewModel);

            // Act
            var result = _service.Update(viewModel);

            // Assert
            Assert.IsFalse(model.ValidationResult.IsValid);
            Assert.IsTrue(model.ValidationResult.Errors.Count > 0);
            Assert.IsTrue(model.ValidationResult.ToString() == Messages.MSG01);
        }
    }
}
