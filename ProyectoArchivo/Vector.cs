using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoArchivo
{
    class Vector
    {
        private int numElements;
        private int[] v;

        public Vector()
        {
            numElements = 0; v = new int[0];
        }

        void ResizeVector()
        {
            Array.Resize(ref v, v.Length + 1);
        }

        public void intercambio(int c1, int c2)
        {
            int aux = v[c1];
            v[c1] = v[c2];
            v[c2] = aux;
        }

        public void SortVector()
        {
            for (int i = 0; i < numElements; i++)
                for (int j = i + 1; j < numElements; j++)
                    if (v[i] > v[j])
                        intercambio(i, j);
        }

        public bool IsOrder()
        {
            bool isOrder = true;
            for (int i = 0; i < numElements - 1; i++)
                if (v[i] > v[i + 1])
                    isOrder = false;
            return isOrder;
        }

        public void SetNumbers(int num, int min, int max)
        {
            numElements = num;
            Random numRandom = new Random();
            for (int i = 0; i < num; i++)
            {
                ResizeVector();
                v[i] = numRandom.Next(min, max);
            }
        }

        public string GetNumbers()
        {
            string strNumbers = "";
            for (int i = 0; i < numElements; i++)
            {
                if (i == numElements - 1)
                    strNumbers = strNumbers + v[i].ToString();
                else
                    strNumbers = strNumbers + v[i].ToString() + ",   ";
            }
            return strNumbers;
        }

        public void Grabar(string namePath, ref FileSec F1)
        {
            F1.Open_Create(namePath);
            for (int i = 0; i < numElements; i++)
            {
                F1.Create(v[i]);
            }
            F1.Close_Create();
        }

        public void Read(string namePath, ref FileSec F1)
        {
            F1.Open_Read(namePath);
            int i = 0;
            while (!F1.IsFinalPosition())
            {
                this.ResizeVector();
                v[i] = F1.Read();
                i++;
            }
            F1.Close_Read();
            numElements = i;
        }

        // Save in new File: elements with equal digits
        public void Exercise1(ref Vector v2)
        {
            IntegerNumber num1 = new IntegerNumber();
            int j = 0;
            for (int i = 0; i < numElements; i++)
            {
                num1.SetNumber(v[i]);
                if (num1.IsDigitEqual())
                {
                    v2.ResizeVector();
                    v2.v[j] = v[i];
                    j++;
                }
            }
            v2.numElements = j;
        }

        public void Exercise2(ref Vector v2)
        {
            IntegerNumber num1 = new IntegerNumber();
            int j = 0;
            for (int i = 0; i < numElements; i++)
            {
                num1.SetNumber(v[i]);
                if (num1.IsDigitDifferent())
                {
                    v2.ResizeVector();
                    v2.v[j] = v[i];
                    j++;
                }
            }
            v2.numElements = j;
        }

        public void Exercise3(ref Vector v2, int r = 1)
        {
            IntegerNumber num1 = new IntegerNumber();
            int j = 0;
            for (int i = 0; i < numElements; i++)
            {
                num1.SetNumber(v[i]);
                if (num1.IsDigitOderWithReason(r))
                {
                    v2.ResizeVector();
                    v2.v[j] = v[i];
                    j++;
                }
            }
            v2.numElements = j;
        }
    }
}
