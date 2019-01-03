using System;
using System.Collections.Generic;
using EpicTale.Models;

namespace EpicTale
{
    //Klasse statisch maken, omdat er altijd maar één Game object kan zijn.
    //Hierdoor kun je het Game object, met de properties en alle methodes, gebruiken in ieder ander klasse
    public class Game
    {
        private Parser parser;

        private List<Being> party;
        private Hero hero;
        private Player chico;
        private Monster ganondorf;
        private Monster miniondorf;

        private Dialogue dialogue;

        public Game()
        {
            parser = new Parser();
            dialogue = new Dialogue();
            SetupGame();

            Play();
        }

        private void SetupGame()
        {
            CreatePlayersAndParty();
            CreateMonsters();
            CreateAreas();
            CreatePlanets();
            CreateAbilityTypes();
            CreateAbilities();
        }

        private void CreatePlayersAndParty()
        {
            party = new List<Being>();

            hero = new Hero();
            chico = new Player("Chico", new Human());

            party.Add(hero);
        }

        private void CreateMonsters()
        {
            ganondorf = new Monster("Ganondorf", 21, 2358, 1035, 100);
            miniondorf = new Monster("Miniondorf", 2, 600, 200, 10);
        }

        private void CreateAbilityTypes()
        {
            AbilityType physical, magic;

            physical = new AbilityType("physical");
            magic = new AbilityType("magic");
        }

        private void CreateAbilities()
        {
            Ability randomized1, randomized2, randomized3, randomized4, randomized5;

            randomized1 = new Ability();
            randomized2 = new Ability();
            randomized3 = new Ability();
            randomized4 = new Ability();
            randomized5 = new Ability();
        }

        private void CreatePlanets()
        {
            //throw new NotImplementedException();

            //Player has to fall into a random area on a planet when traveling for the first time.
            //"Oh no, the hero landed into the Boss' lair", is a possible outcome.
            //In that case, the boss is escapable however.
        }

        private void CreateAreas()
        {
            Area sweetlake, yorkshin, istangrad, neotokyo, kush;

            sweetlake = new Area("Sweet Lake City");
            yorkshin = new Area("York Shin City");
            istangrad = new Area("Istangrad City");
            neotokyo = new Area("Neo Tokyo City");
            kush = new Area("Kush City");

            sweetlake.SetNeighbor("west", yorkshin);
            sweetlake.SetNeighbor("south", istangrad);
            sweetlake.SetNeighbor("north", neotokyo);
            sweetlake.SetNeighbor("east", kush);

            yorkshin.SetNeighbor("east", sweetlake);
            yorkshin.SetNeighbor("south", istangrad);
            yorkshin.SetNeighbor("north", neotokyo);

            istangrad.SetNeighbor("north", sweetlake);
            istangrad.SetNeighbor("west", yorkshin);
            istangrad.SetNeighbor("east", kush);

            neotokyo.SetNeighbor("south", sweetlake);
            neotokyo.SetNeighbor("west", yorkshin);
            neotokyo.SetNeighbor("east", kush);

            kush.SetNeighbor("west", sweetlake);
            kush.SetNeighbor("south", istangrad);
            kush.SetNeighbor("north", neotokyo);

            hero.SetCurrentArea(sweetlake);
        }

        private void Play()
        {
            bool quit = false;

            dialogue.PrintIntro(party, chico, ganondorf);
            
            while(!quit){
                string[] cmd = parser.ReadCommand();

                switch(cmd[0]){
                    case "quit":
                        quit = true;
                        break;
                    case "go":
                        MovePlayers(cmd[1]);
                        break;
                    case "fight":
                        FightMode();
                        break;
                    case "help":
                        Help();
                        break;
                }
            }

            Quit();
        }

        private void MovePlayers(string direction)
        {
            foreach(Being b in party){
                b.Go(direction);
            }
        }

        private void FightMode()
        {
            throw new NotImplementedException(); //Fight or Flee, new commands for battle, new while loop probably
        }

        private void Quit()
        {
            System.Console.WriteLine("Thanks for playing.");
            Environment.Exit(0);
        }

        private void Help()
        {
            System.Console.WriteLine("I aint helpin you.");
        }
    }
}