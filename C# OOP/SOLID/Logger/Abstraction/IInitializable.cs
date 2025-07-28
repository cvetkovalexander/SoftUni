using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logging.Abstraction;

public interface IInitializable
{
    // NOTE: May be used in future
    // bool IsInitialized { get; }

    void Initialize();
}