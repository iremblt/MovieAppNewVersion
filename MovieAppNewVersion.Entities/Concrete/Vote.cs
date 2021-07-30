namespace MovieAppNewVersion.Entities.Concrete
{
    public class Vote
    {
        public int VoteId { get; set; }
        public int Voting { get; set; }
        public Movie Movie { get; set; }
    }
}
