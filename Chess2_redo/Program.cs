using System;
using System.Text.Json;

namespace Chess2_redo
{
    //program will recive a string which is turned into an array 
    //array[0] is the x cord
    //array[1] is the y cord
    //array [2] is the piece that is to be moved
    class MainClass
    {       
        
        public static string userInput;
        public static Piece cunrrentPiece;
        public static int inputx;
        public static int inputy;
        public static Game game;

        public static bool gameOver { get; set; } = false;


        public static void Main(string[] args)
        {   
            //creates a new game
            game = new Game();
     
            setCurrentPiece(game.br1);
            setCord(0, 2);
      
            game.board.updateOneDAryAndList();
            
            PipeServer pipe = new PipeServer();

            while (!gameOver) {

                pipe.reciveData();
                if (userInput != null) 
                {   
                    SwitchBoard.handelRequest(userInput);
                    userInput = null;
                    pipe.sendData("Hello");
                }
                //await pipe.reciveData();
                
            }

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


