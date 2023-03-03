using Moq;
using SolicitacaoDeFerias.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace SolicitacaoDeFerias.Test.Services
{
    public class RegraDeNegocioTests
    {

        [Fact]
        public void DataFinalMaiorQueDataInicio()
        {
            bool valid = true;

            //Arrange
            Moq.Mock<IRegraDeNegocio> mock = new Mock<IRegraDeNegocio>();
            mock.Setup(x => x.DataFinalMaiorQueDataInicio(It.IsAny<DateTime>(), It.IsAny<DateTime>(), true)).Returns(true);
            RegraDeNegocio DFMQI = new RegraDeNegocio();

            //Act
            var op = DFMQI.DataFinalMaiorQueDataInicio(new DateTime(20 / 02 / 2023), new DateTime(19 / 02 / 2023), valid);

            //Assert
            Assert.True(op);

        }
        [Fact]
        public void DiaDaSemanaLiberado()
        {
            bool valid = true;

            //Arrange
            Moq.Mock<IRegraDeNegocio> mock = new Mock<IRegraDeNegocio>();
            mock.Setup(x => x.DiaDaSemanaLiberado(It.IsAny<DateTime>(), It.IsAny<List<DayOfWeek>>(), true)).Returns(true);
            RegraDeNegocio DDSL = new RegraDeNegocio();

            //Act
            var op = DDSL.DiaDaSemanaLiberado(new DateTime(20 / 02 / 2023), new List<DayOfWeek>((int) DayOfWeek.Monday), valid);

            //Assert
            Assert.False(op);

        }
        [Fact]
        public void DataDeInicioAntecedeFeriado()
        {
            bool valid = true;

            //Arrange
            Moq.Mock<IRegraDeNegocio> mock = new Mock<IRegraDeNegocio>();
            mock.Setup(x => x.DataDeInicioAntecedeFeriado(It.IsAny<DateTime>(), true)).Returns(true);
            RegraDeNegocio DDIAF = new RegraDeNegocio();

            //Act
            var op = DDIAF.DataDeInicioAntecedeFeriado(new DateTime(25 / 02 / 2023), valid);

            //Assert
            Assert.True(op);
        }
        [Fact]
        public void QuarentaDiasDeAntecedencia()
        {
            bool valid = true;

            //Arrange
            Moq.Mock<IRegraDeNegocio> mock = new Mock<IRegraDeNegocio>();
            mock.Setup(x => x.QuarentaDiasDeAntecedencia(It.IsAny<DateTime>(), It.IsAny<DateTime>(), true));
            RegraDeNegocio QDA = new RegraDeNegocio();

            //Act
            var op = QDA.QuarentaDiasDeAntecedencia(new DateTime(01 / 02 / 2023), new DateTime(25 / 02 / 2023), valid);

            //Assert
            Assert.False(op);
        }
        [Fact]
        public void FeriasDentroDoLimiteDeDias()
        {
            bool valid = true;


            //Arrange            
            Moq.Mock<IRegraDeNegocio> mock = new Mock<IRegraDeNegocio>();
            mock.Setup(x => x.FeriasDentroDoLimiteDeDias(It.IsAny<DateTime>(), It.IsAny<DateTime>(), It.IsAny<int>(), true)).Returns(true);
            RegraDeNegocio FDLD = new RegraDeNegocio();

            //Act
            int limite = 30;
            var op = FDLD.FeriasDentroDoLimiteDeDias(new DateTime(25 / 02 / 2023), new DateTime(25 / 02 / 2023), limite,  valid);

            //Assert
            Assert.True(op);
        }
        [Fact]
        public void FeriasDentroDoLimiteMinimoDeDias()
        {
            bool valid = true;

            //Arrange
            Moq.Mock<IRegraDeNegocio> mock = new Mock<IRegraDeNegocio>();
            mock.Setup(x => x.FeriasDentroDoLimiteMinimoDeDias(It.IsAny<DateTime>(), It.IsAny<DateTime>(), It.IsAny<int>(), true)).Returns(true);
            RegraDeNegocio FDLDD = new RegraDeNegocio();

            //Act
            int limite = 10;
            var op = FDLDD.FeriasDentroDoLimiteMinimoDeDias(new DateTime(01 / 02 / 2023), new DateTime( 01/ 02 / 2023), limite, valid);

            //Assert
            Assert.True(op);
        }
    }
}
