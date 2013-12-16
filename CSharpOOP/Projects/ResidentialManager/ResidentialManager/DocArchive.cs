using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ResidentialManager
{
    public sealed class DocArchive
    {
        private static volatile DocArchive myDocArchive;
        private static object syncRoot = new Object();

        private List<Document> documents;

        /// <summary>
        /// Holds the documents of the commonhold
        /// </summary>
        public IEnumerable<Document> Documents
        {
            get { return this.documents.AsEnumerable(); }
            set
            {
                if (value.Count() != value.Select(doc => doc.ID).Distinct().Count())
                {
                    throw new ArgumentException("There is another document with this ID!");
                }
                this.documents = value.ToList();
            }
        }
        /// <summary>
        /// Creates an instance of the documents archive if none already exist
        /// </summary>
        public static DocArchive MyDocArchive
        {
            get
            {
                if (myDocArchive == null)
                {
                    lock (syncRoot)
                    {
                        if (myDocArchive == null)
                        {
                            myDocArchive = new DocArchive();
                        }
                    }
                }
                return myDocArchive;
            }
        }

        private DocArchive()
        {
            try
            {
                Documents = GetDocuments();
            }
            catch (MissingDocumentTypeException ex)
            {
                MessageBox.Show(ex.Message);
                Environment.Exit(-1);
            }

        }


        /// <summary>
        /// Load the commonghold's documents from the storage file
        /// </summary>
        /// <returns>IEnumerable with all the commonhold's documents</returns>
        public static IEnumerable<Document> GetDocuments()
        {
            return GetDocuments(@"..\..\data\documents.txt");
        }

        private static List<Document> GetDocuments(string file)
        {
            List<Document> docs = new List<Document>();
            string[] doc;
            using (StreamReader fileContent = new StreamReader(file))
            {
                doc = fileContent.ReadToEnd().Split(new string[] { ";;;\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            }
            string[] docProp;
            foreach (var row in doc)
            {
                docProp = row.Split(new string[] { ";," }, StringSplitOptions.RemoveEmptyEntries);
                switch (docProp[0])
                {
                    case "Message":
                        IEnumerable<Inhabitant> receivers = InhabitantList.DeserializeInhabitants(docProp[8]);
                        IEnumerable<Inhabitant> senders = InhabitantList.DeserializeInhabitants(docProp[7]);
                        Message myMess = new Message(docProp[1], docProp[2], DateTime.Parse(docProp[3]), DateTime.Parse(docProp[4]), docProp[5], docProp[6], senders, receivers);
                        docs.Add(myMess);
                        break;
                    case "LegalDocument":
                        LegalDocument myLegalDoc = new LegalDocument(docProp[1], docProp[2], DateTime.Parse(docProp[3]), DateTime.Parse(docProp[4]), docProp[5], DateTime.Parse(docProp[6]), (LegalDocumentTypes)Enum.Parse(typeof(LegalDocumentTypes), docProp[7]));
                        docs.Add(myLegalDoc);
                        break;
                    case "Contract":
                        IEnumerable<Inhabitant> contragentFirst = InhabitantList.DeserializeInhabitants(docProp[6]);
                        IEnumerable<Inhabitant> contragentSecond = InhabitantList.DeserializeInhabitants(docProp[7]);
                        Contract myContract = new Contract(docProp[1], docProp[2], DateTime.Parse(docProp[3]), DateTime.Parse(docProp[4]), docProp[5], contragentFirst, contragentSecond, DateTime.Parse(docProp[8]), DateTime.Parse(docProp[9]));
                        docs.Add(myContract);
                        break;
                    case "Protocol":
                        IEnumerable<Inhabitant> mySigners = InhabitantList.DeserializeInhabitants(docProp[7]);
                        IEnumerable<Inhabitant> protWriters = InhabitantList.DeserializeInhabitants(docProp[6]);

                        Protocol myProtocol = new Protocol(docProp[1], docProp[2], DateTime.Parse(docProp[3]), DateTime.Parse(docProp[4]), docProp[5], protWriters.ToList()[0], mySigners);
                        docs.Add(myProtocol);
                        break;
                    case "MessageGeneralMeeting":
                        IEnumerable<Inhabitant> send = InhabitantList.DeserializeInhabitants(docProp[7]);
                        IEnumerable<Inhabitant> recv = InhabitantList.DeserializeInhabitants(docProp[8]);
                        IEnumerable<Inhabitant> conv = InhabitantList.DeserializeInhabitants(docProp[12]);
                        MessageGeneralMeeting myMessGM = new MessageGeneralMeeting(docProp[1], docProp[2], DateTime.Parse(docProp[3]), DateTime.Parse(docProp[4]), docProp[5], docProp[6], send, recv, docProp[9], DateTime.Parse(docProp[10]), DateTime.Parse(docProp[11]), conv);
                        docs.Add(myMessGM);
                        break;
                    default:
                        throw new MissingDocumentTypeException(String.Format("{0} type of document is not recognized", docProp[0]));
                }
            }
            return docs;
        }

        /// <summary>
        /// Saves the commonhold's documents in a text file
        /// </summary>
        /// <param name="file">full path of the receiving text file</param>
        public void SaveDocuments(string file = @"..\..\data\documents.txt")
        {
            using (StreamWriter sw = new StreamWriter(file, false, Encoding.GetEncoding("UTF-8")))
            {
                StringBuilder sb = new StringBuilder();
                this.Documents.ToList().ForEach(doc => sw.WriteLine(doc.GetType().Name + ";," + doc.ToString() + ";;;"));
            }
        }
        /// <summary>
        /// Adds a document to the document archive
        /// </summary>
        /// <param name="doc">the document to be added to the document archive</param>
        public void AddDocument(Document doc)
        {
            if (Documents.Select(d => d.ID).Contains(doc.ID))
            {
                MessageBox.Show("The document archive already has a document with this ID!");
            }
            else
            {
                documents.Add(doc);
            }
        }
    }
}
