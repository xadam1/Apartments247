﻿using System.Linq;
using System;
using BLL;
using DAL.Models;

namespace FrontendConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            // Spuštění aplikace
            new ConsoleApp();
        }
    }

    public class ConsoleApp
    {

        private Engine engine = new Engine();
        private Action unimpl = () => Console.WriteLine("Unimplemented");

        public ConsoleApp()
        {
            // Viz logický DFA
            PromptStart();
        }

        private void Prompt((string name, Action act)[] options, string info)
        {
            Prompt(options, () => Console.WriteLine(info.Length != 0 ? info : "InfoIsEmpty"));
        }

        private void Prompt((string name, Action act)[] options, Action start)
        {
            bool run = true;
            while (run)
            {
                start();

                Array.ForEach(Utils.Enumerate(options), opt =>
                    Console.WriteLine($"{opt.i + 1} - {opt.val.name}"));
                Console.WriteLine("q - Exit");

                int next = 0;
                string input = null;
                do
                {
                    input = Console.ReadLine();
                    if (input == "q")
                    {
                        run = false;
                    }
                } while (run && (!int.TryParse(input, out next) || next <= 0 || next > options.Length));

                if (run)
                {
                    options[next - 1].act();
                }
            }
        }

        private void PromptStart()
        {
            Prompt(new (string, Action)[] { ("Sing Up", PromptNewAccount), ("Log in", PromptLogin) },
                "Start screen");
        }
        
        private void PromptNewAccount()
        {
            Prompt(new (string, Action)[] { ("Fast", () => PromptCreateAccount(false)), ("Advanced", () => PromptCreateAccount(true)) }, "Options to Create Account");
        }
        
        private void PromptCreateAccount(bool advanced)
        {
            (string name, string password, string email) = ("", "", "");

            Console.WriteLine("Insert Details");
            Console.Write("name: ");
            name = Console.ReadLine();
            Console.Write("password: ");
            password = Console.ReadLine();
            if (advanced)
            {
                Console.Write("email: ");
                email = Console.ReadLine();
            }
            if (!engine.BLLCreateAccount(name, password, email))
            {
                Console.WriteLine("Account already exists");
            }
        }
        
        private void PromptLogin()
        {
            Console.WriteLine("Type name and password");
            Console.Write("name: ");
            string name = Console.ReadLine();
            Console.Write("password: ");
            string password = Console.ReadLine();

            (bool result, int userID) = engine.BLLGetUserIDByCredentials(name, password);

            if (result)
            {
                PromptDefaultScreen(userID);
            }
            else
            {
                Console.WriteLine("Account doesnt exist");
            }
        }
        
        private void PromptDefaultScreen(int userID)
        {
            Prompt(new (string, Action)[] { ("List my flats", unimpl /*PromptGroups*/), ("Create new flat", unimpl), ("Search", unimpl), ("Show User Details", () => PromptShowUserDetails(userID)) }, "Your Account");
        }
        /*
        private void PromptGroups()
        {
            string[] groups = engine.BLLListGroups(user);
            Prompt(T.Concat(T.Enumerate(groups).Select<(int i, string val), (string, Action)>(group => (group.val, () => PromptUnits(group.i))), new (string, Action)[] { }), "Your Groups");
        }

        private void PromptShowGroupDetails(int groupId)
        {
            unitGroup = engine.BLLGetGroupByID(groupId);

            Console.WriteLine($"name: {unitGroup.Specification.Name}");
            Console.WriteLine($"color: {unitGroup.Specification.Color}");
            Console.WriteLine($"note: {unitGroup.Specification.Note}");
            Console.WriteLine($"address: {unitGroup.Specification.Address}");

            Prompt(new (string, Action)[] { ("Change Group Details", () => PromptChangeGroupDetails()) }, "Group Details");
        }

        private void PromptChangeGroupDetails()
        {
            Prompt(new (string, Action)[] { ("Name", () => PromptSetGroupDetails(T.Binary("1000"))), ("Color", () => PromptSetGroupDetails(T.Binary("0100"))), ("Note", () => PromptSetGroupDetails(T.Binary("0010"))), ("Address", () => PromptSetGroupDetails(T.Binary("0001"))), ("All", () => PromptSetGroupDetails(T.Binary("1111"))) }, "Change Group Details");
        }

        private void PromptSetGroupDetails(int mode)
        {
            if ((mode & T.Binary("1000")) != 0)
            {
                Console.Write("name: ");
                unitGroup.Specification.Name = Console.ReadLine();
            }
            if ((mode & T.Binary("0100")) != 0)
            {
                int color = 0;
                Console.Write("color: ");
                if (!int.TryParse(Console.ReadLine(), out color))
                {
                    Console.WriteLine("You have to insert number");
                }
                else
                {
                    unitGroup.Specification.Color = color;
                }
            }
            if ((mode & T.Binary("0010")) != 0)
            {
                Console.Write("note: ");
                unitGroup.Specification.Note = Console.ReadLine();
            }
            if ((mode & T.Binary("0001")) != 0)
            {
                Console.Write("address: ");
                unitGroup.Specification.Address = Console.ReadLine();
            }

            engine.BLLChangeGroup(unitGroup);
        }

        private void PromptUnits(int group)
        {
            string[] units = null; // TODO
            Prompt(T.Concat(T.Enumerate(units).Select<(int i, string val), (string, Action)>(unit => (unit.val, () => PromptUnits(unit.i))), new (string, Action)[] { ("Show Group Details", () => PromptShowGroupDetails(group)), ("Create Unit", unimpl) }), "Your Units");
        }

        private void PromptUnit(int unit)
        {
            Prompt(new (string, Action)[] { ("Show Unit Details", () => PromptShowUnitDetails(unit)) }, "Unit Management");
        }

        public void PromptShowUnitDetails(int unitId)
        {
            unit = engine.BLLGetUnitByID(unitId);

            Console.WriteLine($"name: {unit.Name}");
            Console.WriteLine($"current capacity: {unit.CurrentCapacity}");
            Console.WriteLine($"max capacity: {unit.MaxCapacity}");
            Console.WriteLine($"type: {unit.UnitTypeId}");

            Prompt(new (string, Action)[] { ("Change Unit Details", unimpl), (("Delete Unit", PromptChangeUnitDetails)) }, "Unit Details");
        }

        public void PromptChangeUnitDetails()
        {
            Prompt(new (string, Action)[] { ("Name", () => PromptSetUnitDetails(T.Binary("1000"))), ("Current Capacity", () => PromptSetUnitDetails(T.Binary("0100"))), ("Max Capacity", () => PromptSetUnitDetails(T.Binary("0010"))), ("Type", () => PromptSetUnitDetails(T.Binary("0001"))), ("All", () => PromptSetUnitDetails(T.Binary("1111"))) }, "Change Unit Details");
        }

        public void PromptSetUnitDetails(int mode)
        {
            int capacity = 0;
            if ((mode & T.Binary("1000")) != 0)
            {
                Console.Write("name: ");
                unit.Name = Console.ReadLine();
            }
            if ((mode & T.Binary("0100")) != 0)
            {
                Console.Write("current capacity: ");
                if (int.TryParse(Console.ReadLine(), out capacity))
                {
                    unit.CurrentCapacity = capacity;
                }
                else
                {
                    Console.WriteLine("Capacity must be number");
                }
            }
            if ((mode & T.Binary("0010")) != 0)
            {
                Console.Write("max capacity: ");
                if (int.TryParse(Console.ReadLine(), out capacity))
                {
                    unit.MaxCapacity = capacity;
                }
                else
                {
                    Console.WriteLine("Capacity must be number");
                }
            }
            if ((mode & T.Binary("0001")) != 0)
            {
                Console.Write("type: ");
                if (int.TryParse(Console.ReadLine(), out capacity))
                {
                    unit.UnitTypeId = capacity;
                }
                else
                {
                    Console.WriteLine("Type must be number");
                }
            }

            engine.BLLChangeUnit(unit);
        }
        */
        private void PromptShowUserDetails(int userID)
        {
            void WriteDetails(User user)
            {
                Console.WriteLine($"name: {user.Username}");
                Console.WriteLine($"password: {user.Password}");
                Console.WriteLine($"email: {(user.Email.Length != 0 ? user.Email : "*not filled*")}");
                Console.WriteLine($"admin: {(user.IsAdmin ? "Yes" : "No")}");
            }

            User user = engine.GetUserByID(userID);

            Prompt(new (string, Action)[] { ("Change User Details", () => PromptChangeUserDetails(user)) }, () => WriteDetails(user));
        }
        
        private void PromptChangeUserDetails(User user)
        {
            Prompt(new (string, Action)[] { ("Name", () => PromptSetUserDetails(user, Utils.Binary("100"))), ("Password", () => PromptSetUserDetails(user, Utils.Binary("010"))), ("Email", () => PromptSetUserDetails(user, Utils.Binary("001"))), ("All", () => PromptSetUserDetails(user, Utils.Binary("111"))) }, "Details Change");
        }
        
        private void PromptSetUserDetails(User user, int mode)
        {
            if ((mode & Utils.Binary("100")) != 0)
            {
                Console.Write("New Userame: ");
                user.Username = Console.ReadLine();
            }
            if ((mode & Utils.Binary("010")) != 0)
            {
                Console.Write("New Password: ");
                user.Password = Console.ReadLine();
            }
            if ((mode & Utils.Binary("001")) != 0)
            {
                Console.Write("New Email: ");
                user.Email = Console.ReadLine();
            }

            engine.BLLChangeUser(user);
        }
    }
}

