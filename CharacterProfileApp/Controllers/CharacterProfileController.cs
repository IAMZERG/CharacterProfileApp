using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CharacterProfileApp.Data;
using CharacterProfileApp.Models;
using System.Net;

namespace CharacterProfileApp.Controllers
{
    public class CharacterProfileController : Controller
    {

        // GET: CharacterProfile
        public ActionResult Index()
        {
            var charProfileList = CharacterProfileRepository.GetCharacterProfiles();
            return View(charProfileList);
        }

        public ActionResult Detail(int? id)
        {
            if(id == null || (int)id < 0)
            {
                return HttpNotFound();
            }
            var characterProfile = CharacterProfileRepository.GetCharacterProfile((int)id);
            
            return View(characterProfile);

        }

        [ActionName("New")]
        [HttpPost]
        public ActionResult NewCharacterProfile(string name, string description) //values in form
        {
            ViewBag.Name = name; //assigning values to ViewBag to re-fill the form.
            ViewBag.Description = description;
            CharacterProfileRepository.AddCharacterProfile(new CharacterProfile { Name = name, Description = description });
            return View();
        }
        public ActionResult New()
        {
            return View();
        }
    
        [HttpPost]
        public ActionResult Edit(CharacterProfile profile) 
        {
            var editStatus = CharacterProfileRepository.UpdateCharacterProfile(profile);

            ViewBag.EditStatus = editStatus;

            return View(profile);
        }
        //DONE:  create edit method for the pre-send view-- i.e. the GET side of the equation 
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CharacterProfile profile = CharacterProfileRepository.GetCharacterProfile((int)id);

            if (profile == null)
            {
                return HttpNotFound();
            }

            return View(profile);
        }
        //TODO: add delete view


        [HttpPost]
        public ActionResult Delete(CharacterProfile profile)
        {

            string message = CharacterProfileRepository.DeleteCharacterProfile(profile);

            TempData["Message"] = message;

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CharacterProfile profile = CharacterProfileRepository.GetCharacterProfile((int)id);
            if (profile == null)
            {
                return HttpNotFound();
            }

            return View(profile);
        }
        //DONE: add deletecharacterprofile method to Repository

    }
}