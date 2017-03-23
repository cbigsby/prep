using System;

namespace code.utility.containers
{
    public interface IFindFactoriesForAType
    {
        IBuildA<TypeToCreate> get_resolver_for_type<TypeToCreate>();
    }
}