﻿
public class ArrayTransitionNumbersFolder
{
    private int[] ArrayNumbers;
    private const float Multiplier = 1.5f;
    private const int MinSize = 10;
    private int CountNumbers;

    public ArrayTransitionNumbersFolder()
    {
        ArrayNumbers = new int[MinSize];
        CountNumbers = 0;
        for (int i = 0; i < MinSize; i++)
        {
            ArrayNumbers[i] = -100;
        }
    }
    private bool IsFull() => CountNumbers == ArrayNumbers.Length;
    private void EnlargeArray()
    {
        int[] array = new int[(int)(ArrayNumbers.Length * Multiplier)];
        for (int i = 0; i < ArrayNumbers.Length; i++)
        {
            array[i] = ArrayNumbers[i];
        }
        ArrayNumbers = array;
    }
    public void Add(int number)
    {
        if (IsFull()) { EnlargeArray(); }
        ArrayNumbers[CountNumbers] = number;
        CountNumbers++; 
    }
    public int Watch => ArrayNumbers[CountNumbers - 1];
    public void Remove()
    {
        ArrayNumbers[CountNumbers--] = -100;
    }
}

