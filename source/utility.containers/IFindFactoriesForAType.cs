using System;

namespace code.utility.containers
{
    public delegate TypeToCreate TypeBuilder<out TypeToCreate>();
    public interface IFindFactoriesForAType
    {
        TypeBuilder<TypeToCreate> get_resolver_for_type<TypeToCreate>();
    }
}