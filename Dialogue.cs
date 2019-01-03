using System;
using System.Collections.Generic;
using EpicTale.Models;

namespace EpicTale
{
    public class Dialogue
    {
        public void PrintIntro(List<Being> party, Player chico, Monster ganondorf)
        {
            Console.Write($"Welcome, ");
            PrintColoredText(ConsoleColor.Yellow, "brave hero");
            Console.WriteLine("!");
            Console.Write("Our lands are in peril and is currently being terrorized by ");
            PrintColoredText(ConsoleColor.Yellow, "The Great Demon Ganondorf");
            Console.WriteLine("!");

            Console.Write("But now, the ");
            PrintColoredText(ConsoleColor.Yellow, "heavens");
            Console.Write(" have brought forth ");
            PrintColoredText(ConsoleColor.Yellow, "you");
            Console.Write(", the ");
            PrintColoredText(ConsoleColor.Yellow, "Legendary Hero");
            Console.Write(", capable of ");
            PrintColoredText(ConsoleColor.Yellow, "slaying all evil");
            Console.Write(" and ");
            PrintColoredText(ConsoleColor.Yellow, "piercing open a path of light");
            Console.WriteLine("!\n");
            PrintDashedLine();

            var hero = party.Find(x => x.GetType() == typeof(Hero));

            hero.Name = PickName();
            while(hero.Race == null){
                try{
                    hero.Race = PickRace();
                }catch(NullReferenceException ex){
                    System.Console.WriteLine($"Foutje: {ex}");
                }
            }

            PrintDashedLine();
            Console.WriteLine("");
            Console.Write("Oh, great ");
            PrintColoredText(ConsoleColor.Yellow, hero.Race.Name);
            Console.Write(" ");
            PrintColoredText(ConsoleColor.Yellow, hero.Name);
            Console.Write("! Please save this ");
            PrintColoredText(ConsoleColor.Yellow, "village ");
            Console.Write("and the entire ");
            PrintColoredText(ConsoleColor.Yellow, "planet ");
            Console.Write("from the wicked clutches of ");
            PrintColoredText(ConsoleColor.Yellow, "Ga-\n");

            PrintColoredText(ConsoleColor.Red, "???: Watch out Great Hero!\n");
            Console.Write("Village Chief: ");
            PrintColoredText(ConsoleColor.Yellow, $"{chico.Name}");
            Console.WriteLine(", my child. Are you alright??");
            PrintNarrativeText($"{chico.Name} covered the hero and took the damage");
            chico.CurrentHP /= 2;

            Console.Write("???: Foolish mortals. Only death awaits those conspiring against ");
            PrintColoredText(ConsoleColor.Yellow, $"The Great {ganondorf.Name}");
            Console.WriteLine("!");
            
            Console.Write("Village Chief: Oh great ");
            PrintColoredText(ConsoleColor.Yellow, "hero");
            Console.Write(", please ");
            PrintColoredText(ConsoleColor.Yellow, "save ");
            Console.WriteLine("us!");

            PrintColoredText(ConsoleColor.Red, "\nQ: Will you help the villagers? Y/N\n");
            string playersAnswer = CheckPlayersAnswer();

            if(playersAnswer.Equals("N")){
                Console.WriteLine($"{hero.Name}: Aaah hell naahh, I'm out!\n");

                PrintDashedLine();
                Console.Write("A mere");
                PrintColoredText(ConsoleColor.Red, " 3 days later");
                Console.Write(", all villagers ");
                PrintColoredText(ConsoleColor.Red, "died ");
                Console.Write("a ");
                PrintColoredText(ConsoleColor.Red, "cruel death");
                Console.WriteLine("..");
                
                Console.Write("The ");
                PrintColoredText(ConsoleColor.Yellow, "village ");
                Console.Write("has been ");
                PrintColoredText(ConsoleColor.Red, "destroyed");
                //"And there is no sign of anything or anyone (add later..)
                //Also add Chico's lines and death
                Console.WriteLine(".");

                PrintDashedLine();
            }else if(playersAnswer.Equals("Y")) {
                Console.WriteLine($"{hero.Name}: Fine, I accept your request and will execute the demon terrorizing these lands.");
                Console.WriteLine($"{chico.Name}: I will assist you, my hero!");
                party.Add(chico);


                //Call Battle mode, Hero party vs Ganondorf
            }

            //Continue to the main game
        }

        private void PrintNarrativeText(string text)
        {
            PrintColoredText(ConsoleColor.Cyan, $"\n|| {text} ||\n\n");
        }

        private void PrintDashedLine()
        {
            Console.WriteLine("--------------------------");
        }

        private static string CheckPlayersAnswer()
        {
            // string answer;
            // do{
            //     answer = Console.ReadLine().ToUpper();
            // }while(!answer.Equals("Y") && !answer.Equals("N"));

            // return answer;
            string answer = "";

            while(!answer.Equals("Y") && !answer.Equals("N")){
                answer = Console.ReadLine().ToUpper();

                if(!answer.Equals("Y") && !answer.Equals("N")){
                    Console.WriteLine("Please answer with a Y or N.");
                }
            }
            return answer;
        }

        private Race PickRace()
        {
            Race race;
            int choice = 0;

            while(choice < 1 || choice > 3)
            {
                System.Console.Write("Pick a ");
                PrintColoredText(ConsoleColor.Yellow, "Race");
                System.Console.WriteLine("..");
                System.Console.WriteLine("1 for Saiyan - 2 for Human - 3 for Namekian");
                
                int.TryParse(Console.ReadLine(), out choice);
            }
            
            switch(choice){
                case 1:
                    race = new Saiyan();
                    break;
                case 2:
                    race = new Human();
                    break;
                case 3:
                    race = new Namekian();
                    break;
                default:
                    race = null;
                    break;
            }

            return race;
        }

        private string PickName()
        {
            string name = "";

            while(string.IsNullOrEmpty(name) || name.Length < 3)
            {
                Console.WriteLine("What may we call our Hero?");
                name = Console.ReadLine();
            }

            return name;
        }

        private static void PrintColoredText(ConsoleColor color, string textToColor)
        {
            Console.ForegroundColor = color;
            Console.Write(textToColor);
            Console.ResetColor();
        }
    }
}