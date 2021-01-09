using DAL;
using System;
using System.Linq;

namespace FrontendConsole
{
    class Program
    {
        static void Main()
        {
            // Spuštění aplikace
            //new ConsoleApp();
            ApartmentsDbContext con = new ApartmentsDbContext();
            Console.WriteLine(con.UnitTypes.First().Type);
        }
    }

    public class ConsoleApp
    {/*

        private readonly Engine engine = new Engine();
        private readonly Action unimpl = () => Console.WriteLine("Unimplemented");

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
            (string name, string password, string email) = (null, null, null);

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
            Prompt(new (string, Action)[] { ("List my groups", () => PromptGroups(userID)), ("Search", unimpl), ("Show User Details", () => PromptShowUserDetails(userID)) }, "Your Account");
        }
        
        private void PromptGroups(int userID)
        {
            (int id, string name)[] groupNames = engine.BLLListGroups(userID);
            Prompt(Utils.Concat(Utils.Enumerate(groupNames).Select<(int i, (int id, string val) cont), (string, Action)>(group => (group.cont.val, () => PromptUnits(group.cont.id))), new (string, Action)[] { ("CreateGroup", () => PromptCreateGroup(userID)) }), "Your Groups");
        }
        
        private void PromptShowGroupDetails(int groupID)
        {
            void WriteDetails(int groupID)
            {
                Specification spec = engine.BLLGetGroupByID(groupID).Specification;

                Console.WriteLine($"name: {spec.Name}");
                Console.WriteLine($"color: {spec.Color}");
                Console.WriteLine($"note: {spec.Note}");
                Console.WriteLine(ShortAddress(spec.Address));
            }

            Prompt(new (string, Action)[] { ("Change Group Details", () => PromptChangeGroupDetails(groupID)) }, () => WriteDetails(groupID));
        }

        private string ShortAddress(Address address)
        {
            return $"address: {address.Street} {address.Number}, {Utils.FirstOrDefault(address.City, "*city not filled*")}";
        }

        private void PrintAddress(int addressID)
        {
            Address address = engine.BLLGetAddressByID(addressID);

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
            Specification spec = engine.BLLGetGroupByID(groupID).Specification;

            if ((mode & Utils.Binary("1000")) != 0)
            {
                Console.Write("name: ");
                spec.Name = Console.ReadLine();
            }
            if ((mode & Utils.Binary("0100")) != 0)
            {
                (bool result, Color color) = ReadColor("color: ");
                if (result)
                {
                    spec.Color = color;
                }
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
            Prompt(new (string, Action)[] { ("State", () => PromptSetAddress(addressID, Utils.Binary("10000"))), ("City", () => PromptSetAddress(addressID, Utils.Binary("01000"))), ("Street", () => PromptSetAddress(addressID, Utils.Binary("00100"))), ("Number", () => PromptSetAddress(addressID, Utils.Binary("00010"))), ("Zip", () => PromptSetAddress(addressID, Utils.Binary("00001"))), ("All", () => PromptSetAddress(addressID, Utils.Binary("11111"))) }, () => PrintAddress(addressID));
        }

        private void PromptSetAddress(int addressID, int mode)
        {
            Address address = engine.BLLGetAddressByID(addressID);

            if ((mode & Utils.Binary("10000")) != 0)
            {
                Console.Write("State: ");
                address.State = Console.ReadLine();
            }
            if ((mode & Utils.Binary("01000")) != 0)
            {
                Console.Write("City: ");
                address.City = Console.ReadLine();
            }
            if ((mode & Utils.Binary("00100")) != 0)
            {
                Console.Write("Street: ");
                address.Street = Console.ReadLine();
            }
            if ((mode & Utils.Binary("00010")) != 0)
            {
                Console.Write("Number: ");
                address.Number = Console.ReadLine();
            }
            if ((mode & Utils.Binary("00001")) != 0)
            {
                Console.Write("Zip: ");
                address.Zip = Console.ReadLine();
            }

            engine.BLLChangeAddress(address);
        }

        private void PromptCreateGroup(int userID)
        {
            Prompt(new (string, Action)[] { ("Fast", () => PromptNewGroup(userID, false)), ("Advanced", () => PromptNewGroup(userID, true)) }, "Fast or advanced?");
        }

        private void PromptNewGroup(int userID, bool advanced)
        {
            (string name, Color color, string note) = ("", 0, "");
            (string state, string city, string street, string number, string zip) = ("", "", "", "", "");

            Console.Write("name: ");
            name = Console.ReadLine();

            if (advanced)
            {
                (bool result, Color colorInput) = ReadColor("color: ");
                if (result)
                {
                    color = colorInput;
                }
            }
            if (advanced)
            {
                Console.Write("note: ");
                note = Console.ReadLine();
            }
            if (advanced)
            {
                Console.Write("state: ");
                state = Console.ReadLine();
            }
            if (advanced)
            {
                Console.Write("city: ");
                city = Console.ReadLine();
            }
            Console.Write("street: ");
            street = Console.ReadLine();

            Console.Write("number: ");
            number = Console.ReadLine();
            if (advanced)
            {
                Console.Write("zip: ");
                zip = Console.ReadLine();
            }

            engine.BLLCreateGroup(name, color, note, userID, state, city, street, number, zip);
        }
        
        private void PromptUnits(int groupID)
        {
            (int, string)[] unitNames = engine.BLLListUnitsFromGroup(groupID);
            Prompt(Utils.Concat(Utils.Enumerate(unitNames).Select<(int i, (int id, string val) cont), (string, Action)>(unit => (unit.cont.val, () => PromptUnit(unit.cont.id))), new (string, Action)[] { ("Show Group Details", () => PromptShowGroupDetails(groupID)), ("Create Unit", () => PromptCreateUnit(groupID)) }), "Your Units");
        }
        
        private void PromptUnit(int unitID)
        {
            Prompt(new (string, Action)[] { ("Show Unit Details", () => PromptShowUnitDetails(unitID)) }, "Unit Management");
        }
        
        private void PromptShowUnitDetails(int unitId)
        {
            void WriteDetails(int unitID)
            {
                Unit unit = engine.BLLGetUnitByID(unitId);

                Console.WriteLine($"name: {unit.Specification.Name}");
                Console.WriteLine($"color: {unit.Specification.Color}");
                Console.WriteLine($"note: {unit.Specification.Note}");
                Console.WriteLine(ShortAddress(unit.Specification.Address));
                Console.WriteLine($"current capacity: {unit.CurrentCapacity}");
                Console.WriteLine($"max capacity: {unit.MaxCapacity}");
                Console.WriteLine($"type: {unit.Type.Type}");
            }

            Prompt(new (string, Action)[] { ("Change Unit Details", () => PromptChangeUnitDetails(unitId)) }, () => WriteDetails(unitId));
        }
        
        private void PromptChangeUnitDetails(int unitID)
        {
            int addressID = engine.BLLGetAddressIDByUnitID(unitID);
            Prompt(new (string, Action)[] { ("Name", () => PromptSetUnitDetails(unitID, Utils.Binary("100000"))), ("Color", () => PromptSetUnitDetails(unitID, Utils.Binary("010000"))), ("Note", () => PromptSetUnitDetails(unitID, Utils.Binary("001000"))), ("Address", () => PromptChangeAddress(addressID)), ("Current Capacity", () => PromptSetUnitDetails(unitID, Utils.Binary("000100"))), ("Max Capacity", () => PromptSetUnitDetails(unitID, Utils.Binary("000010"))), ("Type", () => PromptSetUnitDetails(unitID, Utils.Binary("000001"))), ("All", () => PromptSetUnitDetails(unitID, Utils.Binary("111111"))) }, "Change Unit Details");
        }


        private (bool, Color) ReadColor(string prompt)
        {
            Console.Write(prompt);
            if (Enum.TryParse(Console.ReadLine(), out Color color))
            {
                return (true, color);
            } else
            {
                Console.WriteLine("You have to submit valid color");
                return (false, 0);
            }
        }
        private (bool, int) ReadNumber(string prompt)
        {
            Console.Write(prompt);
            if (int.TryParse(Console.ReadLine(), out int capacity))
            {
                return (true, capacity);
            }
            else
            {
                Console.WriteLine("You have to insert number");
                return (false, -1);
            }
        }

        private int ReadNumberOrDefault(int def=-1)
        {
            int.TryParse(Console.ReadLine(), out def);
            return def;
        }
        private void PromptSetUnitDetails(int unitID, int mode)
        {
            Unit unit = engine.BLLGetUnitByID(unitID);
            Specification spec = unit.Specification;

            if ((mode & Utils.Binary("100000")) != 0)
            {
                Console.Write("name: ");
                spec.Name = Console.ReadLine();
            }
            if ((mode & Utils.Binary("010000")) != 0)
            {
                (bool result, Color color) = ReadColor("color: ");
                if (result)
                {
                    spec.Color = color;
                }
            }
            if ((mode & Utils.Binary("001000")) != 0)
            {
                Console.Write("note: ");
                spec.Note = Console.ReadLine();
            }
            if ((mode & Utils.Binary("000100")) != 0)
            {
                (bool result, int capacity) = ReadNumber("current capacity: ");
                if (result)
                {
                    unit.CurrentCapacity = capacity;
                }
            }
            if ((mode & Utils.Binary("000010")) != 0)
            {
                (bool result, int capacity) = ReadNumber("max capacity: ");
                if (result)
                {
                    unit.MaxCapacity = capacity;
                }
            }
            if ((mode & Utils.Binary("000001")) != 0)
            {
                (bool result, UnitType type) = ReadUnitType();
                if (result)
                {
                    unit.UnitTypeId = type.Id;
                    unit.Type = type;
                }
            }

            engine.BLLChangeUnit(unit);
            engine.BLLChangeSpecification(spec);
        }

        private (bool, UnitType) ReadUnitType()
        {
            Console.Write("type: ");
            string typeName = Console.ReadLine();
            (bool exists, UnitType type) = engine.BLLGetTypeByName(typeName);
            if (exists)
            {
                return (exists, type);
            }
            else
            {
                Console.WriteLine("Submitted type doesnt exist");
                return (false, null);
            }
        }

        private void PromptCreateUnit(int groupID)
        {
            Prompt(new (string, Action)[] { ("Fast", () => PromptNewUnit(groupID, false)), ("Advanced", () => PromptNewUnit(groupID, true)) }, "Fast or Advanced?");
        }

        private void PromptNewUnit(int groupID, bool advanced)
        {
            (int curCapacity, int maxCapacity, string name, Color color, string note, int typeID) = (0, 0, "", 0, "", 0);

            Console.Write("name: ");
            name = Console.ReadLine();

            if (advanced)
            {
                Console.Write("current capacity: ");
                curCapacity = ReadNumberOrDefault();
            }

            if (advanced)
            {
                Console.Write("max capacity: ");
                maxCapacity = ReadNumberOrDefault();
            }

            if (advanced)
            {
                (bool result1, Color colorRead) = ReadColor("color: ");
                if (result1)
                {
                    color = colorRead;
                }
            }
            if (advanced)
            {
                Console.Write("note: ");
                note = Console.ReadLine();
            }

            (bool result2, UnitType type) = ReadUnitType();
            if (result2)
            {
                typeID = type.Id;
            }

            engine.BLLCreateUnit(curCapacity, maxCapacity, name, color, note, typeID, groupID);
        }

        private void PromptShowUserDetails(int userID)
        {
            void WriteDetails(int userID)
            {
                User user = engine.GetUserByID(userID);

                Console.WriteLine($"name: {user.Username}");
                Console.WriteLine($"password: {user.Password}");
                Console.WriteLine($"email: {(user.Email.Length != 0 ? user.Email : "*not filled*")}");
                Console.WriteLine($"admin: {(user.IsAdmin ? "Yes" : "No")}");
            }

            Prompt(new (string, Action)[] { ("Change User Details", () => PromptChangeUserDetails(userID)) }, () => WriteDetails(userID));
        }
        
        private void PromptChangeUserDetails(int userID)
        {
            Prompt(new (string, Action)[] { ("Name", () => PromptSetUserDetails(userID, Utils.Binary("100"))), ("Password", () => PromptSetUserDetails(userID, Utils.Binary("010"))), ("Email", () => PromptSetUserDetails(userID, Utils.Binary("001"))), ("All", () => PromptSetUserDetails(userID, Utils.Binary("111"))) }, "Details Change");
        }
        
        private void PromptSetUserDetails(int userID, int mode)
        {
            User user = engine.GetUserByID(userID);

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
        }*/
    }
}


