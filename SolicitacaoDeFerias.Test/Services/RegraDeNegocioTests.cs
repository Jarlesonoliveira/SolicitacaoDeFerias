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
            Moq.Mock<IRegra1> mock = new Mock<IRegra1>();
            mock.Setup(x => x.DataFinalMaiorQueDataInicio(It.IsAny<DateTime>(), It.IsAny<DateTime>(), true)).Returns(true);
            Regra1 DFMQI = new Regra1();

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
            Moq.Mock<IRegra2> mock = new Mock<IRegra2>();
            mock.Setup(x => x.DiaDaSemanaLiberado(It.IsAny<DateTime>(), It.IsAny<List<DayOfWeek>>(), true)).Returns(true);
            Regra2 DDSL = new Regra2();

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
            Moq.Mock<IRegra3> mock = new Mock<IRegra3>();
            mock.Setup(x => x.DataDeInicioAntecedeFeriado(It.IsAny<DateTime>(), true)).Returns(true);
            Regra3 DDIAF = new Regra3();

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
            Moq.Mock<IRegra4> mock = new Mock<IRegra4>();
            mock.Setup(x => x.QuarentaDiasDeAntecedencia(It.IsAny<DateTime>(), It.IsAny<DateTime>(), true));
            Regra4 QDA = new Regra4();

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
            Moq.Mock<IRegra5> mock = new Mock<IRegra5>();
            mock.Setup(x => x.FeriasDentroDoLimiteDeDias(It.IsAny<DateTime>(), It.IsAny<DateTime>(), It.IsAny<int>(), true)).Returns(true);
            Regra5 FDLD = new Regra5();

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
            Moq.Mock<IRegra6> mock = new Mock<IRegra6>();
            mock.Setup(x => x.FeriasDentroDoLimiteMinimoDeDias(It.IsAny<DateTime>(), It.IsAny<DateTime>(), It.IsAny<int>(), true)).Returns(true);
            Regra6 FDLDD = new Regra6();

            //Act
            int limite = 10;
            var op = FDLDD.FeriasDentroDoLimiteMinimoDeDias(new DateTime(01 / 02 / 2023), new DateTime( 01/ 02 / 2023), limite, valid);

            //Assert
            Assert.True(op);
        }
    }
}
