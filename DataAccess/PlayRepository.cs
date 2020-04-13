using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HeadBallCoach.Models;

namespace HeadBallCoach.DataAccess
{
    public class PlayRepository
    {
        static List<Play> _plays = new List<Play>
        {
            new Play
            {
                TypeOfPlay = "Run",
                Id = 1,
                NameOfPlay = "QB Sneak"
            },
             new Play
            {
                TypeOfPlay = "Run",
                Id = 2,
                NameOfPlay = "Buck Sweep"
            },
                new Play
            {
                TypeOfPlay = "Pass",
                Id = 3,
                NameOfPlay = "Post Corner Z"
            },
                new Play
            {
                TypeOfPlay = "Pass",
                Id = 4,
                NameOfPlay = "Bootleg Long"
            }
        };
        public List<Play> GetAllPlays()
        {
            return _plays;
        }

        public void AddPlay(Play play)
        {
            play.Id = _plays.Max(x => x.Id) + 1;
            _plays.Add(play);
        }

        public Play GetPlayById(int id)
        {
            return _plays.FirstOrDefault(play => play.Id == id);
        }
    }
}
