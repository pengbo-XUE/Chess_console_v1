using System;
using System.Text.Json;

namespace Chess2_redo
{
    class MainClass
    {       
        
        public static string userInput = "move";
        public static Piece cunrrentPiece;
        public static int inputx;
        public static int inputy;
        public static Game game;
        public static bool gameOver { get; set; } = false;


        public static void Main(string[] args)
        {   
            //creates a new game
            game = new Game();
           

            //console.logs the json ary
          /*  foreach (var i in game.board.boardJson)
            {
                Console.WriteLine(i);
            }*/

            //hard code cunrrent piece DELETE LATER
            setCurrentPiece(game.br1);

            //hard code move test DELETE LATER
            
            

            //hard code set cord DELETE LATER
            setCord(0, 2);
            //hard coded update one D ary
            game.board.updateOneDAryAndList();

            //Console.WriteLine(game.br1.move(0,7));

            //test turning obj in to JSON DELETE LATER
           
            

                 switch (userInput)
                 {
                     case "move":
                         //Console.WriteLine(cunrrentPiece);
                         cunrrentPiece.move(inputx, inputy);
                         if (CheckWin.check())
                         {
                             gameOver = true;
                         }

                        
                         break;
                     case "reset":
                         game = new Game();
                         break;

                 }

            game.board.writeToTxt();
        }

        public static void setCurrentPiece(Piece p) 
        {
            cunrrentPiece = p;
        }

        //gets the position of a piece
        public static string getPiecePosition(Piece p)
        {
            return $"{p.x} {p.y}";
        }

        //gets the cord from pipe and set it to the prop
        public static void setCord(int x, int y)
        {
            inputx = x;
            inputy = y;
        }


    }
}


