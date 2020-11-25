using System.Linq;
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
            // To speedup login
            new DAL.ApartmentsDbContext();

            // Viz logický DFA
            //PromptStart();

            PromptDefaultScreen(14);
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
            Prompt(new (string, Action)[] { ("List my flats", () => PromptGroups(userID)), ("Create new flat", unimpl), ("Search", unimpl), ("Show User Details", () => PromptShowUserDetails(userID)) }, "Your Account");
        }
        
        private void PromptGroups(int userID)
        {
            (int id, string name)[] groupNames = engine.BLLListGroups(userID);
            Prompt(Utils.Concat(Utils.Enumerate(groupNames).Select<(int i, (int id, string val) cont), (string, Action)>(group => (group.cont.val, () => PromptUnits(group.cont.id))), new (string, Action)[] { ("CreateGroup", unimpl) }), "Your Groups");
        }
        
        private void PromptShowGroupDetails(int groupID)
        {
            Specification spec = engine.BLLGetSPecificationByGroupID(groupID);

            Console.WriteLine($"name: {spec.Name}");
            Console.WriteLine($"color: {spec.Color}");
            Console.WriteLine($"note: {spec.Note}");
            PrintAddress(spec.Address);

            Prompt(new (string, Action)[] { ("Change Group Details", () => PromptChangeGroupDetails(groupID)) }, "Group Details");
        }

        private void PrintAddress(Address address)
        {
            Console.WriteLine($"state: {address.State}");
            Console.WriteLine($"city: {address.City}");
            Console.WriteLine($"street: {address.Street}");
            Console.WriteLine($"number: {address.Number}");
            Console.WriteLine($"zip: {address.Zip}");
        }
        
        private void PromptChangeGroupDetails(int groupID)
        {
            int addressID = engine.BLLGetAddressIDByGroupID(groupID);
            Prompt(new (string, Action)[] { ("Name", () => PromptSetGroupDetails(groupID, Utils.Binary("1000"))), ("Color", () => PromptSetGroupDetails(groupID, Utils.Binary("0100"))), ("Note", () => PromptSetGroupDetails(groupID, Utils.Binary("0010"))), ("Address", () => PromptChangeAddress(addressID)), ("All", () => PromptSetGroupDetails(groupID, Utils.Binary("1111"))) }, "Change Group Details");
        }
        
        private void PromptSetGroupDetails(int groupID, int mode)
        {
            Specification spec = engine.BLLGetSPecificationByGroupID(groupID);

            if ((mode & Utils.Binary("1000")) != 0)
            {
                Console.Write("name: ");
                spec.Name = Console.ReadLine();
            }
            if ((mode & Utils.Binary("0100")) != 0)
            {
                // TODO Color
            }
            if ((mode & Utils.Binary("0010")) != 0)
            {
                Console.Write("note: ");
                spec.Note = Console.ReadLine();
            }

            engine.BLLChangeSpecification(spec);
        }

        private void PromptChangeAddress(int addressID)
        {
            // TODO
        }

        private void PromptSetAddress(int addressID)
        {
            // TODO
        }
        
        private void PromptUnits(int groupID)
        {
            (int, string)[] unitNames = engine.BLLListUnitsFromGroup(groupID);
            Prompt(Utils.Concat(Utils.Enumerate(unitNames).Select<(int i, (int id, string val) cont), (string, Action)>(unit => (unit.cont.val, () => PromptUnits(unit.cont.id))), new (string, Action)[] { ("Show Group Details", () => PromptShowGroupDetails(groupID)), ("Create Unit", unimpl) }), "Your Units");
        }
        /*
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


