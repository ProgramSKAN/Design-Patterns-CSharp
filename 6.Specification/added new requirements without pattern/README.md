- new requirements are added like kidsonly,child/adult tickets,buy tickets,onCD movies 6months ago

- these uses cases fall intto 2 categories
  1.Data retrival from DB
  2.User Input Validation

  - usecases of the above 2 is different but they have somthing in common.

    1. kids movie
    2. movies has a cd version

    - this domain knowledge scatters across code base. eg:line 30 in moviesRepository.cs checking same this as line60 in MoviesListViewModel.cs. This duplicated domain knowledge and violated DRY principle. This could be solved by keeeping IsSuitableForChildren() method in movied entity and use it in both places but it won't work in LINQ ORM Lamda expression .

    * to solve it either duplicate domain knowledge or damage performance of SQL Linq.This is where specification Patterns helps.it gives the best of both.(no duplication,efficient sql)
