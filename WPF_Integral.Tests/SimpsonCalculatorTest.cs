using WPF_Integral.Classes;

namespace WPF_Integral.Tests
{
    public class SimpsonCalculatorTest
    {
        // Тест 1. Интеграл x^2 на [0; 100] = 1000000/3 = 333333,3333
        [Fact]
        public void Simpson_XX_Return_Correct_Answer()
        {
            //Arrange (Подготовка)
            double upperLimit = 100;
            double lowerLimit = 0;
            int count = 1000;
            Func<double, double> integralFunction = x => x * x;

            double expectedResult = 333333.3333;

            //Act (Действия)
            SimpsonCalculator calculator = new SimpsonCalculator();
            double actualResult = calculator.Intagrate(lowerLimit, upperLimit, count, integralFunction);

            //Assert (Сравнение)
            Assert.Equal(expectedResult, actualResult, 0.01);
        }

        // Тест 2. Функция из варианта: 2x - ln(2x) + 234 на [1; 10] = 2184,7358
        [Fact]
        public void Simpson_Variant_Function_Return_Correct_Answer()
        {
            //Arrange (Подготовка)
            double upperLimit = 10;
            double lowerLimit = 1;
            int count = 1000;
            Func<double, double> integralFunction = x => 2 * x - Math.Log(2 * x) + 234;

            double expectedResult = 2184.7358;

            //Act (Действия)
            SimpsonCalculator calculator = new SimpsonCalculator();
            double actualResult = calculator.Intagrate(lowerLimit, upperLimit, count, integralFunction);

            //Assert (Сравнение)
            Assert.Equal(expectedResult, actualResult, 0.01);
        }

        // Тест 3. Метод Симпсона требует чётное количество разбиений,
        // при нечётном count должно выбрасываться исключение ArgumentException
        [Fact]
        public void Simpson_Count_Odd_Throws_ArgumentException()
        {
            //Arrange (Подготовка)
            double upperLimit = 100;
            double lowerLimit = 0;
            int count = 1001;
            Func<double, double> integralFunction = x => x * x;

            //Act (Действия)
            SimpsonCalculator calculator = new SimpsonCalculator();

            //Assert (Сравнение)
            Assert.Throws<ArgumentException>(() => calculator.Intagrate(lowerLimit, upperLimit, count, integralFunction));
        }
    }
}
