using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ArrayClassTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ArrayResultTest01()
        {
            int[] input = new int[5] { 1, 2, 3, 4, 5 };
            int[] expected = new int[3] { 1, 3, 5 };
            int[] expectedIndexes = new int[2] { 1, 3 };

            int divider = 2;

            int[] actualIndexes;
            int[] actual = ArrayClass.ArrayClass.RemoveDividableNumbers(input, divider, out actualIndexes);

            CollectionAssert.AreEqual(expected, actual, $"Итоговые массивы не совпадают!");
        }
        [TestMethod]
        public void ArrayResultTest02()
        {
            // создаем случайный массив для тестирования
            Random rnd = new Random();
            int[] input = new int[9];
            List<int> expected = new List<int>();
            int divider = rnd.Next(4, 30);

            for(int i = 0; i < rnd.Next(3, 9); i++)
            {
                input[i] = rnd.Next(1, 10) * divider;
            }
            Shuffle<int>(rnd, input);
            for (int i = 0; i < 9; i++)
            {
                if (input[i] == 0)
                {
                    while(input[i] % divider == 0) input[i] = rnd.Next(1, 300);
                    expected.Add(input[i]);
                }
            }
            
            

            int[] actualIndexes;
            int[] actual = ArrayClass.ArrayClass.RemoveDividableNumbers(input, divider, out actualIndexes);

            CollectionAssert.AreEqual(expected, actual, $"Итоговые массивы не совпадают!");
        }

        [TestMethod]
        public void ArrayIndexesTest()
        {
            int[] input = new int[5] { 1, 2, 3, 4, 5 };
            int[] expectedIndexes = new int[2] { 1, 3 };

            int divider = 2;

            int[] actualIndexes;
            int[] actual = ArrayClass.ArrayClass.RemoveDividableNumbers(input, divider, out actualIndexes);

            CollectionAssert.AreEqual(expectedIndexes, actualIndexes, $"Итоговые массивы не совпадают!");
        }

        [TestMethod]
        public void ArrayZeroLengthTest()
        {
            int[] input = new int[0] {};
            int divider = 2;

            try
            {
                int[] actualIndexes;
                int[] actual = ArrayClass.ArrayClass.RemoveDividableNumbers(input, divider, out actualIndexes);
            }
            catch (Exception ex)
            {
                StringAssert.Contains(ex.Message, "Массив пуст!");
                return;
            }
            Assert.Fail("Исключение не было получено!");
        }
        [TestMethod]
        public void ArrayZeroDividerTest()
        {
            int[] input = new int[5] { 1, 2, 3, 4, 5 };
            int[] expected = new int[3] { 1, 3, 5 };
            int divider = 0;

            try
            {
                int[] actualIndexes;
                int[] actual = ArrayClass.ArrayClass.RemoveDividableNumbers(input, divider, out actualIndexes);
            }
            catch (Exception ex)
            {
                StringAssert.Contains(ex.Message, "Делитель не может быть нулём!");
                return;
            }
            Assert.Fail("Исключение не было получено!");
        }
        [TestMethod]
        public void ArrayFailTest()
        {
            int[] input = new int[5] { 1, 2, 3, 4, 5 };
            int[] expected = new int[3] { 1, 3, 5 };
            int divider = 0;

            try
            {
                int[] actualIndexes;
                int[] actual = ArrayClass.ArrayClass.RemoveDividableNumbers(input, divider, out actualIndexes);
            }
            catch (Exception ex)
            {
                Assert.Fail($"Было получено исключение {ex.Message}!");
            }
        }
        // метод для перемешивания массива
        public static void Shuffle<T>(Random rng, T[] array)
        {
            int n = array.Length;
            while (n > 1)
            {
                int k = rng.Next(n--);
                T temp = array[n];
                array[n] = array[k];
                array[k] = temp;
            }
        }
    }
}
