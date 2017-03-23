using System;
using developwithpassion.specifications.assertions.core;
using developwithpassion.specifications.assertions.interactions;
using Machine.Specifications;
using spec = developwithpassion.specifications.use_engine<Machine.Fakes.Adapters.Rhinomocks.RhinoFakeEngine>;

namespace code.utility.containers
{
  [Subject(typeof(ContainerFacade))]
  public class ContainerFacadeSpecs
  {
    public abstract class concern : spec.observe<IFetchDependencies, ContainerFacade>
    {
    }

    public class when_fetching_a_dependency : concern
    {
        public class SomeItem
        {
            
        }

      private Establish c = () =>
      {
        registry = depends.on<IFindFactoriesForAType>();
        registry.setup(x => x.get_resolver_for_type<SomeItem>()).Return(the_builder);
        the_builder = fake.an<TypeBuilder<SomeItem>>();
      };

      Because b = () => sut.an<SomeItem>();

      It uses_the_type_builder_to_build_the_type = () =>
        the_builder.should().received(x => x.Invoke());

      static IFindFactoriesForAType registry;
      static TypeBuilder<SomeItem> the_builder;
    }
  }
}