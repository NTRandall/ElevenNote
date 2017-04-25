using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ElevenNote.Models;
using ElevenNote.Services;
using Microsoft.AspNet.Identity;

namespace ElevenNote.Api.Controllers
{
    [Authorize]
    public class NotesController : ApiController
    {

        public IHttpActionResult GetAll()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var noteService = new NoteService(userId);
            var note = noteService.GetNotes();
            if (note == null) return NotFound();

            return Ok(note);
        }



        public IHttpActionResult Get(int id)
        {
            var noteService = new NoteService(Guid.Parse(User.Identity.GetUserId()));
            var note = noteService.GetNoteById(id);
            if (note == null) return NotFound();

            return Ok(note);
        }

        public IHttpActionResult Post(NoteCreate model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var noteService = new NoteService(Guid.Parse(User.Identity.GetUserId()));
            return Ok(noteService.CreateNote(model));
        }

        public IHttpActionResult Put(NoteEdit model)
        {
            // Make sure the note exists 
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var noteService = new NoteService(Guid.Parse(User.Identity.GetUserId()));
            var temp = noteService.GetNoteById(model.NoteId);
            if (temp == null) return NotFound();

            // Attempt to update
            return Ok(noteService.UpdateNote(model));
        }

        public IHttpActionResult Delete(int id)
        {
            // Make sure the note exists
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var noteService = new NoteService(Guid.Parse(User.Identity.GetUserId()));
            var temp = noteService.GetNoteById(id);
            if (temp == null) return NotFound();

            //Attempt to Delete
            return Ok(noteService.DeleteNote(id));
        }
    }
}
