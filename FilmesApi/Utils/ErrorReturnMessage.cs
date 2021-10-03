using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesApi.Utils
{
    public class RangeMsg : ValidationAttribute
    {
        public readonly string? _ErrorMessage;
        public double? _minimum { get; set; }
        public double? _maximum { get; set; }
        public RangeMsg(double minimum, double maximum) :base()
        {
            base.ErrorMessage = $"range_{minimum}_to_{maximum}";
            _minimum = minimum;
            _maximum = maximum;
        }


        public override bool IsValid(object? value)
        {
            var i = int.Parse(value.ToString());
            return i>= _minimum & i<= _maximum;
        }
    }
}
