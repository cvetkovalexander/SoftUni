using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationAttributes.Attributes;

public class MyRangeAttribute : MyValidationAttribute
{
    private readonly int _minValue, _maxValue;
    public MyRangeAttribute(int minValue, int maxValue)
    {
        if (maxValue < minValue) throw new ArgumentException("Max bound should be greater than or equal to min bound.");

        this._minValue = minValue;
        this._maxValue = maxValue;
    }

    public override IEnumerable<string> Validate(string path, object val)
    {
        if (val is not int num || num < this._minValue || this._maxValue < num)
            yield return $"{path} should be an integer in range [{this._minValue}], [{this._maxValue}]";
    }
}
