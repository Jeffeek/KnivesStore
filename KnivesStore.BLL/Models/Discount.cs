using System;

namespace KnivesStore.BLL.Models
{
    public class Discount
    {
        public Discount(int val)
        {
            Value = val;
        }
        public int Value { get; }

        public int GetDiscountedPrice(int sum)
        {
            if (DateTime.Now.Day == 1)
                return (int)(sum - sum * (Value / 100.0));
            return sum;
        }
    }
}
