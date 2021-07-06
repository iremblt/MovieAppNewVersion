using MovieAppNewVersion.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAppNewVersion.Data
{
    public static class VoteRepository
    {
        private static readonly List<Vote> _votes = null;
        static VoteRepository()
        {
            _votes = new List<Vote>()
            {
               new Vote()
               {
                   VoteId=1,
                   VoteName='1'
               },
               new Vote()
               {
                   VoteId=2,
                   VoteName='2'
               },
               new Vote()
               {
                   VoteId=3,
                   VoteName='3'
               },
               new Vote()
               {
                   VoteId=4,
                   VoteName='4'
               },
               new Vote()
               {
                   VoteId=5,
                   VoteName='5'
               }
            };
        }
        public static List<Vote> Votes
        {
            get
            {
                return _votes;
            }
        }
    }
}
