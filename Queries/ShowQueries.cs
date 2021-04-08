using GraphQL.Types;
using NetflixGraphQL.Database.Interfaces;
using NetflixGraphQL.Types;

namespace NetflixGraphQL.Queries
{
    public class ShowQueries : ObjectGraphType
    {
        public ShowQueries(IAllShows allShows)
        {
            Field<ListGraphType<ShowsType>>(
                "show",
                resolve: context => allShows.GetAllShows());
        }


    }
}
