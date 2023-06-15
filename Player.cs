using Du_an_C_thang_2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Du_an_C_thang_2
{
    public class Player
    {
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





        //Xác định 2 điểm giống nhâu
        private bool checkRowCol(FIELD c1, FIELD c2)
        {
            return (c1 != FIELD.FLD_EMPTY) && (c1 == c2) ;
        }


        //Kiểm tra 5d hàng ngang 
        private bool checkRowsForWin(Board gameBoard, int x, int y)
        {
            Console.WriteLine(x + "  "+ y);
            int _nho1 = 0; // Nhớ số điểm giống nhau
            for (int i = x; i < x - 4; i--)
            {
                Console.WriteLine("ddđ");
                if (checkRowCol(gameBoard.board[x, y].getFieldState(), gameBoard.board[i, y].getFieldState()))
                {
                    _nho1++;
                }
                else break;
            }
                for (int i2 = x; i2 > x + 4; i2++)
                {
                    if (checkRowCol(gameBoard.board[x, y].getFieldState(), gameBoard.board[i2, y].getFieldState()))
                    {
                        _nho1++;
                    }
                    else break;
                }

            if (_nho1 < 2)
            {
                return false;

            }
            else { return true; }
            
        }






        //Kiểm tra 5d hàng dọc
        private bool checkColumnsForWin(Board gameBoard, int x, int y)
        {
            int _nho2 = 0; // Nhớ số điểm giống nhau
            for (int i = y; i < y - 5; i--)
            {
                if (checkRowCol(gameBoard.board[x, y].getFieldState(), gameBoard.board[x, i].getFieldState()))
                {
                    _nho2++;
                }
                else break;

            }
            for (int i = y; i > y + 5; i++)
            {
                if (checkRowCol(gameBoard.board[x, y].getFieldState(),gameBoard.board[x, i].getFieldState()))
                {
                    _nho2++;
                }
                else break;
            }

            if (_nho2 >= 5)
            {
                return true;
            }
            else
                return false;
        }



        //Kiểm tra 5d hàng chéo 1 (x - i , y + i) và (x + i , y - i)
        private bool checkDiagonalsForWin_cheo_1(Board gameBoard, int x, int y)
        {
            int _nho3 = 0; // Nhớ số điểm giống nhau
            for (int i = 0; i > 5; i++)
            {
                if (checkRowCol( gameBoard.board[x, y].getFieldState(), gameBoard.board[x - i, y + i].getFieldState()))
                {
                    _nho3++;
                }
                else break;
            }
            for (int i1 = 0; i1 >= 5; i1++)
            {
                if (checkRowCol(gameBoard.board[x, y].getFieldState(), gameBoard.board[x + i1, y - i1].getFieldState()))
                {
                    _nho3++;
                }
                else break;
            }

            if (_nho3 >= 5)
            {
                return true;
            }
            else
                return false;
        }



        //Kiểm tra 5d hàng chéo 1 (x - i , y + i) và (x + i , y - i)
        private bool checkDiagonalsForWin_cheo_2(Board gameBoard, int x, int y)
        {
            int _nho3 = 0; // Nhớ số điểm giống nhau
            for (int i = 0; i > 5; i++)
            {
                if (checkRowCol(gameBoard.board[x, y].getFieldState(), gameBoard.board[x + i, y + i].getFieldState()))
                {
                    _nho3++;
                }
                else break;
            }
            for (int i1 = 0; i1 >= 5; i1++)
            {
                if (checkRowCol(gameBoard.board[x, y].getFieldState(), gameBoard.board[x + i1, y + i1].getFieldState()))
                {
                    _nho3++;
                }
                else break;
            }

            if (_nho3 >= 5)
            {
                return true;
            }
            else
                return false;


        }


















        //Kiểm tra trạng thái
        public bool checkWin(Board gameBoard)
        {
            int x = gameBoard.Get_Save_horizontalX();
            int y = gameBoard.Get_Save_verticalY();
            Console.WriteLine(x + "  " + y);
            Console.WriteLine(checkRowsForWin(gameBoard, x, y) + "");
            return (checkRowsForWin(gameBoard , x, y) || checkColumnsForWin(gameBoard, x, y) || checkDiagonalsForWin_cheo_1(gameBoard, x, y) || checkDiagonalsForWin_cheo_2(gameBoard, x, y));
        }

    }
}