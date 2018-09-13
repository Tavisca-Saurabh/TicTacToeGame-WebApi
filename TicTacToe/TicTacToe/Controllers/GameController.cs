using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TicTacToe.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [Log]
    [Exception]
    public class GameController : Controller
    {
        static int[] board = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        static int boardCount = 0;
        static bool playerOnePlayed = true;
        static bool playerSecondPlayed = true;
        // GET api/values
        [HttpGet]

        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        //// POST api/values
        //[HttpPost]
        //public void Post([FromBody]string value)
        //{
        //}
        // POST api/values
        [HttpPost("{id}")]
        public ActionResult makeMove(int id)
        {
            id--;
            if (id >= 0 && id <= 8)
            {
                bool playerOne = AuthorizeAttribute.playerOne;
                bool playerSecond = AuthorizeAttribute.playerSecond;
                if (playerOne)
                {
                    if (playerOnePlayed)
                    {
                        if(board[id]!='x' && board[id] != 'o') {
                            board[id] = 'x';
                            playerOnePlayed = false;
                            playerSecondPlayed = true;
                        }
                        else
                        {
                            return BadRequest("Position is not Empty");
                        }
                        if (CheckWin() == 1)
                        {
                            return Ok("Player 1 is Winner");
                        }
                        else
                        {
                            boardCount++;
                            return Ok("Added to Board");
                        }
                    }
                    else
                    {
                        return BadRequest("Player 2 Turn");
                    }
                }
                else if (playerSecond)
                {
                    if (playerSecondPlayed)
                    {
                        if (board[id] != 'x' && board[id] != 'o')
                        {
                            board[id] = 'o';
                            playerSecondPlayed = false;
                            playerOnePlayed = true;
                        }
                        else
                        {
                            return BadRequest("Position is not Empty");
                        }
                        if (CheckWin() == 1)
                        {
                            return Ok("Player 2 is Winner");
                        }
                        else
                        {
                            boardCount++;
                            return Ok("Added to Board");
                        }
                    }
                    else
                    {
                        return BadRequest("Player 1 Turn");
                    }
                }

                if(boardCount==9 && CheckWin() == -1)
                {
                    return Ok("Match Draw");
                }
            }
            return BadRequest("Index out of board");
        }
        //Checking that any player has won or not  

        private int CheckWin()
        {
            //horizontal Winning Condtion

            //Winning Condition For First Row   
            if (board[0] == board[1] && board[1] == board[2])
            {
                return 1;
            }
            //Winning Condition For Second Row   
            else if (board[3] == board[4] && board[4] == board[5])
            {
                return 1;
            }
            //Winning Condition For Third Row   
            else if (board[6] == board[7] && board[7] == board[8])
            {
                return 1;
            }

            //vertical Winning Condtion

            //Winning Condition For First Column       
            else if (board[0] == board[3] && board[3] == board[6])
            {
                return 1;
            }
            //Winning Condition For Second Column  
            else if (board[1] == board[4] && board[4] == board[7])
            {
                return 1;
            }

            //Winning Condition For Third Column  
            else if (board[2] == board[5] && board[5] == board[8])
            {
                return 1;
            }

            //Diagonal Winning Condition
            else if (board[0] == board[4] && board[4] == board[8])
            {
                return 1;
            }
            else if (board[2] == board[4] && board[4] == board[6])
            {
                return 1;
            }

            //Checking For Draw
            // If all the cells or values filled with X or O then any player has won the match  
            else if (board[0] != '1' && board[1] != '2' && board[2] != '3' && board[3] != '4' && board[4] != '5' && board[5] != '6' && board[6] != '7' && board[7] != '8' && board[8] != '9')
            {
                return -1;
            }
            else
            {
                return 0;
            }

        }


        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
