using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ResidentialManager
{
    public abstract class TextDocument:Document
    {
        private string content;
        /// <summary>
        /// Holds the content of a document
        /// </summary>
        public override object Content
        {
            get { return this.content; }
            set
            {
                if (value == null) throw new ArgumentNullException("Document content is mandatory!");
                this.content = value as string;
            }
        }
        /// <summary>
        /// Constructs a document with content string
        /// </summary>
        /// <param name="name"></param>
        /// <param name="content"></param>
        public TextDocument(string id, string name, DateTime creationDate, DateTime lastChangeDate, string content)
            :base(id,name,creationDate,lastChangeDate)
        {
            this.Content = content;
        }

        /// <summary>
        /// generates a string with the text document's data
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return base.ToString()+";,"+this.Content;
        }
    }
}
