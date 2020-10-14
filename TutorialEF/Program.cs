using System;
using System.Collections.Generic;
using System.Linq;
using TutorialEF.DAL;
using TutorialEF.Entidades;

namespace TutorialEF
{
    class Program
    {
        static void Main(string[] args)
        {

            // Agregar
            using (var context = new Contexto())
            {
                var insertar = new Student()
                {
                    FirstName = "Wilbert Smith",
                    LastName = "Antigua Castillo",
                    Address = "Villa Riva",


                };

                context.students.Add(insertar);
                context.SaveChanges();
            }

            //Actualizar
            using (var context = new Contexto())
            {
                var actualizar = context.students.First<Student>();
                actualizar.FirstName = "Antigua";
                context.SaveChanges();
            }

            //Eliminar
            using (var context = new Contexto())
            {
                var eliminar = context.students.First<Student>();
                context.students.Remove(eliminar);

                context.SaveChanges();
            }


            //Consultar los datos
            var context_C = new Contexto();
            var studentsWithSameName = context_C.students
                                              .Where(s => s.FirstName == GetName())
                                              .ToList();

            var guardar = new Student() { FirstName = "Bill" };

            using (var context = new Contexto())
            {
                context.Add<Student>(guardar);
                context.SaveChanges();
            }

            var stdAddress = new Address()
            {
                City = "SFO",
                State = "CA",
                Country = "USA"

            };

            var std = new Student()
            {
                FirstName = "Julio",
                Address = Convert.ToString(stdAddress),

            };


            using (var contex = new Contexto())
            {
                contex.Add<Student>(std);
                contex.SaveChanges();
            }

            var insertar_dbset = new Student()
            {
                FirstName = "Bill"
            };

            using (var context = new Contexto())
            {
                context.students.Add(insertar_dbset);
                context.SaveChanges();
            }

            //Actualizacion

            var stud = new Student() { StudentId = 1, FirstName = "Bill" };

            stud.FirstName = "Steve";

            using (var context = new Contexto())
            {
                context.Update<Student>(stud);


                context.SaveChanges();
            }


            //Actualizar entidades
            var modifiedStudent1 = new Student()
            {
                StudentId = 1,
                FirstName = "Bill"
            };

            var modifiedStudent2 = new Student()
            {
                StudentId = 3,
                FirstName = "Steve"
            };

            var modifiedStudent3 = new Student()
            {
                StudentId = 3,
                FirstName = "James"
            };

            IList<Student> modifiedStudents = new List<Student>()
            {
                modifiedStudent1,
                modifiedStudent2,
                modifiedStudent3
            };

            using (var context = new Contexto())
            {
                context.UpdateRange(modifiedStudents);


                context.SaveChanges();
            }

            var student = new Student()
            {
                StudentId = 1
            };

            using (var context = new Contexto())
            {
                context.Remove<Student>(student);

                context.SaveChanges();
            }

            //Eliminar Registros
            IList<Student> students = new List<Student>() {
               new Student(){ StudentId = 1 },
               new Student(){ StudentId = 2 },
               new Student(){ StudentId = 3 },

             };

            using (var context = new Contexto())
            {
                context.RemoveRange(students);

                context.SaveChanges();
            }
                        
        }

        public static string GetName()
        {
            return "Wilbert Smith";

        }
    }
}