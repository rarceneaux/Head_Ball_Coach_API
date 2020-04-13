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

        //Get All Plays
        [HttpGet]
        public IActionResult GetAllPlays()
        {
            var allPlays = _playRepository.GetAllPlays();
            return Ok(allPlays);
        }

        //Add A New Play
        [HttpPost]
        public IActionResult AddNewPlay(Play playToAdd)
        {
            _playRepository.AddPlay(playToAdd);
            return Created("", playToAdd);
        }

        /*Get Play By Type
        [HttpGet("{typeOfPlay}/play")]
        public IActionResult GetPlayByType(string typeOfPlay)
        {
            var playCalled = _playRepository.GetPlayByType(typeOfPlay);
            return Ok(playCalled);//
        }*/

        //Get Play By Id
        [HttpGet("{id}")]
        public IActionResult GetPlayById(int id)
        {
            var play = _playRepository.GetPlayById(id);
            if (play == null) return NotFound ("This Play is not in our Playbook.");
            return Ok(play);
        }

     }
    
}