using System;

namespace code.utility.containers
{
    public interface IFindFactoriesForAType
    {
        TypeBuilder<TypeToCreate> get_resolver_for_type<TypeToCreate>();
    }
}