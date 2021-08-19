in previous project , MpaaRating<=MpaaRating.PG, this statement is process differently on where it is used. in IF statement it is just comparision. if used in ORM same statement we put into the where LINQ method is actually an expression, and it's not executed by the processor, it get compiled into a SQL query, which is then sent to the SQL server.

## LINQ in C#.

There are two major interfaces when it comes to using LINQ, IEnumerable and IQueryable. There also are two separate sets of extension methods that work on top of them, and they work totally differently, despite looking exactly the same.

for example,

- new [] {1,2,4}.Where(x=>x==1).
  WHERE method is a version for IEnumerable because the array implements the IEnumerable interface

- session.Query<<'Movie'>>().Where(x=>x.MpaaRating<=MpaaRating.PG) OR dbContext.Movies().Where(x=>exp) , WHERE method is a version for IQueryable because session. Query implements the IQueryable interface.

look at the signatures of the two, they work on top of different interfaces, IEnumerable and IQueryable. the predicate for the IQueryable version is not a delegate, it's an Expression. This is possible because of a C#-language , a lambda expression in it can become compiled to either a delegate or an expression, depending on the circumstances.

The lambda will be compiled into a delegate.

IENUMERABLE

     Func<int,bool> func = x=>x==1

IQUERYABLE

     Expresion<Func<int,bool>> expression = x=>x==1

both works,in 2nd compiler will treat it as an expression. At this point you might ask how the compiler chooses which version of the WHERE statement to use. The array implements only the IEnumerable interface, but session.Query() implements both IEnumerable and IQueryable, so why the compiler chooses the version for IQueryable over IEnumerable? IQueryable inherits from IEnumerable,

in the case of the NHibernate session, IQueryable is the more specific interface because IQueryable inherits from IEnumerable, and thus the compiler will pick the version of the where method that works on top of IQueryables. this is true for any ORM. The LINQ providers in them work pretty much the same way.

In LINQ WHERE only small set of opertions can be translated to SQL.

      ex:
      session.Query<Movie>.Where(x=>x.IsSuitableForChildren()).ToList()

      won't work, because though IsSuitableForChildren() is expression inside LINQ won't know how to tranlate to sql.

      Remedy:
      session.Query<Movie>.ToList().Where(x=>x.IsSuitableForChildren()).ToList()

      it works , as it convers IQueryable to IEnumerable.So, here WHERE work on top of IEnumerable not IQueriable like before.x.IsSuitableForChildren() also translates into delegate not like expression before.But this is slow as it fatched all movies first.

- Expression can be converted to Delegate. reverese not possible

      Expression<Func<int,bool>> expression = x=>x==1;
      Func<int,bool> func = expression.Compile();

      this feature used when building Specification
