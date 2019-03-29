using LaVideotheque;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;



namespace Vidly.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();

        }

        public ActionResult MoviesList()
        {
            using (DataBase4VidlyEntities context = new DataBase4VidlyEntities())
            {
                var films = context.Films.ToList();

                return View(films);

            }
        }

        public ActionResult CustomersList()
        {

            using (DataBase4VidlyEntities context = new DataBase4VidlyEntities())
            {

                var clients = context.Clients.ToList();

                return View(clients);

            };
        }


        public ActionResult DetailsForCustomers(short Id)
        {

            using (DataBase4VidlyEntities context = new DataBase4VidlyEntities())
            {

                var client = context.Clients.SingleOrDefault(c => c.Id == Id);

                return View(client);

            };

        }

        public ActionResult DetailsForMovies(short Id)
        {

            using (DataBase4VidlyEntities context = new DataBase4VidlyEntities())
            {

                var film = context.Films.SingleOrDefault(c => c.Id == Id);

                return View(film);

            };


        }

        public ActionResult DeleteMovie(short Id)
        {

            using (DataBase4VidlyEntities context = new DataBase4VidlyEntities())
            {

                var film = context.Films.SingleOrDefault(c => c.Id == Id);
                
                context.Films.Remove(film);

                context.SaveChanges();

                return View("Index");

            };


        }

        public ActionResult DeleteCustomer(short Id)
        {

            using (DataBase4VidlyEntities context = new DataBase4VidlyEntities())
            {

                var client = context.Clients.SingleOrDefault(c => c.Id == Id);

                context.Clients.Remove(client);

                context.SaveChanges();

                return View("Index");

            };


        }

        
        public ActionResult CreateMovie()
        {

            return View();

        }

        [HttpPost]
        public ActionResult Creator(string Titre, string Genre)
        {

            using (DataBase4VidlyEntities context = new DataBase4VidlyEntities())
            {

                var LastFilm = context.Films.OrderByDescending(o => o.Id).FirstOrDefault();

                var LastIdFilm = LastFilm.Id;

                var NextId = LastIdFilm + 1;

                var Fl = new Film()
                {
                    Id = NextId,
                    Titre = Titre,
                    Genre = Genre
                    
                };

                context.Films.Add(Fl);                

                context.SaveChanges();

                return View("Index");

            };

        }

    }
}