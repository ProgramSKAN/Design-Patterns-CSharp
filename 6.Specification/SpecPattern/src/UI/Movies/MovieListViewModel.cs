using System;
using System.Collections.Generic;
using System.Windows;
using CSharpFunctionalExtensions;
using Logic.Movies;
using UI.Common;

namespace UI.Movies
{
    public class MovieListViewModel : ViewModel
    {
        private readonly MovieRepository _repository;

        public Command SearchCommand { get; }
        public Command<long> BuyAdultTicketCommand { get; }
        public Command<long> BuyChildTicketCommand { get; }
        public Command<long> BuyCDCommand { get; }
        public IReadOnlyList<Movie> Movies { get; private set; }

        public bool ForKidsOnly { get; set; }//new requirement, kids only checkboc for ticket buy app
        public double MinimumRating { get; set; }
        public bool OnCD { get; set; }//new requirement, moviews released morethan 6moths ago, ie, cd version movies 

        public MovieListViewModel()
        {
            _repository = new MovieRepository();

            SearchCommand = new Command(Search);
            BuyAdultTicketCommand = new Command<long>(BuyAdultTicket);
            BuyChildTicketCommand = new Command<long>(BuyChildTicket);
            BuyCDCommand = new Command<long>(BuyCD);
        }

        private void BuyCD(long movieId)
        {
            Maybe<Movie> movieOrNothing = _repository.GetOne(movieId);
            if (movieOrNothing.HasNoValue)
                return;

            Movie movie = movieOrNothing.Value;
            if (movie.ReleaseDate >= DateTime.Now.AddMonths(-6))
            {
                MessageBox.Show("The movie doesn't have a CD version", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            MessageBox.Show("You've bought a ticket", "Success",
                MessageBoxButton.OK, MessageBoxImage.Information);
        }

//new requirement , by child ticket
        private void BuyChildTicket(long movieId)//on buy ticket button
        {
            Maybe<Movie> movieOrNothing = _repository.GetOne(movieId);
            if (movieOrNothing.HasNoValue)//check if the movie exists 
                return;

            Movie movie = movieOrNothing.Value;
            if (!movie.IsSuitableForChildren())
            {
                MessageBox.Show("The movie is not suitable for children", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            
            MessageBox.Show("You've bought a ticket", "Success",
                MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void BuyAdultTicket(long movieId)
        {
            MessageBox.Show("You've bought a ticket", "Success",
                MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Search()//on search buttton
        {
            Movies = _repository.GetList(ForKidsOnly, MinimumRating, OnCD);//pass new filter requirements
            Notify(nameof(Movies));
        }
    }
}
