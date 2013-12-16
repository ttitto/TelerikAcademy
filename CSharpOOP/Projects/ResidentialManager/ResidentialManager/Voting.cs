using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidentialManager
{
    class Voting
    {
        private string subject;
        private GeneralMeeting meeting;
        private List<Inhabitant> positiveVoters;
        private List<Inhabitant> negativeVoters;
        private List<Inhabitant> abstainers;
        private VotingResult result;

        public VotingResult Result
        {
            get { return this.result; }
            set { this.result = value; }
        }


        public List<Inhabitant> NegativeVoters
        {
            get { return this.negativeVoters; }
            set { this.negativeVoters = value; }
        }

        public List<Inhabitant> Abstainers
        {
            get { return this.abstainers; }
            set { this.abstainers = value; }
        }

        public List<Inhabitant> PositiveVoters
        {
            get { return this.positiveVoters; }
            set { this.positiveVoters = value; }
        }

        public GeneralMeeting Meeting
        {
            get { return this.meeting; }
            set { this.meeting = value; }
        }

        public string Subject
        {
            get { return this.subject; }
            set { this.subject = value; }
        }

        public Voting(string subject, GeneralMeeting meeting)
        {
            this.subject = subject;
            this.meeting = meeting;
        }

        public void EnterResult(List<Inhabitant> positiveVoters, List<Inhabitant> negativeVoters, List<Inhabitant> abstainers)
        {
            this.positiveVoters = positiveVoters;
            this.negativeVoters = negativeVoters;
            this.abstainers = abstainers;
            
            int result = positiveVoters.Count - negativeVoters.Count;

            if (result > 0)
                this.result = VotingResult.Passed;
            else if (result < 0)
                this.result = VotingResult.Failed;
            else
                this.result = VotingResult.Par;
        }
    }
}
