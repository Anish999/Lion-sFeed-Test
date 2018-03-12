using LionsFeed.Data;
using LionsFeed.Models;
using LionsFeed.ViewModel.Manage;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace LionsFeed.Controllers
{
    public class ManageController : BaseController
    {
        private LionsContext _context;

        public ManageController(LionsContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Profile()
        {
            var user = GetLoggedInUser();

            if (user == null)
            {
                throw new ApplicationException("Unable to load user.");
            }

            var model = new ProfileViewModel
            {
                Name = user.FirstName + " " + user.LastName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                ImageUrl = user.ImageUrl,
                LoggedInUserEmail = user.Email

            };
            return View(model);
        }

        public IActionResult Profile(ApplicationUser user)
        {
            var userLog = GetLoggedInUser();

            if (user == null)
            {
                throw new ApplicationException("Unable to load user.");
            }

            var model = new ProfileViewModel
            {
                Name = user.FirstName + " " + user.LastName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                ImageUrl = user.ImageUrl,
                LoggedInUserEmail = userLog.Email

            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Profile(ProfileViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = GetLoggedInUser();
            if (user == null)
            {
                throw new ApplicationException($"Unable to load user.");
            }

            if (model.PhoneNumber != user.PhoneNumber)
            {
                user.PhoneNumber = model.PhoneNumber;
                _context.Update(user);
                _context.SaveChanges();
            }

            return RedirectToAction(nameof(Profile));
        }

        public IActionResult Medium(int id)
        {

            var post = _context.Posts
                .Include(p => p.Artist)
                .Where(p => p.ID == id).SingleOrDefault();

            var user = _context.Users.Where(u => u.Id == post.Artist.Id).SingleOrDefault();

            var userLog = GetLoggedInUser();

            return View("Profile", new ProfileViewModel(user, userLog));
        }

        //GET
        public IActionResult EditProfile()
        {
            var user = GetLoggedInUser();

            if (user == null)
            {
                throw new ApplicationException("Unable to load user.");
            }

            var model = new ProfileViewModel
            {
                Name = user.FirstName + " " + user.LastName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                ImageUrl = user.ImageUrl

            };

            return View(model);
        }

        [HttpPost]
        public IActionResult EditProfile(ProfileViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = GetLoggedInUser();

            if (user == null)
            {
                throw new ApplicationException($"Unable to load user.");
            }

            if (model.PhoneNumber != user.PhoneNumber)
            {
                user.PhoneNumber = model.PhoneNumber;

                _context.Users.Update(user);
                //_context.Entry(user).State = EntityState.Modified;
                _context.SaveChanges();

            }

            var name = user.FirstName + " " + user.LastName;

            var words = model.Name.Split(' ');

            if (model.Name != name)
            {
                user.FirstName = words[0];
                user.LastName = words[1];

                _context.Update(user);
                _context.SaveChanges();
            }


            return RedirectToAction(nameof(Profile));
        }
    }
}