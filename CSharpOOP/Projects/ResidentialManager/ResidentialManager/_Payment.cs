using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidentialManager
{
    class Payment
    {
        #region Private and protected members

        private DateTime dtWhen;

        #endregion Private and protected members

        #region Public properties

        public DateTime When
        {
            get
            {
                return this.dtWhen;
            }
        }

        #endregion Public properties

        #region Class lifecycle

        public Payment(DateTime date)
        {
            this.dtWhen = date;
        }

        #endregion Class lifecycle
    }
    
}
