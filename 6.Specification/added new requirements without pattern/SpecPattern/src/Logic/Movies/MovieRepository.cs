using System;
using System.Collections.Generic;
using System.Linq;
using CSharpFunctionalExtensions;
using Logic.Utils;
using NHibernate;
using NHibernate.Linq;

namespace Logic.Movies
{
    public class MovieRepository
    {
        public Maybe<Movie> GetOne(long id)
        {
            using (ISession session = SessionFactory.OpenSession())
            {
                return session.Get<Movie>(id);
            }
        }

        public IReadOnlyList<Movie> GetList(
            bool forKidsOnly,
            double minimumRating,
            bool availableOnCD)
        {
            using (ISession session = SessionFactory.OpenSession())
            {
                return session.Query<Movie>()
                    .Where(x => //new filter requirements
                    // (x.IsSuitableForChildren() || !forKidsOnly) &&  //this won't work as of complex method call.it will work if there is .toList() before(because it convers IQuereable to IEnumerable) where, but its isefficient.
                        (x.MpaaRating <= MpaaRating.PG || !forKidsOnly) &&
                        x.Rating >= minimumRating &&
                        (x.ReleaseDate <= DateTime.Now.AddMonths(-6) || !availableOnCD))
                    .ToList();
            }
        }
    }
}
