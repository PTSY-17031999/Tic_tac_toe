using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Du_an_C_thang_2
{
    class Du_an_C_thang_2
    {
        //Khoi tao
        public Du_an_C_thang_2()
        {
            play();
        }

        //Luot choi
        public void play()
        {
            int moveCounter = 0;
            Board gameBoard = new Board();

            Player playerX = new Player('X');
            Player playerO = new Player('O');
            Player currentPlayer = playerX;

            bool play = true;
            while (play)
            {
                gameBoard.printBoard();
                Console.WriteLine("Nguoi choi: {0} Toi luot ban choi ", currentPlayer.getSign());
               // Console.WriteLine(currentPlayer.checkWin(gameBoard).ToString());
                try
                {
                    gameBoard.putMark(currentPlayer, playerX.takeTurn());
                    gameBoard.clearBoard();
                    moveCounter++;
                    
                    if (currentPlayer.checkWin(gameBoard))
                    {
                        Console.WriteLine("Nguoi choi: {0} THANG!", currentPlayer.getSign());
                        gameBoard.printBoard();
                        play = false;
                    }
                    else if (checkDraw(moveCounter))
                    {
                        Console.WriteLine("DRAW");
                        gameBoard.printBoard();
                        play = false;
                    }
                    currentPlayer = (moveCounter % 2 == 0) ? playerX : playerO;
                }
                catch (Exception)
                {
                    Console.WriteLine("NHAP TU 1 - 625 !");
                    Console.ReadLine();
                    Console.Clear();
                }
            }
        }

        //Kiem tra luot di cuoi
        private bool checkDraw(int turnCounter)
        {
            if (turnCounter == 625)
                return true;
            return false;
        }
    }
}
