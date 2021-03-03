using Microsoft.AspNetCore.Mvc;
using OnlineBookstore413.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookstore413.Components
{
    
    public class NavigationMenuViewComponent : ViewComponent
    {
        private IBookstoreRepository _repository;

        public NavigationMenuViewComponent (IBookstoreRepository r)
        {
            _repository = r;
        }

        public IViewComponentResult Invoke()
        {
            //pull category from url
            ViewBag.SelectedCategory = RouteData?.Values["category"];

            //send to view the categories for the list
            return View(_repository.Books
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x));
        }
    }
}
