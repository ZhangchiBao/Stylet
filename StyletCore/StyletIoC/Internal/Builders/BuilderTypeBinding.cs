﻿using System;
using System.Collections.Generic;
using StyletCoreIoC.Creation;

namespace StyletCoreIoC.Internal.Builders
{
    internal class BuilderTypeBinding : BuilderBindingBase
    {
        private readonly Type implementationType;

        public BuilderTypeBinding(List<BuilderTypeKey> serviceTypes, Type implementationType)
            : base(serviceTypes)
        {
            this.EnsureTypeAgainstServiceTypes(implementationType);
            this.implementationType = implementationType;
        }

        public override void Build(Container container)
        {
            this.BindImplementationToServices(container, this.implementationType);
        }
    }
}
