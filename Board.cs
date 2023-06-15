using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe;

namespace Du_an_C_thang_2
{
    public class Board
    {
        public const int BOARD_SIZE = 25;    //kích thước cố định
        public Cell[,] board;               //ma trận 2 chiều
        int Save_verticalY;
        int Save_horizontalX;

        public int Get_Save_horizontalX() { return Save_horizontalX; }
        public int Get_Save_verticalY() { return Save_verticalY; }

        //Khởi tạo bảng rỗng
        public Board()
        {
            int Save_verticalY = 0;
            int Save_horizontalX = 0;
            board = new Cell[BOARD_SIZE, BOARD_SIZE];
            for (int i = 0; i < BOARD_SIZE; i++)
            {
                for (int j = 0; j < BOARD_SIZE; j++)
                {
                    board[i, j] = new Cell();
                }
            }
        }
        //Hiển thị bảng
        public void printBoard()
        {
            int fieldNumber = 1;
            Console.WriteLine("---------------------------------------------------------------------------------");
            for (int i = 0; i < BOARD_SIZE; i++)
            {
                for (int j = 0; j < BOARD_SIZE; j++)
                {
                    if (board[i, j].isEmpty())
                    {
                        if(fieldNumber < 10)
                        {
                            Console.Write("00" + fieldNumber);
                        } else if(fieldNumber < 100)
                        {
                            Console.Write("0" + fieldNumber);
                        }else Console.Write( fieldNumber);


                    }    
                        
                    else
                    {
                       //if( (char)(board[i, j].getFieldState() == "X")){ }
                       
                        Console.Write(" " + (char)(board[i, j].getFieldState()) + " ");
                    }
                    fieldNumber++;

                    if (j < BOARD_SIZE - 1) Console.Write("|");
                }
                Console.Write("\n");
            }
            Console.WriteLine("---------------------------------------------------------------");
        }
        //Xác định tạo độ
        public void putMark(Player player, int fieldNumber)
        {
            int verticalY = (fieldNumber - 1) / BOARD_SIZE;
            int horizontalX = (fieldNumber - 1) % BOARD_SIZE;
            if (board[verticalY, horizontalX].isEmpty())
            {
                board[verticalY, horizontalX].markField(player);
                Save_verticalY = verticalY;
                Save_horizontalX = horizontalX;
            }
            else
            {
                Console.WriteLine("Vi tri nay da duoc chon, hay chon vi tri khac: ");
                putMark(player, player.takeTurn());
            }
        }
        //Xóa bảng
        public void clearBoard()
        {
            Console.Clear();
        }

       
        
    }
}
