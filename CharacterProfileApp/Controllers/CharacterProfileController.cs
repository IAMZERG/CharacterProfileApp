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
        // GET: CharacterProfile
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Detail()
        {
            var charProfile = new CharacterProfileRepository();
            var characterProfile = charProfile.GetCharacterProfile();
            
            return View(characterProfile);

        }
    }
}