using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoArchivo
{
    class IntegerNumber
    {
        private int number;

        public IntegerNumber()
        {
            number = 0;
        }

        public void SetNumber(int value)
        {
            number = value;
        }

        public int GetNumber()
        {
            return number;
        }

        public bool IsDigitEqual()
        {
            bool isEqual = true;
            int dig1, dig2, num = number;
            dig1 = num % 10;
            num = num / 10;
            while (num > 0)
            {
                dig2 = num % 10;
                if (dig1 != dig2)
                    isEqual = false;
                num = num / 10;
            }
            return isEqual;
        }

        public bool isEqual(int num, int digit)
        {
            bool isEqual = false;
            int dig;
            while (num > 0)
            {
                dig = num % 10;
                num /= 10;
                if (digit == dig)
                    isEqual = true;
            }

            return isEqual;
        }

        public bool IsDigitDifferent()
        {
            bool isDifferent = true;
            int dig, num1 = number;
            while (num1 > 0)
            {
                dig = num1 % 10;
                num1 /= 10;
                if (this.isEqual(num1, dig))
                    isDifferent = false;
            }
            return isDifferent;
        }

        public bool IsDigitOderWithReason(int r = 1)
        {
            bool isOrder = false, asc = true, desc = true;
            int dig1, dig2, num = number;
            dig1 = num % 10;
            num /= 10;
            while (num > 0)
            {
                dig2 = num % 10;
                num /= 10;
                if ((dig2 > dig1) && (dig2 == dig1 + r) && asc)
                {
                    dig1 = dig2;
                    isOrder = true;
                    desc = false;
                }
                else if ((dig2 < dig1) && (dig2 + r == dig1) && desc)
                {
                    dig1 = dig2;
                    isOrder = true;
                    asc = false;
                }
                else
                {
                    isOrder = false;
                    break;
                }
            }
            return isOrder;
        }
    }
}
