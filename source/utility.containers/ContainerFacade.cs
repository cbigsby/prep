using System;

namespace code.utility.containers
{
    public class ContainerFacade : IFetchDependencies
    {
        private IFindFactoriesForAType type_factory_registry;

        public ContainerFacade(IFindFactoriesForAType type_factory_registry)
        {
            this.type_factory_registry = type_factory_registry;
        }

        public ItemToFetch an<ItemToFetch>()
        {
            type_factory_registry.get_resolver_for_type<ItemToFetch>();

            return default(ItemToFetch);
        }
    }
}