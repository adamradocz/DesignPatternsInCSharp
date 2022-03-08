using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsInCSharp.Structural.Decorator.RealLife;

public class SedanWithHeatedSeats : SedanWithExtras
{
    public SedanWithHeatedSeats(ICar car) : base(car)
    {
        Car.Extras.Add("Heated Seats");
        Car.Price += 80;
    }
}
