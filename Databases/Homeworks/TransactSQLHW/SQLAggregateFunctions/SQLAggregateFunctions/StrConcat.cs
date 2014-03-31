using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;
using System.Data.SqlTypes;
using System.IO;

namespace SQLAggregateFunctions
{
    [System.Serializable]
    [Microsoft.SqlServer.Server.SqlUserDefinedAggregate(
        Format.UserDefined,
        IsInvariantToDuplicates = false,
        IsInvariantToNulls = false,
        IsInvariantToOrder = true,
        IsNullIfEmpty = false,
        MaxByteSize = -1,
        Name = "StrConcat")]
    public struct StrConcat:IBinarySerialize
    {

        private StringBuilder result;
        private string delimiter;
        private SqlBoolean hasValue;
        public void Init()
        {
            this.result = new StringBuilder();
            this.delimiter = ", ";
            this.hasValue = false;
        }

        public void Accumulate(string value, string delimiter)
        {
            //if this is the first value => get it
            if (!this.hasValue)
            {
                this.result.Append( value);
            }
            //if the result is null => leave it as is
            else if (string.IsNullOrEmpty(this.result.ToString()))
            {
            }
            //if the new value is null => do not add it to the resulting string
            else if (string.IsNullOrEmpty(value))
            {
            }
            //in all other cases append the delimiter and value to the result
            else
            {
                this.result.Append(delimiter);
                this.result.Append(value);
            }
            //mark that the result already contains some value
            this.hasValue = true;
        }

        public void Merge(StrConcat group)
        {
            //append to the result only if the group has value
            if (group.hasValue)
            {
                this.result.Append(group.delimiter);
                this.result.Append(group.result);
            }
        }

        public string Terminate()
        {
            return this.result.ToString();
        }

        public void Read(BinaryReader r)
        {
           this.delimiter= r.ReadString();
           this.result =new StringBuilder( r.ReadString());
        }

        public void Write(BinaryWriter w)
        {
            w.Write(this.delimiter);
            w.Write(this.result.ToString());
        }
    }
}
