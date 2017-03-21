using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CharacterProfileApp.Data;

namespace CharacterProfileApp.Controllers
{
    public class CharacterProfileController : Controller
    {
        private CharacterProfileRepository _characterProfileRepository = new CharacterProfileRepository();

        // GET: CharacterProfile
        public ActionResult Index()
        {
            var charProfileList = _characterProfileRepository.GetCharacterProfiles();
            return View(charProfileList);
        }

        public ActionResult Detail(int? id)
        {
            if(id == null || id >= _characterProfileRepository.GetCharacterProfiles().Count)
            {
                return HttpNotFound();
            }
            var characterProfile = _characterProfileRepository.GetCharacterProfile((int)id);
            
            return View(characterProfile);

        }

        [ActionName("New")]
        [HttpPost]
        public ActionResult NewCharacterProfile(string name, string description) //values in form
        {
            ViewBag.Name = name; //assigning values to ViewBag to fill the form.
            ViewBag.Description = description;
            _characterProfileRepository.AddCharacterProfile(new Models.CharacterProfile { Name = name, Description = description });
            return View();
        }
        public ActionResult New()
        {
            return View();
        }
    }
}