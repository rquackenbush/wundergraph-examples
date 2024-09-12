using HotChocolate.ApolloFederation.Resolvers;
using HotChocolate.ApolloFederation.Types;
using ParentSubgraph.Data;

namespace ParentSubgraph.Types
{
    public class Parent
    {
        public Parent(string id, string name)
        {
            Id = id;
            Name = name;
        }

        [Key]
        [ID]
        public string Id { get; }

        public string Name { get; }

        [ReferenceResolver]
        public static Parent? Get(ParentRepository repository, string id)
        {
            return repository.GetParent(id);
        }
    }
}
