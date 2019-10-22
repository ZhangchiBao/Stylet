using StyletCoreIoC.Creation;
using System;
using System.Collections.Generic;

namespace StyletCoreIoC.Internal.RegistrationCollections
{
    internal class EmptyRegistrationCollection : IReadOnlyRegistrationCollection
    {
        private readonly Type type;

        public EmptyRegistrationCollection(Type type)
        {
            this.type = type;
        }

        public IRegistration GetSingle()
        {
            throw new StyletIoCRegistrationException(String.Format("No registrations found for service {0}.", this.type.GetDescription()));
        }

        public List<IRegistration> GetAll()
        {
            return new List<IRegistration>();
        }
    }
}
