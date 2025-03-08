using Microsoft.AspNetCore.Mvc;
using TicTacToe.Models;

namespace TicTacToe.Controllers
{
    public class GameController : Controller
    {
        private static GameModel _game = new GameModel();

        public IActionResult Index()
        {
            return View(_game);
        }

        public IActionResult MakeMove(int row, int col)
        {
            _game.MakeMove(row, col);
            return RedirectToAction("Index");
        }

        public IActionResult Reset()
        {
            _game = new GameModel();
            return RedirectToAction("Index");
        }

        public IActionResult ToggleAI()
        {
            _game.ToggleAI();
            return RedirectToAction("Index");
        }
    }
}
