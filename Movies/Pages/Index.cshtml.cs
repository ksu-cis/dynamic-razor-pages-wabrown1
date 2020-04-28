using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Movies.Pages
{
    public class IndexModel : PageModel
    {
        /// <summary>
        /// The movies to display on the index page 
        /// </summary>
        public IEnumerable<Movie> Movies { get; protected set; }

        /// <summary>
        /// Gets and sets the search terms
        /// </summary>
        [BindProperty]
        public string SearchTerms { get; set; } = "";

        /// <summary>
        /// Gets and sets the MPAA rating filters
        /// </summary>
        [BindProperty]
        public string[] MPAARatings { get; set; } = { };

        /// <summary>
        /// The filtered genres
        /// </summary>
        [BindProperty]
        public string[] Genres { get; set; } = { };

        /// <summary>
        /// Gets and sets the IMDB minimium rating
        /// </summary>
        public double? IMDBMin { get; set; }

        /// <summary>
        /// Gets and sets the IMDB maximum rating
        /// </summary>
        public double? IMDBMax { get; set; }

        /// <summary>
        /// Does the response initialization for incoming GET requests
        /// </summary>
        public void OnGet(/*string SearchTerms, double? IMDBMin, double? IMDBMax*//*float? IMDBMin, float? IMDBMax*/)
        {
            /*this.SearchTerms = SearchTerms;
            this.IMDBMin = IMDBMin;
            this.IMDBMax = IMDBMax;*/

            /*SearchTerms = Request.Query["SearchTerms"];
            var value = double.Parse(Request.Query["IMDBMin"]);
            if (double.IsNaN(value)) IMDBMin = null;
            else IMDBMin = value;*/
            Movies = MovieDatabase.All;


            // Nullable conversion workaround
            /*this.IMDBMin = IMDBMin;
            this.IMDBMax = IMDBMax;
            Movies = MovieDatabase.Search(SearchTerms);
            Movies = MovieDatabase.FilterByMPAARating(Movies, MPAARatings);
            Movies = MovieDatabase.FilterByGenre(Movies, Genres);
            Movies = MovieDatabase.FilterByIMDBRating(Movies, IMDBMin, IMDBMax);*/
        }

        public void OnPost()
        {
            Movies = MovieDatabase.Search(SearchTerms);
            Movies = MovieDatabase.FilterByMPAARating(Movies, MPAARatings);
            Movies = MovieDatabase.FilterByGenre(Movies, Genres);
            Movies = MovieDatabase.FilterByIMDBRating(Movies, IMDBMin, IMDBMax);
        }
    }
}
