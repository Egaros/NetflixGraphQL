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
                "allShows",
                resolve: context => allShows.GetAllShows());

            Field<ShowsType>(
                "featuredShow",
                resolve: context => allShows.GetFeaturedShow());

            Field<ListGraphType<ShowsType>>(
                "actionShows",
                resolve: context => allShows.GetActionShows());

            Field<ListGraphType<ShowsType>>(
                "comedyShows",
                resolve: context => allShows.GetComedyShows());

            Field<ListGraphType<ShowsType>>(
                "comingSoonShows",
                resolve: context => allShows.GetComingSoonShows());

            Field<ListGraphType<ShowsType>>(
                "popularShows",
                resolve: context => allShows.GetPopularShows());

            Field<ListGraphType<ShowsType>>(
                "searchForShow",
                arguments: new QueryArguments(new QueryArgument<StringGraphType> { Name = "title" }),
                resolve: context =>
                {
                    var title = context.GetArgument<string>("title");
                    return allShows.SearchForShows(title);
                });
        }
    }
}