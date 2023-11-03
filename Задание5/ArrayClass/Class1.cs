using System;
using System.Collections.Generic;


namespace ArrayClass
{
    /// <summary>
    /// Класс для работы с одномерными массивами
    /// </summary>
    public class ArrayClass
    {
        /// <summary>
        /// Находит и удаляет все элементы массива, кратные заданному числу (делителю)
        /// </summary>
        /// <param name="input">Входной массив</param>
        /// <param name="divider">Делитель</param>
        /// <param name="indexes">Индексы удаленных элементов</param>
        /// <returns>Измененный массив</returns>
        public static int[] RemoveDividableNumbers(int[] input, int divider, out int[] indexes)
        {
            // Стандартные проверки.
            if (input.Length == 0) throw new Exception("Массив пуст!");
            if (divider == 0) throw new Exception("Делитель не может быть нулём!");

            // Конвертируем в список для удобства работы.
            List<int> list = new List<int>(input);

            // По такой же причине создаем список для удаленных индексов.
            List<int> indexesList = new List<int>();

            // Основной цикл.
            for(int i = 0; i < input.Length; i++)
            {
                if(input[i] % divider == 0)
                {
                    // Записываем индекс в список.
                    indexesList.Add(i);          
                    // Удаляем этот элемент из списка.
                    list.Remove(input[i]);
                }
            }
            // Преобразуем в обычные массивы.
            indexes = indexesList.ToArray();
            return list.ToArray();
        }
    }
}
