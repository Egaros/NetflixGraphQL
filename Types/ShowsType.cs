using GraphQL.Types;
using NetflixGraphQL.Models;

namespace NetflixGraphQL.Types
{
    public class ShowsType : ObjectGraphType<MovieModel>
    {
        public ShowsType()
        {
            Field(x => x.Thumbnail).Description("Movie poster");
            Field(x => x.Title).Description("Movie title");
            Field(x => x.Genre).Description("Movie genre");
            Field(x => x.IsFeatured).Description("Is movie featured?");
            Field(x => x.Synopsis).Description("Movie synopsis");
            Field(x => x.IsPopular).Description("Is movie popular?");
            Field(x => x.IsAction).Description("Is movie action?");
            Field(x => x.IsComedy).Description("Is movie comedy?");
            Field(x => x.Casts).Description("Movie casts");
            Field(x => x.Year).Description("Year that movies has been released");
            Field(x => x.Rating).Description("Movie rating");
            Field(x => x.InfoThumbnail).Description("Thumbnail for each episode");
            Field(x => x.IsComingSoon).Description("Is movie coming soon?");
        }
    }
}
