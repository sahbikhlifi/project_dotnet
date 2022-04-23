using Domain.Entities;
using PS.Data.Infrastructure;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{
    public class EmpruntService : Service<Emprunt>, IEmpruntService
    {
        private readonly IDocumentService _documentService;
        public IUnitOfWork uiprop { get; set; }

        public EmpruntService(IUnitOfWork ui, IDocumentService documentService) : base(ui)
        {
            uiprop = ui;
            _documentService = documentService;
        }

        public int NbEmpruntsEffectuees(Client client)
        {
            return this.GetMany(emp => emp.ClientFk == client.ClientId).Count();
        }

        public int NbEmpruntsEnCours(Client client)
        {
            return this.GetMany(emp => emp.ClientFk == client.ClientId && emp.DateLimite < DateTime.Now).Count();
        }

        public int NbEmpruntsDeposes(Client client)
        {
            return this.GetMany(emp => emp.ClientFk == client.ClientId).Count();
        }

        public int NbEmprunts(Document doc)
        {
            return this.GetMany(emp => emp.DocumentFk == doc.Key).Count();
        }

        public void Emprunter(Document doc, Client client)
        {
            Emprunt emp = new Emprunt
            {
                DateEmprunt = DateTime.Now,
                DateLimite = DateTime.Now,
                Tarif = 3d,
                ClientFk = client.ClientId,
                DocumentFk = doc.Key
            };

            this.Add(emp);

            // to update document in the dbContext 
            var document = _documentService.GetById(doc.Key);
            _documentService.Update(document);
            _documentService.Commit();
            this.Commit();
        }

        public void Rendre(Document doc)
        {
            if (doc != null)
            {
                //get and remove from table Emprunt

                var emprunts = this.GetMany(x => x.DocumentFk == doc.Key);
                if (emprunts.Any())
                {
                    var emprunt = emprunts.LastOrDefault();
                    emprunt.DateRetour = DateTime.Now;


                    this.Update(emprunt);
                    this.Commit();
                }

                // update attributs of document
                // not mapped 
                // var document = _documentService.GetById(doc.Key);
                // _documentService.Update(doc);
                // _documentService.Commit();
            }
            else
            {
                throw new Exception("Document not found");
            }
        }
    }
}