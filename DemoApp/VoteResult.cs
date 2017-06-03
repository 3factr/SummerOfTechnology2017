using System;
namespace DemoApp
{
    public class VoteResult: IComparable<VoteResult>
    {
        public string VoteOption { get; }
        public int Votes { get; }
        public decimal Percentage { get; }

        public VoteResult(string voteOption, int votes, int total)
        {
            Votes = votes;
            VoteOption = voteOption;

            Percentage = votes / (decimal )total;
        }

        public int CompareTo(VoteResult other)
        {
            return -Votes.CompareTo(other.Votes);
        }
    }
}
