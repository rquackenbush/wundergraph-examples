﻿using ParentSubgraph.Data;
using ParentSubgraph.Types;

namespace ApolloFederationRepro.Types
{
    public class Query
    {
        public IEnumerable<Parent> AllParents(ParentRepository repository)
        {
            return repository.GetAllParents();
        }
    }
}
