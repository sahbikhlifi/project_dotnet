using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServicePattern;
using Domain.Entities;
using PS.Data.Infrastructure;

namespace Service
{
    public class DocumentService : Service<Document>, IDocumentService
    {
        public DocumentService(IUnitOfWork ui) : base(ui)
        {
        }


        public Boolean Empruntable(Document d)
        {
            var doc = this.GetById(d.Key);
            if (doc != null)
            {
                return doc.Emprunte;
            }

            throw new Exception("erreur");
        }

        public IList<Document> GetEmpruntables(Mediatheque mediatheque)
        {
            var docMed =  mediatheque.Documents.ToList();
            return docMed.Where(item => item.Empruntable).ToList();
        }

        public List<Document> ChercherDocument(string titre)
        {
            return this.GetMany((doc => doc.Titre.Contains(titre))).ToList();
        }
    }
}