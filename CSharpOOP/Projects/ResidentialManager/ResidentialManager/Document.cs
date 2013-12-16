using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidentialManager
{
    public abstract class Document : IEditable
    {
        private string id;
        private string name;
        private DateTime creationDate;
        private DateTime lastChangeDate;

        /// <summary>
        /// Holds the identification of a document
        /// </summary>
        public string ID
        {
            get {return this.id ;}
            set { this.id=value;}
        }
        /// <summary>
        /// Holds the name of the document
        /// </summary>
        public string Name
        {
            get { return this.name; }
            set
            {
                if (value == null) throw new ArgumentNullException("Document name is mandatory!");
                this.name = value;
            }
        }
        /// <summary>
        /// Holds the content of the document
        /// </summary>
        public abstract object Content
        {
            get;
            set;
        }
        /// <summary>
        /// Holds the date of the first time the document has been saved
        /// </summary>
        public DateTime CreationDate
        {
            get { return this.creationDate; }
            set { this.creationDate = value; }
        }
        /// <summary>
        /// Holds the date of the last change of the document.
        /// Validates the date of the last change to be later than the document creation.
        /// </summary>
        public DateTime LastChangeDate
        {
            get { return this.lastChangeDate; }
            set
            {
                if (this.CreationDate > value)
                    throw new ArgumentException("Document creation date can not be later than the last change date!");
                this.lastChangeDate = value;
            }
        }

        /// <summary>
        /// Constructs a document
        /// </summary>
        /// <param name="id">document's identification</param>
        /// <param name="name">document's name</param>
        /// <param name="creationDate">date of the documents's creation</param>
        /// <param name="lastChangeDate">date of the document's last change</param>
        public Document(string id, string name, DateTime creationDate, DateTime lastChangeDate)
        {
            this.ID = id;
            this.Name = name;
            this.CreationDate = creationDate;
            this.LastChangeDate = lastChangeDate;
        }

        /// <summary>
        /// Holds a string of the document's data
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
                return this.ID+";,"+this.Name +";,"+this.CreationDate.ToString()+";,"+this.LastChangeDate.ToString();
        }
 
        /// <summary>
        /// Edits the content of a document
        /// </summary>
        /// <param name="newContent">holds the new content of the document</param>
        public virtual void Edit(string newContent) { }
    }
}
