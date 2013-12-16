using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidentialManager
{
  public  class Protocol :TextDocument
    {
       private Inhabitant protocolWriter;
        private List<Inhabitant> signers;
      /// <summary>
      /// Holds the inhabitant that writes the protocol
      /// </summary>
       public Inhabitant ProtocolWriter
        {
            get { return this.protocolWriter; }
            set { this.protocolWriter = value; }
        }
      /// <summary>
      /// Holds a list of inhabitants that sign the protocol
      /// </summary>
        public IEnumerable<Inhabitant> Signers
        {
            get { return this.signers; }
            set { this.signers = value.ToList(); }
        }
      /// <summary>
      /// Constructs a protocol
      /// </summary>
      /// <param name="id"></param>
      /// <param name="name"></param>
      /// <param name="creationDate"></param>
      /// <param name="lastChangeDate"></param>
      /// <param name="content"></param>
      /// <param name="protocolWriter"></param>
      /// <param name="signers"></param>
        public Protocol(string id,string name,  DateTime creationDate, DateTime lastChangeDate, string content, Inhabitant protocolWriter, IEnumerable<Inhabitant> signers)
            : base(id, name, creationDate, lastChangeDate, content)
        {
           this.ProtocolWriter = protocolWriter;
            this.Signers = signers;
        }

      /// <summary>
      /// Generates a string with the protocol's data
      /// </summary>
      /// <returns></returns>
        public override string ToString()
        {
            string protWriter=this.ProtocolWriter.FirstName+this.ProtocolWriter.LastName+this.ProtocolWriter.TelephoneNumber;

            return base.ToString() + ";," + protWriter + ";," + InhabitantList.SerializeInhabitants(this.Signers);
        }

    }
}
