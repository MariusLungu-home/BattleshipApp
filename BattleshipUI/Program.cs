using BattleshipLibrary;
using BattleshipLibrary.Models;

namespace BattleshipUI
{
    class Program
    {
        static void Main(string[] args)
        {
            UI.WelcomeMessage();

            PlayerInfoModel activePlayer = UI.CreatePlayer("Player 1");
            PlayerInfoModel opponent = UI.CreatePlayer("Player 2");
            PlayerInfoModel winner = null;

            do
            {
                UI.DisplayShotGrid(activePlayer);
                UI.RecordPlayerShot(activePlayer, opponent);

                bool doesGameContinue = GameLogic.PlayerStillActive(opponent);

                if (doesGameContinue == true)
                {
                    // swap using tuple
                    (activePlayer, opponent) = (opponent, activePlayer);
                }
                else 
                { 
                    winner = activePlayer;
                }

            } while (winner == null);

            UI.IdentifyWinner(winner);

            Console.ReadLine();
        }
    }
}