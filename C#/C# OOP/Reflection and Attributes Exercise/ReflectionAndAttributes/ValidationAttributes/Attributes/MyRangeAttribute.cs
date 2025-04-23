using System;
using System.Collections.Generic;
using System.Text;

namespace ValidationAttributes.Attributes
{
    public class MyRangeAttribute : MyValidationAttribute
    {
        private readonly int minValue;
        private readonly int maxValue;

        public MyRangeAttribute(int minValue, int maxValue)
        {
            ValidateRange(minValue, maxValue);

            this.minValue = minValue;
            this.maxValue = maxValue;
        }

        public override bool IsValid(object obj)
        {
            if (obj is int)
            {
                int value = (int)obj;

                if (value < minValue || maxValue < value)
                {
                    return false;
                }

                return true;
            }
            else
            {
                throw new ArgumentException("The given data type is not Int32!");
            }
        }

        private void ValidateRange(int min, int max)
        {
            if(min > max)
            {
                throw new ArgumentException("The value is out of range!");
            }
        }
    }
}
