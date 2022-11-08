﻿/// <remark>
/// Этот класс генерирует простые числа, не превышающие заданного
/// пользователем порога. В качестве алгоритма используется решето
/// Эратосфена.
///
/// Эратосфен Киренский, 276 г. до н. э., Кирена, Ливия --
/// 194 г. до н. э., Александрия. Впервые измерил окружность Земли.
/// Известен также работами по составлению календаря с високосными
/// годами. Работал в Александрийской библиотеке.
///
/// Сам алгоритм прост. Пусть дан массив целых чисел, начинающийся
/// с 2. Вычеркиваем все кратные 2. Находим первое невычеркнутое
/// число и вычеркиваем все его кратные. Повторяем, пока не
/// дойдем до квадратного корня из максимального значения.
///
/// Написал Роберт К. Мартин 9.12.1999 на языке Java
/// Перевел на C# Мика Мартин 12.01.2005.
///</remark>
using System;
/// <summary>
/// автор: Роберт К. Мартин
/// </summary>
public class GeneratePrimes
{
    ///<summary>
    /// Генерирует массив простых чисел.
    ///</summary>
    ///
    /// <param name=”maxValue”>Верхний порог.</param>
    public static int[] GeneratePrimeNumbers(int maxValue)
    {
        if (maxValue >= 2) // единственный допустимый случай
        {
            // объявления
            int s = maxValue + 1; // размер массива
            bool[] f = new bool[s];
            int i;
            // инициализировать элементы массива значением true.
            for (i = 0; i < s; i++)
                f[i] = true;
            // исключить заведомо не простые числа
            f[0] = f[1] = false;
            // решето
            int j;
            for (i = 2; i < Math.Sqrt(s) + 1; i++)
            {
                if (f[i]) // если i не вычеркнуто, вычеркнуть его кратные.
                {
                    for (j = 2 * i; j < s; j += i)
                        f[j] = false; // кратное – не простое число
                }
            }
            // сколько оказалось простых чисел?
            int count = 0;
            for (i = 0; i < s; i++)
            {
                if (f[i])
                    count++; // увеличить счетчик
            }
            int[] primes = new int[count];
            // поместить простые числа в результирующий массив
            for (i = 0, j = 0; i < s; i++)
            {
                if (f[i]) // если простое
                    primes[j++] = i;
            }
            return primes; // вернуть простые числа
        }
        else // maxValue < 2
            return new int[0]; // если входные данные не корректны,
                               // возвращаем пустой массив
    }
}
