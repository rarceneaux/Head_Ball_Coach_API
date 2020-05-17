using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HeadBallCoach.DataAccess;
using HeadBallCoach.Models;

namespace HeadBallCoach.Controllers
{
    [Route("api/plays")]
    [ApiController]
    public class PlayController : ControllerBase
    {
        PlayRepository _playRepository = new PlayRepository();



        //*****Get All Plays*****
        [HttpGet]
        public IActionResult GetAllPlays()
        {
            var allPlays = _playRepository.GetAllPlays();
            return Ok(allPlays);
        }

        //*****Add A New Play******
        [HttpPost]
        public IActionResult AddNewPlay(Play playToAdd)
        {
            var playAdded = _playRepository.AddPlay(playToAdd);
            return Created("", playAdded);
        }


        /***DELETE PLAY
        //[HttpDelete("{id}")]
        //public IActionResult DeletePlay(int id)
        //{
        //    throw new NotImplementedException();
        //}




            //**GET PLAY BY TYPE RUN OR PASS
        /*https://localhost:44381/api/plays/pass/play */
        [HttpGet("{typeOfPlay}/play")]
        public IActionResult GetPlayByType(string typeOfPlay)
        {
            var playCalled = _playRepository.GetPlaysByType(typeOfPlay);
            return Ok(playCalled);//
        }



        //** GET PLAY BY ID
        /* https://localhost:44381/api/plays/# */
        //Get Play By Id
        [HttpGet("{id}")]
            public IActionResult GetPlayById(int id)
        {
            var play = _playRepository.GetPlayById(id);
            if (play == null) return NotFound("This Play is not in our playbook coach.");
            return Ok(play);
        }



        //TOTALLY WRONG BUT WTH Im Learning and that is the point!!!
        [HttpPut("{id}")]
            public IActionResult UpdateAnPlay(int id, Play play)
            {
               // var playToRedo = play;
                var playToUpdate = _playRepository.GetAllPlays().First(p => p.Id == play.Id);
                var playToupdate = _playRepository.GetPlayById(id);

            //TOTALLY WRONG BUT WTH Im Learning and that is the point!!!
                playToUpdate = playToupdate;
                return Ok(playToupdate);

            }
        }
    }
