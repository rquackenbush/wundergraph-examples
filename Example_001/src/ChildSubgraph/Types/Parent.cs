using ChildSubgraph.Data;
using HotChocolate.ApolloFederation.Resolvers;
using HotChocolate.ApolloFederation.Types;

namespace ChildSubgraph.Types;

public class Parent
{
    public Parent(string id)
    {
        Id = id;
    }

    [ID]
    [Key]
    public string Id { get; }

    public IEnumerable<Child> Children([Parent] Parent parent, ChildRepository repository)
    {
        return repository.GetChildren(parent.Id);
    }

    [ReferenceResolver]
    public static Parent Get(string id)
    {
        return new Parent(id);
    }
}
