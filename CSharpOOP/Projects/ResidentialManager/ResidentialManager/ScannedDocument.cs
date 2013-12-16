using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Controls;

namespace ResidentialManager
{
    class ScannedDocument : Document
    {
        private Image scannedImage;

        //public Image ScannedImage
        //{
        //    get { return this.scannedImage; }
        //    set { this.scannedImage = value; }
        //}
        public override object Content
        {
            get { return this.scannedImage; }
            set { this.scannedImage=(Image)value; }
        }
        public ScannedDocument(string id, string name,  object content, DateTime creationDate, DateTime lastChangeDate)
            : base(id,name,creationDate,lastChangeDate)
        {
           // this.Content = Image.FromFile("");
        }


    }
}
