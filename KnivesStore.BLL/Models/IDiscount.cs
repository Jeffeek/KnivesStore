using System;
using System.Collections.Generic;
using System.Text;

namespace KnivesStore.BLL.Models
{
    public interface IDiscount
    {
        int Percentage { get; }
        double GetTotalPriceWithDiscount(int sum);
    }
}
