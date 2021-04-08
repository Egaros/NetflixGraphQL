using GraphQL;
using NetflixGraphQL.Queries;

namespace NetflixGraphQL.Schema
{
    public class ShowsSchema : GraphQL.Types.Schema
    {
        public ShowsSchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<ShowQueries>();
        }
    }
}
