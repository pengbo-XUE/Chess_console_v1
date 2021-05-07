﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Chess2_redo
{
    public static class SwitchBoard
    {
        public static void handelRequest(string request)
        {

            switch (request)
            {
                case "move":
                    //Console.WriteLine(cunrrentPiece);
                    MainClass.cunrrentPiece.move(MainClass.inputx, MainClass.inputy);
                    if (CheckWin.check())
                    {
                        MainClass.gameOver = true;
                    }
                    Console.WriteLine("Piece moved");
                    break;
                case "reset":
                    //MainClass.game = new Game();
                    Console.WriteLine("Board reset");
                    break;
            }
        }
    }
}
