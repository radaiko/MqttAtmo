using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netatmo.Model
{
    public enum EScale
    {
        min30,
        hour1,
        hours3,
        day1,
        week1,
        month1
    }
    public static class EScaleExtensions
    {
        public static string ToRevertString(this EScale scale)
        {
            var number = Utils.GetAllNumberFromString(scale.ToString());
            var text = Utils.GetAllLetterFromString(scale.ToString()); ;
            return number+text;
        }

        
    }
}
