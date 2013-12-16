using System;

namespace ResidentialManager
{
    class Cash
    {
        #region Private and protected members

        private double available;

        #endregion Private and protected members

        #region Public properties

        public double Money
        {
            get
            {
                return this.available;
            }
        }

        #endregion Public properties

        #region Class lifecycle

        public Cash(double cash)
        {
            this.available = cash;
        }

        #endregion Class lifecycle

        #region Public methods

        public void Add(double mn)
        {
            this.available += mn;
        }

        public double Rem(double mn)
        {
            if (mn > this.available)
            {
                throw new ArgumentException("Trying to get more money than available.");
            }

            this.available -= mn;
            return this.available;
        }

        #endregion Public methods
    }
}

//static void Main( string[ ] args )
//{
//    Cash cash = new Cash( 10000.00 );
            
//    cash.Add( AddCash( ) );

 //   Console.WriteLine( cash.Money );
//}

//static double AddCash( )
//{
//    Income inc = new Income( );
//
//    inc.Over18.Add( new Living( "Pesho", "Goshev", "Toshev", 38 ) );
//    inc.Over18.Add( new Living( "Ivanka", "Georgieva", "Asenova", 34 ) );
//    inc.Under18.Add( new Living( "Myrzelanka", "Georgieva", "Tosheva", 10 ) );
//    inc.Under18.Add( new Living( "Rabotlivko", "Ivanov", "Toshev", 6 ) );
//    inc.Pets.Add( new Pet( "Gergana", 3, false ) );
//    inc.Pets.Add( new Pet( "Teo", 5, false ) );

//    return inc.Calculate( );
//}
