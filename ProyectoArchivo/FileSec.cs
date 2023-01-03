using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoArchivo
{
    class FileSec
    {
        private string NameFile;
        private FileStream Stream;
        private BinaryWriter Writer;
        private BinaryReader Reader;

        public FileSec()
        {
            NameFile = "";
        }

        // Create
        public void Open_Create(string namePath)
        {
            NameFile = namePath;
            Stream = new FileStream(NameFile, FileMode.Create, FileAccess.Write);
            Writer = new BinaryWriter(Stream);
        }

        public void Create(int value)
        {
            Writer.Write(value);
        }

        public void Close_Create()
        {
            Stream.Close();
            Writer.Close();
        }

        // Read
        public void Open_Read(string pathName)
        {
            NameFile = pathName;
            Stream = new FileStream(NameFile, FileMode.Open, FileAccess.Read);
            Reader = new BinaryReader(Stream);
        }

        public int Read()
        {
            return Reader.ReadInt32();
        }

        public void Close_Read()
        {
            Stream.Close();
            Reader.Close();
        }

        //Check if is Finished
        public bool IsFinalPosition()
        {
            return Stream.Position == Stream.Length;
        }

        // Save in new File: elements with equal digits
        public void Exercise1(string pathName, ref FileSec F2)
        {
            IntegerNumber num1 = new IntegerNumber();
            this.Open_Read(NameFile);
            F2.Open_Create(pathName);
            while (!this.IsFinalPosition())
            {
                num1.SetNumber(this.Read());
                if (num1.IsDigitEqual())
                {
                    F2.Create(num1.GetNumber());
                }
            }
            this.Close_Read();
            F2.Close_Create();
        }

        public void Exercise2(string pathName, ref FileSec F2)
        {
            IntegerNumber num1 = new IntegerNumber();
            this.Open_Read(NameFile);
            F2.Open_Create(pathName);
            while (!this.IsFinalPosition())
            {
                num1.SetNumber(this.Read());
                if (num1.IsDigitDifferent())
                {
                    F2.Create(num1.GetNumber());
                }
            }
            this.Close_Read();
            F2.Close_Create();
        }

        public void Exercise3(string pathName, ref FileSec F2, int r)
        {
            IntegerNumber num1 = new IntegerNumber();
            this.Open_Read(NameFile);
            F2.Open_Create(pathName);
            while (!this.IsFinalPosition())
            {
                num1.SetNumber(this.Read());
                if (num1.IsDigitOderWithReason(r))
                {
                    F2.Create(num1.GetNumber());
                }
            }
            this.Close_Read();
            F2.Close_Create();
        }

        public void Exercise4(string pathName1, string pathName2, string pathName3, ref FileSec F2, ref FileSec F3)
        {
            this.Open_Read(pathName1);
            F2.Open_Read(pathName2);
            F3.Open_Create(pathName3);
            int[] v2 = new int[0]; int i = 0;
            while (!this.IsFinalPosition())
            {
                Array.Resize(ref v2, v2.Length + 1);
                v2[i] = this.Read();
                i++;
            }
            while (!F2.IsFinalPosition())
            {
                Array.Resize(ref v2, v2.Length + 1);
                v2[i] = F2.Read();
                i++;
            }
            Array.Sort(v2);
            for (int j = 0; j < v2.Length; j++)
            {
                F3.Create(v2[j]);
            }
            this.Close_Read();
            F2.Close_Read();
            F3.Close_Create();
        }
    }
}
