using Microsoft.AspNetCore.Mvc;
using SuperFarmer.Src;

namespace SuperFarmer.Controllers
{
    [ApiController]
    [Route("api")]
    public class SuperFarmerController : ControllerBase
    {
        [HttpPost("newGame/{gameID}/{player}")]
        public void newGame(string gameID, string player)
        {
            try
            {
                GameManager.CreateGameAndAddPlayers(gameID, player);
            }
            catch (Exception)
            {
                throw;
            }
            
        }
        [HttpGet("GetAnimals/{gameID}/{player}")]
        public Animals GetAnimals(string gameID, string player)
        {
            try
            {
                return GameManager.GetPlayerAnimals(gameID, player);
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        [HttpGet("GetBank/{gameID}")]
        public Animals GetBank(string gameID)
        {
            try
            {
                return GameManager.GetBank(gameID);
            }
            catch (Exception)
            {
                throw;
            }

        }

        [HttpGet("GetCurrentPlayer/{gameID}")]
        public string GetCurrentPlayer(string gameID)
        {
            try
            {
                return GameManager.GetCurrentPlayer(gameID);
            }
            catch (Exception)
            {
                throw;
            }

        }

        [HttpPost("Trade/{gameID}/{player}/{tradeID}")]
        public Animals Trade(string gameID, string player, int tradeID)
        {
            try
            {
                return GameManager.MakeTrade(gameID, player, tradeID);
            }
            catch (Exception)
            {
                throw;
            }

        }

        [HttpPost("Roll/{gameID}/{player}")]
        public GameManager.RollRespone Roll(string gameID, string player)
        {
            try
            {
                return GameManager.RollForPlayer(gameID, player);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}