using System;
using System.Collections.Generic;
using Bunit;
using Microsoft.AspNetCore.Components;

namespace Tests
{

    public class BarSubstituteComponentFactory : IComponentFactory
    {
        public bool CanCreate(Type componentType)
            => componentType == typeof(Bar);

        public IComponent Create(Type componentType)
            => new BarSubstitute();
    }

    public class BarSubstitute : ComponentBase { }

    public class Substitute : ComponentBase
    {
        [Parameter(CaptureUnmatchedValues = true)]
        public IReadOnlyDictionary<string, object> Parameters { get; set; }
    }
}