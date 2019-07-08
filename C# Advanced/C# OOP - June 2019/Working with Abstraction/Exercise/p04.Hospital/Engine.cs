namespace p04.Hospital
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Engine
    {
        private Dictionary<string, List<string>> doctors;
        private Dictionary<string, List<List<string>>> departments;

        public Engine()
        {
            this.doctors = new Dictionary<string, List<string>>();
            this.departments = new Dictionary<string, List<List<string>>>();
        }
        public void Run()
        {
            string command = Console.ReadLine();

            while (command != "Output")
            {
                string[] inputArgs = command.Split();

                var department = inputArgs[0];
                var firstName = inputArgs[1];
                var middleName = inputArgs[2];
                var patient = inputArgs[3];

                var fullName = firstName + middleName;

                AddDoctor(fullName);
                AddDepartment(department);

                bool isFree = departments[department]
                                  .SelectMany(x => x)
                                  .Count() < 60;

                if (isFree)
                {
                    AddPatientToRoom(fullName, patient, department);
                }

                command = Console.ReadLine();
            }

            command = Console.ReadLine();

            while (command != "End")
            {
                string[] args = command.Split();

                if (args.Length == 1)
                {
                    string departmentName = args[0];

                    PrintPatientsInDepartment(departmentName);
                }
                else if (args.Length == 2)
                {
                    bool isRoom = int.TryParse(args[1], out int room);

                    if (isRoom)
                    {
                        string departmentName = args[0];

                        PrintPatientsInRoom(departmentName, room);
                    }
                    else
                    {
                        string fullName = args[0] + args[1];

                        PrintAllDoctors(fullName);
                    }
                }

                command = Console.ReadLine();
            }
        }

        private void PrintAllDoctors(string fullName)
        {
            var allPatientsOfDoctor = doctors[fullName]
                .OrderBy(x => x)
                .ToArray();

            Console.WriteLine(string.Join(Environment.NewLine, allPatientsOfDoctor));
        }

        private void PrintPatientsInRoom(string departmentName, int room)
        {
            var allPatientInRoom = departments[departmentName][room - 1]
                .OrderBy(x => x)
                .ToArray();

            Console.WriteLine(string.Join(Environment.NewLine, allPatientInRoom));
        }

        private void PrintPatientsInDepartment(string departmentName)
        {
            var allPatientsInDepartment = departments[departmentName]
                .Where(x => x.Count > 0)
                .SelectMany(x => x)
                .ToArray();

            Console.WriteLine(string.Join(Environment.NewLine, allPatientsInDepartment));
        }

        private void AddPatientToRoom(string fullName, string patient, string department)
        {
            int room = 0;

            doctors[fullName].Add(patient);

            for (int currentRoom = 0; currentRoom < departments[department].Count; currentRoom++)
            {
                if (departments[department][currentRoom].Count < 3)
                {
                    room = currentRoom;
                    break;
                }
            }

            departments[department][room].Add(patient);
        }

        private void AddDepartment(string department)
        {
            if (!departments.ContainsKey(department))
            {
                departments[department] = new List<List<string>>();

                for (int rooms = 0; rooms < 20; rooms++)
                {
                    departments[department].Add(new List<string>());
                }
            }
        }

        private void AddDoctor(string fullName)
        {
            if (!doctors.ContainsKey(fullName))
            {
                doctors[fullName] = new List<string>();
            }
        }
    }
}