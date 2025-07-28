using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationAttributes.Attributes;

public class MyValidCollectionAttribute : MyValidationAttribute
{
    public override IEnumerable<string> Validate(string path, object val)
    {
        if (val is null) yield break;

        if (val is not IEnumerable collection)
            yield return $"{path} should be a collection.";
        else
        {
            int index = 0;
            foreach (object el in collection)
            {
                foreach (string error in Validator.Validate(el, $"{path}[{index}]"))
                    yield return error;

                index++;
            }

        }
    }
}