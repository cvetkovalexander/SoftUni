using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationAttributes.Attributes;

public class MyLengthAttribute : MyValidationAttribute
{
    private readonly int _minLength;
    private readonly int? _maxLength;

    public MyLengthAttribute(int minLength)
    {
        this._minLength = minLength;
    }

    public MyLengthAttribute(int minLength, int maxLength) : this(minLength)
    {
        if (maxLength < minLength)
            throw new ArgumentException("Max length should be greater than or equal to min length.");

        this._maxLength = maxLength;
    }

    public override IEnumerable<string> Validate(string path, object val)
    {
        if (val is null) yield break;

        int length;
        if (val is ICollection collection) length = collection.Count;
        else if (val is string text) length = text.Length;
        else
        {
            yield return $"{path} is not a sequence of elements.";
            yield break;
        }

        if (length < this._minLength || (this._maxLength.HasValue && this._maxLength < length))
        {
            string range;
            if (this._maxLength.HasValue) range = $"[{this._minLength}, {this._maxLength}]";
            else range = $"[{this._minLength}, Inf]";

            yield return $"The length of {path} should be an integer in range {range}";
        }
    }
}
