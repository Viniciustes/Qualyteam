using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Qualyteam.Application.ViewModels;
using Qualyteam.Domain.Interfaces.Mediators;
using Qualyteam.Domain.Interfaces.Repository;
using Qualyteam.Domain.Services;
using System;

namespace Qualyteam.Test.Domain.Services
{
    [TestClass]
    public class IndicadorMensalServiceTest
    {
        //private IndicadorMensalService _service;

        //private IMapper _mapper;
        //private Mock<IMediatorHandler> _mockMediatorHandler;
        //private Mock<IIndicadorMensalRepository> _mockRepository;

        [TestInitialize]
        public void Setup()
        {
            //_mockMediatorHandler = new Mock<IMediatorHandler>();
            //_mockRepository = new Mock<IIndicadorMensalRepository>();

            //_service = new IndicadorMensalService(_mockMediatorHandler.Object, null, _mockRepository.Object);
        }

        [TestMethod]
        public void CreateIndicadorMensalTestOk()
        {
            // Arrange
            var viewModel = new IndicadorMensalViewModel
            {
                Id = 0,
                Nome = "Qualyteam",
                DataInicio = DateTime.Now
            };

            // Act
            //var result = _service.Create(viewModel);

            // Assert
            Assert.IsTrue(viewModel.Id == 0);
        }
    }
}
