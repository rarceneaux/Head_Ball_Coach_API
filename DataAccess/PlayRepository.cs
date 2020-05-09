using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using HeadBallCoach.Models;
using Dapper;

namespace HeadBallCoach.DataAccess
{
    public class PlayRepository
    {
        const string ConnectionString = "Server=localhost;Database=HeadBallCoach;Trusted_Connection=True;";

        public IEnumerable<Play> GetAllPlays()
        {
            using (var db = new SqlConnection(ConnectionString))
            {
                return db.Query<Play>("select * from plays");
            }

        }

        //public List<Play> GetPlaysByType(string typeOfPlay)
        //{
        //    var playsOfType = _plays.FindAll(p => p.TypeOfPlay.ToLower() == typeOfPlay);
        //    return playsOfType;
        //}

        public Play AddPlay(Play play)
        {
            var sql = @"insert into Plays(TypeOfPlay,NameOfPlay)
                        output inserted.*
                        values(@TypeOfPlay,@NameOfPlay)";

            using (var db = new SqlConnection(ConnectionString))
            {
                var result = db.QueryFirstOrDefault<Play>(sql, play);
                return result;
            }
        }









        //        public Play GetPlayById(int id)
        //        {
        //            return _plays.FirstOrDefault(play => play.Id == id);
        //        }

        //        public Play UpdatePlay(Play updatedPlay)
        //        {
        //            //update play
        //            //add to play list
        //            return updatedPlay;
        //        }
    }
}
