using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidentialManager
{
    class LegalDocument : TextDocument
    {
        private DateTime validityDate;
        private LegalDocumentTypes legalDocumentType;
        private List<Document> relatedDocuments;

        /// <summary>
        /// Holds the date of validity of the document
        /// </summary>
        public DateTime ValidityDate
        {
            get { return this.validityDate; }
            set { this.validityDate = value; }
        }
        /// <summary>
        /// Holds the type of the legal document (law, regulation etc.)
        /// </summary>
        public LegalDocumentTypes LegalDocumentType
        {
            get { return this.legalDocumentType; }
            set { this.legalDocumentType = value; }
        }
        /// <summary>
        /// Holds a list with the related documents (if a regulation is issued based on a law per ex.)
        /// </summary>
        public IEnumerable<Document> RelatedDocuments
        {
            get { return this.relatedDocuments; }
            set { this.relatedDocuments=value.ToList(); }
        }

        /// <summary>
        /// Constructs a Legal document
        /// </summary>
        /// <param name="id">identification</param>
        /// <param name="name">name of the document</param>
        /// <param name="creationDate">date of creation</param>
        /// <param name="lastChangeDate">date of the last change</param>
        /// <param name="content">content of the file</param>
        /// <param name="validityDate">date from which the document is valid</param>
        /// <param name="type">type of the legal document</param>
        public LegalDocument(string id, string name,  DateTime creationDate, DateTime lastChangeDate,string content, DateTime validityDate,LegalDocumentTypes type)
            : base(id, name, creationDate, lastChangeDate, content)
        {
            this.ValidityDate = validityDate;
            this.LegalDocumentType = type;
        }

        /// <summary>
        /// Generates a string with the data of a legal document
        /// </summary>
        /// <returns>a string with legal document's data</returns>
        public override string ToString()
        {
            return base.ToString()+";,"+this.ValidityDate.ToString()+";,"+this.LegalDocumentType.ToString();
        }

    }
}
