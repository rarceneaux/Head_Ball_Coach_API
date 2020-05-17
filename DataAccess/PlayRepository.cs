using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using HeadBallCoach.Models;
using Dapper;
using System.Data.Common;

namespace HeadBallCoach.DataAccess
{
    public class PlayRepository
    {
        const string ConnectionString = "Server=localhost;Database=HeadBallCoach;Trusted_Connection=True;";
        //GET ALL PLAYS
        public IEnumerable<Play> GetAllPlays()
        {
            using (var db = new SqlConnection(ConnectionString))
            {
                return db.Query<Play>("select * from plays");
            }

        }
        //*****GET A PLAYS BY PLAY TYPE (RUN OR PASS)*****
        public List<Play> GetPlaysByType(string typeOfPlay)
        {
            var sql = @"select *
                        from Plays
                        where TypeOfPlay = @TypeOfPlay";

            using (var db = new SqlConnection(ConnectionString))
            {
                var parameters = new { TypeOfPlay = typeOfPlay };

                var plays = db.Query<Play>(sql, parameters).ToList();

                return plays;
            }
        }
        //    var playsOfType = _plays.FindAll(p => p.TypeOfPlay.ToLower() == typeOfPlay);
        //    return playsOfType;
        //select*
        //from Plays
        // where TypeOfPlay = '@TypeOfPlay'

        //}
        //*****ADD A NEW PLAY*****
        public Play AddPlay(Play play)
        {
            var sql = @"insert into Plays(TypeOfPlay,Name)
                        output inserted.*
                        values(@TypeOfPlay,@Name)";

            using (var db = new SqlConnection(ConnectionString))
            {
                //ado net
                //db.Open();

                //var cmd = db.CreateCommand();

                //cmd.CommandText = sql;

                //cmd.Parameters.AddWithValue("TypeOfPlay", play.TypeOfPlay);
                //cmd.Parameters.AddWithValue("Name", play.Name);

                //var reader = cmd.ExecuteReader();

                //if (reader.Read())
                //{
                //    var newPlay = new Play
                //    {
                //        Id = (int)reader["Id"],
                //        Name = (string)reader["Name"],
                //        TypeOfPlay = (string)reader["TypeOfPlay"]
                //    };
                //    return newPlay;
                //}

                //reader.Close();

                //return null;
                var result = db.QueryFirstOrDefault<Play>(sql, play);
                return result;
            }
        }
        //*****GET A PLAY BY ID******
        public Play GetPlayById(int id)
        {
            var sql = @"select *
                         from Plays
                            where Id = @id";

            using (var db = new SqlConnection(ConnectionString))
            {
                var parameters = new { Id = id };
                var play = db.QueryFirstOrDefault<Play>(sql, parameters);
                return play;
            }
            //return _plays.FirstOrDefault(play => play.Id == id);
        }

        public Play UpdatePlay(Play play)
        {
            var sql = @"update Plays
                    set Name = Name + @NewName
                    output inserted.*
                    where Id = @Id";

            using (var db = new SqlConnection(ConnectionString))
            {
                var parameters = new
                {
                    NewName = play.Name,
                    Id = play.Id
                };

                return db.QueryFirstOrDefault<Play>(sql, parameters);
            }
        }
    
        //    //update play
        //    //add to play list
        //    return updatedPlay;
        }
    }

