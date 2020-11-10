using System;

namespace KnivesStore.BLL.Models
{
    public class FirstDayOfWeekDiscount : IDiscount
    {
        public int Percentage { get; } = 20;

        public double GetTotalPriceWithDiscount(int sum)
        {
            if (DateTime.Now.Day == 1)
                return (int)(sum - sum * (Percentage / 100.0));
            return sum;
        }
    }
}
