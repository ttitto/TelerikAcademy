using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;
using System.Data.SqlTypes;

namespace SQLAggregateFunctions
{
    [System.Serializable]
    [Microsoft.SqlServer.Server.SqlUserDefinedAggregate(
        Format.Native,
        IsInvariantToDuplicates = false,
        IsInvariantToNulls = false,
        IsInvariantToOrder = true,
        IsNullIfEmpty = false,
        MaxByteSize = -1,
        Name = "StrConcat")]
    public struct StrConcat
    {

        private SqlString result;
        private SqlString delimiter;
        private SqlBoolean hasValue;
        public void Init()
        {
            this.result = new SqlString();
            this.delimiter = ", ";
            this.hasValue = false;
        }

        public void Accumulate(SqlString value, SqlString delimiter)
        {
            //if this is the first value => get it
            if (!this.hasValue)
            {
                this.result = value;
            }
            //if the result is null => leave it as is
            else if (this.result.IsNull)
            {
            }
            //if the new value is null => do not add it to the resulting string
            else if (value.IsNull)
            {
            }
            //in all other cases append the delimiter and value to the result
            else
            {
                this.result += delimiter + value;
            }
            //mark that the result already contains some value
            this.hasValue = true;
        }

        public void Merge(StrConcat group)
        {
            //append to the result only if the group has value
            if (group.hasValue)
            {
                this.result += group.delimiter + group.result;
            }
        }

        public SqlString Terminate()
        {
            return this.result;
        }
    }
}
