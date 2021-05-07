﻿using System;
using System.Collections.Generic;
using System.Text;
using System;
using System.IO;
using System.IO.Pipes;


namespace Chess2_redo
{
    public class PipeServer
    {
   
        public void sendData(string result)
        {
            using (NamedPipeServerStream pipeServer =
            new NamedPipeServerStream("chess-pipe-1", PipeDirection.InOut))
            {

                Console.WriteLine("trying to get connected.");
                pipeServer.WaitForConnection();

                Console.WriteLine("Client connected.");
                try
                {
                    using (StreamWriter sw = new StreamWriter(pipeServer))
                    {
                        sw.AutoFlush = true;
                        sw.WriteLine(result);

                    }

                }
                catch (IOException e)
                {
                    Console.WriteLine("ERROR: {0}", e.Message);
                }

                pipeServer.Dispose();
            }
        }


        public void reciveData()
        {
            using (NamedPipeClientStream pipeClient =
                  new NamedPipeClientStream(".", "chess-pipe-2", PipeDirection.InOut))
            {

                // Connect to the pipe or wait until the pipe is available.
                Console.Write("Attempting to connect to pipe...");
                pipeClient.Connect();

                Console.WriteLine("Connected to pipe.");
                Console.WriteLine("There are currently {0} pipe server instances open.",
                   pipeClient.NumberOfServerInstances);


                using (StreamReader sr = new StreamReader(pipeClient))
                {
                    // Display the read text to the console
                    //List<string> temp2;

                    string temp;
                    while ((temp = sr.ReadLine()) != null)
                    {
                        string[] temp3 = temp.Split(',');
                        Console.WriteLine("Received from server: {0}", temp3[0]);

                        if (temp != null)
                        {
                            MainClass.userInput = temp3[0];
                        }

                        
                    }
                    pipeClient.Dispose();

                }
            }
        }
    }
}
