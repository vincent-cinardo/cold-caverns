using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Heap<T> where T : IHeapItem<T>
{
    public T[] nodes;
    public int count;
    public Heap()
    {
        nodes = new T[100*100];
        count = 0;
    }

    public Heap(int heapSize)
    {
        nodes = new T[heapSize];
        count = 0;
    }

    public void AddNode(T node)
    {
        nodes[count] = node;
        nodes[count].n = count;
        SortUp();
        count++;
    }
    public T GetRoot()
    {
        return nodes[0];
    }
    public T RemoveRoot()
    {
        count--;
        T firstNode = nodes[0];
        T lastNode = nodes[count];
        nodes[0] = lastNode;
        nodes[0].n = 0;
        SortDown();
        return firstNode;
    }

    void SortUp()
    {
        int n = count;
        int nParent = (n - 1) / 2;

        //While node > parent
        while (nodes[n].CompareTo(nodes[nParent]) < 0)
        {
            Swap(nodes[n], nodes[nParent]);
            n = nParent;
            nParent = (n - 1) / 2;
        }
    }
    void SortDown()
    {
        int swap = 0;
        T node = nodes[0];

        while (true)
        {    
            int left = 2 * swap + 1;
            int right = 2 * swap + 2;

            if (left < count)
            {
                swap = left;
                if (right < count)
                {
                    if (nodes[left].CompareTo(nodes[right]) < 0)
                    {
                        swap = right;
                    }
                }
                
                if (node.CompareTo(nodes[swap]) < 0)
                {
                    Swap(node, nodes[swap]);
                    node = nodes[swap];
                }
                else return;
            }
            else return;
            
        }
    }

    void Swap(T first, T second)
    {
        nodes[first.n] = second;
        nodes[second.n] = first;
        int swapN = first.n;
        first.n = second.n;
        second.n = swapN;
    }

    public bool Contains(T item)
    {
        foreach (T t in nodes)
        {
            if (item.Equals(t))
            {
                return true;
            }
        }
        return false;
    }
}

public interface IHeapItem<T> : IComparable<T>
{ 
    public int n {get; set;}
}