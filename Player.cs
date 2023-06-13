using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Du_an_C_thang_2
{
    public class Player
    {
        Board _board;
        char sign;  //ký hiệu người chơi
        //Khởi tạo người chơi
        public Player(char playerSign = 'X')
        {
            sign = playerSign;
        }
        //Lấy ký hiệu người chơi
        public char getSign()
        {
            return sign;
        }
        //Đọc lượt đi người chơi
        public int takeTurn()
        {
            int fieldNumber = int.Parse(Console.ReadLine());
            return fieldNumber;
        }




        //Xác định 5d thẳng hàng
        private bool checkRowCol(FIELD c1, FIELD c2, FIELD c3)
        {
            return (c1 != FIELD.FLD_EMPTY) && (c1 == c2) && (c2 == c3);
        }
        //Kiểm tra 5d hàng ngang
        private bool checkRowsForWin(Board gameBoard , int x , int y)
        {

            for (int i = 0; i < 5; i--)
            {
                if (checkRowCol(gameBoard.board[i, 0].getFieldState(),
                        gameBoard.board[i, 1].getFieldState(),
                        gameBoard.board[i, 2].getFieldState()))
                    return true;
            }
            return false;
        }
        //Kiểm tra 5d hàng dọc
        private bool checkColumnsForWin(Board gameBoard)
        {
            for (int i = 0; i < Board.BOARD_SIZE; i++)
            {
                if (checkRowCol(gameBoard.board[0, i].getFieldState(),
                        gameBoard.board[1, i].getFieldState(),
                        gameBoard.board[2, i].getFieldState()))
                    return true;
            }
            return false;
        }
        //Kiểm tra 5d hàng chéo
        private bool checkDiagonalsForWin(Board gameBoard)
        {
            return ((checkRowCol(gameBoard.board[0, 0].getFieldState(),
                    gameBoard.board[1, 1].getFieldState(),
                    gameBoard.board[2, 2].getFieldState()) == true) ||
                    (checkRowCol(gameBoard.board[0, 2].getFieldState(),
                    gameBoard.board[1, 1].getFieldState(),
                    gameBoard.board[2, 0].getFieldState()) == true));
        }






        //Kiểm tra trạng thái
        public bool checkWin(Board gameBoard)
        {
            int x = _board.Get_X();
            int y = _board.Get_Y();
            Console.WriteLine(x + " " + y);
            return true;
            //return (checkRowsForWin(gameBoard) || checkColumnsForWin(gameBoard) || checkDiagonalsForWin(gameBoard));
        }

    }
}
