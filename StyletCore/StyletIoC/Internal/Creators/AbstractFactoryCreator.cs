﻿using StyletCoreIoC.Creation;
using System;
using System.Linq.Expressions;

namespace StyletCoreIoC.Internal.Creators
{
    using System.Diagnostics;

    /// <summary>
    /// Knows how to create an instance of an abstract factory (generated by Container.GetFactoryForType)
    /// </summary>
    internal class AbstractFactoryCreator : ICreator
    {
        private readonly Type abstractFactoryType;
        public RuntimeTypeHandle TypeHandle
        {
            get { return this.abstractFactoryType.TypeHandle; }
        }

        public AbstractFactoryCreator(Type abstractFactoryType)
        {
            this.abstractFactoryType = abstractFactoryType;
        }

        public Expression GetInstanceExpression(ParameterExpression registrationContext)
        {
            var ctor = this.abstractFactoryType.GetConstructor(new[] { typeof(IRegistrationContext) });
            Debug.Assert(ctor != null);
            var construction = Expression.New(ctor, registrationContext);
            return construction;
        }
    }
}
