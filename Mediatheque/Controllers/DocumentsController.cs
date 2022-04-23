using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Data;
using Domain.Entities;
using Service;

namespace Mediatheque.Controllers
{
    public class DocumentsController : Controller
    {
        private readonly Context _context;
        private readonly IDocumentService _service;
        private readonly IEmpruntService _empruntService;
        private readonly IClientService _clientService;

        public DocumentsController(Context context, IDocumentService service, IEmpruntService empruntService,
            IClientService clientService)
        {
            _context = context;
            _service = service;
            _empruntService = empruntService;
            _clientService = clientService;
        }

        // GET: Documents
        public IActionResult Index()
        {
            return View(_service.GetMany());
        }

        // GET: Documents
        [HttpPost]
        public IActionResult Index(string searchString)
        {
            return View(string.IsNullOrEmpty(searchString)
                ? _service.GetMany()
                : _service.ChercherDocument(searchString));
        }

        // GET: Documents/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var document = _service.GetById(id.Value);

            if (document == null)
            {
                return NotFound();
            }

            return View(document);
        }

        // GET: Documents/Create
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create([Bind("Key,Titre,Auteur,Annee")] Document document)
        {
            if (ModelState.IsValid)
            {
                _service.Add(document);
                _service.Commit();
                return RedirectToAction(nameof(Index));
            }

            return View(document);
        }

        // GET: Documents/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var document = _service.GetById(id.Value);

            if (document == null)
            {
                return NotFound();
            }

            return View(document);
        }


        [HttpPost]
        public IActionResult Edit(int id, [Bind("Key,Titre,Auteur,Annee")] Document document)
        {
            if (id != document.Key)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _service.Update(document);
                _service.Commit();


                return RedirectToAction(nameof(Index));
            }

            return View(document);
        }

        // GET: Documents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var document = _service.GetById(id.Value);

            if (document == null)
            {
                return NotFound();
            }

            return View(document);
        }

        // POST: Documents/Delete/5
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var document = _service.GetById(id);
            _service.Delete(document);
            _service.Commit();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Emprunter(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var document = _service.GetById(id);
            if (document == null)
            {
                return NotFound();
            }

            return View(document);
        }

        [HttpPost, ActionName("Emprunter")]
        public IActionResult EnpunterMeth(int id)
        {
            var document = _service.GetById(id);
            var client = _clientService.GetById(2);
            _empruntService.Emprunter(document, client);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Rendre(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var document = _service.GetById(id);
            if (document == null)
            {
                return NotFound();
            }

            return View(document);
        }

        [HttpPost, ActionName("Rendre")]
        public IActionResult Rendre(int id)
        {
            var document = _service.GetById(id);
            _empruntService.Rendre(document);
            return RedirectToAction(nameof(Index));
        }
    }
}