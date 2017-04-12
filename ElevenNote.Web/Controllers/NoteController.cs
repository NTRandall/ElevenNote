using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ElevenNote.Models;

namespace ElevenNote.Web.Controllers
{
    [Authorize]
    public class NoteController : Controller
    {
        
        public ActionResult Index()
        {
            var model = new NoteListItem[0];
            return View(model);
        }
    }
}