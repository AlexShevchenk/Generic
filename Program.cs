using System;
using System.Collections.Generic;

public class MyList<T> where T : IComparable<T>
{
    private T[] array;
    private int count;
    private int capacity;

    public MyList()
    {
        capacity = 4; // Початкова ємність списку
        array = new T[capacity];
        count = 0;
    }

    public void Add(T item)
    {
        if (count == capacity)
        {
            capacity *= 2; // Збільшуємо ємність списку вдвічі, якщо список заповнений
            Array.Resize(ref array, capacity);
        }
        array[count] = item;
        count++;
    }

    public void AddRange(IEnumerable<T> collection)
    {
        foreach (T item in collection)
        {
            Add(item);
        }
    }

    public bool Remove(T item)
    {
        int index = IndexOf(item);
        if (index >= 0)
        {
            RemoveAt(index);
            return true;
        }
        else
        {
            return false;
        }
    }

    public void RemoveAt(int index)
    {
        for (int i = index; i < count - 1; i++)
        {
            array[i] = array[i + 1];
        }
        count--;
    }

    public void Sort()
    {
        Array.Sort(array, 0, count);
    }

    public int IndexOf(T item)
    {
        for (int i = 0; i < count; i++)
        {
            if (array[i].Equals(item))
            {
                return i;
            }
        }
        return -1;
    }
}
