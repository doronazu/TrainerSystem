using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.Office.Interop.Word;
using TrainerSystem.Models;
using TrainerSystem.Models.Application;
using TrainerSystem.Models.Application.UploadSystem;

namespace TrainerSystem.Controllers
{
    public class UploadsFilesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UploadsFilesController()
        {
            _context = new ApplicationDbContext();
        }

        private async Task<ApplicationUser> GetUser()
        {
            var uid = User.Identity.GetUserId();
            return await _context.Users.SingleOrDefaultAsync(u => u.Id == uid);
        }
        

        // GET: UploadsFiles
        public async Task<ActionResult> Index()
        {
            var user = await GetUser();
            if (user == null) return HttpNotFound();
            var trainer = await _context.Trainers.Include(t=>t.Files).SingleOrDefaultAsync(t=>t.Id == user.TrainerId);
            if (trainer == null) return HttpNotFound();
            return View(trainer.Files);
        }

        // Post: UploadsFiles
        [HttpPost]
        public async Task<ActionResult> Index(FileUpload obj)
        {
            var path = String.Empty;
            var file = obj.File;

            if (file != null && file.ContentLength > 0)
            {
                switch (file.ContentType)
                {
                    case "image/jpeg":
                        path = "/Uploads/Images";
                        break;
                    case "text/plain":
                        path = "/Uploads/Text";
                        break;
                    case "application/msword":
                        path = "/Uploads/Word";
                        break;
                }
                if (path != String.Empty)
                {
                    var user = await GetUser();
                    if (user == null) return HttpNotFound();

                    var fileName = Path.GetFileNameWithoutExtension(file.FileName) + "--trainerApp--" + Guid.NewGuid() +
                                   Path.GetExtension(file.FileName);
                    var newFile = new AppFile()
                    {
                        DateTimeAdded = DateTime.Now,
                        FilePath = path+ "/" + fileName,
                        Type = file.ContentType,
                        TrainerId = user.TrainerId
                    };
                    _context.Files.Add(newFile);
                    await _context.SaveChangesAsync();

                    file.SaveAs(Path.Combine(Server.MapPath(path), fileName));
                }
            }
            return RedirectToAction("Index");
        }


        // Post: UploadsFiles
        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            var user = await GetUser();
            if (user == null) return HttpNotFound();
            var fileInDb = await _context.Files.SingleOrDefaultAsync(t => t.Id == id);
            if (fileInDb == null || fileInDb.TrainerId != user.TrainerId) return HttpNotFound();

            _context.Files.Remove(fileInDb);
            await _context.SaveChangesAsync();

            if(System.IO.File.Exists(Server.MapPath(fileInDb.FilePath)))
                System.IO.File.Delete(Server.MapPath(fileInDb.FilePath));

            return RedirectToAction("Index");
        }
    }
}