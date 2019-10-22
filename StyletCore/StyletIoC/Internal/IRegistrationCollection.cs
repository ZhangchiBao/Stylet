using StyletCoreIoC.Creation;
using System.Collections.Generic;

namespace StyletCoreIoC.Internal
{
    internal interface IRegistrationCollection : IReadOnlyRegistrationCollection
    {
        IRegistrationCollection AddRegistration(IRegistration registration);
    }

    internal interface IReadOnlyRegistrationCollection
    {
        IRegistration GetSingle();
        List<IRegistration> GetAll();
    }
}
