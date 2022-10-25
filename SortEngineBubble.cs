using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace CSharpSortingAlgos
{
    internal class SortEngineBubble : ISortEngine
    {
        // variables
        private int[] arr; // copy of the array
        private Graphics g; // graphics object
        private int maxVal; // maximum value integer

        // using bursh to draw white and black rectangles into the graphics object
        Brush WhiteBrush = new System.Drawing.SolidBrush(System.Drawing.Color.White);
        Brush BlackBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);

        // construtor
        public SortEngineBubble(int[] arr_In, Graphics g_In, int MaxVal_In)
        {
            arr = arr_In;
            g = g_In;
            maxVal = MaxVal_In;
        }

        public void NextStep()
        {
            int n = arr.Length;
            for (int i = 0; i < n - 1; i++) // step through array
            {
                if (arr[i] > arr[i + 1]) // compare each element to the one after
                {
                    Swap(i, i + 1);
                }
            }
        }

        private void Swap(int i, int p)
        {
            // swap variables
            (arr[i + 1], arr[i]) = (arr[i], arr[i + 1]);

            DrawBar(i, arr[i]);
            DrawBar(p, arr[p]);
        }

        private void DrawBar(int position, int height)
        {
            g.FillRectangle(BlackBrush, position, 0, 1, maxVal); // remove old values
            g.FillRectangle(WhiteBrush, position, maxVal - arr[position], 1, maxVal); // show new values
        }

        public bool IsSorted()
        {
            for (int i = 0; i < arr.Count() - 1; i++)
            {
                if (arr[i] > arr[i + 1]) // if any element is greater than the next element, return false.
                    return false;
            }
            return true;
        }

        public void ReDraw()
        {
            for (int i = 0; i < arr.Count(); i++)
            {
                g.FillRectangle(new System.Drawing.SolidBrush(System.Drawing.Color.White), i, maxVal - arr[i], 1, maxVal);
            }
        }
    }
}
