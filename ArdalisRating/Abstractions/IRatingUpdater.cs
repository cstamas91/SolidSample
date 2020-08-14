using System;
using System.Collections.Generic;
using System.Text;

namespace ArdalisRating.Abstractions
{
    public interface IRatingUpdater 
    {
        void UpdateRating(decimal rating);
    }
}
