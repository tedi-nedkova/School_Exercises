using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversitySystem.Controllers;
using UniversitySystem.Data;

namespace UniversitySystem.Presentation
{
    public class Display
    {
        private readonly UniversityDbContext context = new UniversityDbContext();

        private FacultyController facultyController;

        private MajorController majorController;

        private UniversityController universityController;

        public Display()
        {
            facultyController = new FacultyController(context);  
            majorController = new MajorController(context);
            universityController = new UniversityController(context);
        }

        public void ShowMenu()
        {
            Console.WriteLine("1. Add university");
            Console.WriteLine("2. Add faculty");
            Console.WriteLine("3. Add major");
            Console.WriteLine("4. Show all universities");
            Console.WriteLine("5. Show faculties by university ID");
            Console.WriteLine("6. Show majors by faculty ID");
            Console.WriteLine("7. Show university ID by name");
            Console.WriteLine("8. Show faculty ID and name by name");
            Console.WriteLine("9. Show major ID and name by name");
            Console.WriteLine("10. Exit");

            string command = Console.ReadLine();
            while (command != "10")
            {
                switch (command)
                {
                    case "1":
                        InputUniversity();
                        break;

                    case "2":
                        InputFaculty();
                        break;

                    case "3":
                        InputMajor();
                        break;

                    case "4":
                        GetAllUniversities();
                        break;

                    case "5":
                        GetFacultiesByUniversityId();
                        break;

                    case "6":
                        GetMajorsByFacultyId();
                        break;

                    case "7":
                        GetUniversityIdByName();
                        break;

                    case "8":
                        GetFacultyIdAndNameByName();
                        break;

                    case "9":
                        GetMajorIdAndNameByName();
                        break;

                    default:
                        break;
                }
                command = Console.ReadLine();
            }
        }

        public void InputUniversity()
        {
            Console.Write("Enter university name: ");
            string name = Console.ReadLine();

            universityController.AddUniversity(name);
        }

        public void InputFaculty()
        {
            Console.Write("Enter faculty name: ");
            string name = Console.ReadLine();

            Console.Write("Enter university ID: ");
            int universityId = int.Parse(Console.ReadLine());

            facultyController.AddFaculty(name, universityId);
        }

        public void InputMajor()
        {
            Console.Write("Enter major name: ");
            string name = Console.ReadLine();

            Console.Write("Enter faculty ID: ");
            int facultyId = int.Parse(Console.ReadLine());

            majorController.AddMajor(name, facultyId);
        }

        public void GetAllUniversities()
        {
            foreach (var university in universityController.GetAllUniversities())
            {
                Console.WriteLine($"{university.Id} - {university.Name}");
            }
        }

        public void GetFacultiesByUniversityId()
        {
            Console.Write("Enter university ID: ");
            int id = int.Parse(Console.ReadLine());

            foreach (var faculty in facultyController.GetFacultiesByUniversityId(id))
            {
                Console.WriteLine($"{faculty.Id} - {faculty.Name}");
            }
        }

        public void GetMajorsByFacultyId()
        {
            Console.Write("Enter faculty ID: ");
            int id = int.Parse(Console.ReadLine());

            foreach (var major in majorController.GetMajorsByFacultyId(id))
            {
                Console.WriteLine($"{major.Id}: {major.Name}");
            }
        }

        public void GetUniversityIdByName()
        {
            Console.Write("Enter university name: ");
            string name = Console.ReadLine();

            var id = universityController.GetUniversityIdByName(name);
            if (id != null)
            {
                Console.WriteLine($"ID: {id}");
            }
            else
            {
                Console.WriteLine("No ID");
            }
        }

        public void GetFacultyIdAndNameByName()
        {
            Console.Write("Enter faculty name: ");
            string name = Console.ReadLine();

            var faculties = facultyController.GetFacultiesByName(name);

            foreach (var faculty in faculties)
            {
                Console.WriteLine($"ID: {faculty.Id} - Name: {faculty.Name}");
            }
        }

        public void GetMajorIdAndNameByName()
        {
            Console.Write("Enter major name: ");
            string name = Console.ReadLine();

            var majors = majorController.GetMajorsByName(name);

            foreach (var major in majors)
            {
                Console.WriteLine($"ID: {major.Id} - Name: {major.Name}");
            }
        }
    }
}
