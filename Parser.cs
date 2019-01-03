using System;

namespace EpicTale
{
    public class Parser
    {
        Commands cmd;

        public Parser()
        {
            cmd = new Commands();
        }
        
        public string[] ReadCommand(){
            return Console.ReadLine().ToLower().Split();
        }

        // private bool checkCommands(string cmd1, string cmd2){
        //     if(string.IsNullOrEmpty(cmd1)){
        //         return false;
        //     }

        //     return true;
        // }
    }
}