List<Alumno> alumnos = new List<Alumno>();
bool salir = false;

while (!salir)
{
    Console.WriteLine("\n--- MENÚ DE ALUMNOS ---");
    Console.WriteLine("1. Agregar un alumno");
    Console.WriteLine("2. Listar todos los alumnos");
    Console.WriteLine("3. Buscar un alumno por su legajo");
    Console.WriteLine("4. Mostrar el promedio general del curso");
    Console.WriteLine("5. Mostrar cuántos alumnos están aprobados");
    Console.WriteLine("6. Probar Polimorfismo e Interfaces (Etapas 8 y 9)");
    Console.WriteLine("7. Salir");
    Console.Write("Opción: ");

    string opcion = Console.ReadLine();

    switch (opcion)
    {
        case "1":
            Console.Write("Nombre: ");
            string nombre = Console.ReadLine();

            Console.Write("Documento: ");
            string documento = Console.ReadLine();

            Console.Write("Legajo: ");
            if (!int.TryParse(Console.ReadLine(), out int legajo))
            {
                Console.WriteLine("El legajo debe ser un número entero.");
                break;
            }

            Alumno nuevo = new Alumno(nombre, documento, legajo);

            Console.Write("Nota 1: ");
            double.TryParse(Console.ReadLine(), out double n1);

            Console.Write("Nota 2: ");
            double.TryParse(Console.ReadLine(), out double n2);

            if (nuevo.CargarNotas(n1, n2))
            {
                alumnos.Add(nuevo);
                Console.WriteLine("Alumno agregado correctamente.");
            }
            else
            {
                Console.WriteLine("Error: Las notas deben ser entre 0 y 10. No se guardó.");
            }
            break;

        case "2":
            if (alumnos.Count == 0)
            {
                Console.WriteLine("No hay alumnos registrados.");
            }
            else
            {
                Console.WriteLine("\nListado:");
                foreach (Alumno a in alumnos)
                {
                    Console.WriteLine(a);
                }
            }
            break;

        case "3":
            Console.Write("Ingrese legajo a buscar: ");
            if (int.TryParse(Console.ReadLine(), out int legBuscando))
            {
                Alumno encontrado = null;
                foreach (Alumno a in alumnos)
                {
                    if (a.Legajo == legBuscando)
                    {
                        encontrado = a;
                        break;
                    }
                }

                if (encontrado != null)
                {
                    Console.WriteLine($"Encontrado: {encontrado}");
                }
                else
                {
                    Console.WriteLine("El legajo no existe.");
                }
            }
            else
            {
                Console.WriteLine("Formato de legajo incorrecto.");
            }
            break;

        case "4":
            if (alumnos.Count == 0)
            {
                Console.WriteLine("Promedio no disponible: aún no hay alumnos cargados.");
            }
            else
            {
                double sumaTotal = 0;
                foreach (Alumno a in alumnos)
                {
                    sumaTotal += a.Promedio();
                }
                double promedioGral = sumaTotal / alumnos.Count;
                Console.WriteLine($"Promedio general del curso: {promedioGral:F2}");
            }
            break;

        case "5":
            int aprobados = 0;
            foreach (Alumno a in alumnos)
            {
                if (a.EstaAprobado())
                {
                    aprobados++;
                }
            }
            Console.WriteLine($"Cantidad de alumnos aprobados: {aprobados}");
            break;

        case "6":
            // Prueba de Polimorfismo (Etapa 8)
            Console.WriteLine("\n--- Prueba de Polimorfismo ---");
            List<Persona> listaPersonas = new List<Persona>
            {
                new Alumno("Ana Pérez", "46652014", 1234),
                new Profesor("Marta Díaz", "44849473", "Programación"),
                new Preceptor("Carla Gómez", "22807866", "Mañana")
            };

            foreach (Persona p in listaPersonas)
            {
                Console.WriteLine(p.Presentarse());
            }

            // Prueba de Interfaces (Etapa 9)
            Console.WriteLine("\n--- Prueba de Interfaces (IExportable) ---");
            Alumno alumExport = new Alumno("Ana Pérez", "46652014", 1234);
            alumExport.CargarNotas(7.0, 7.0);

            List<IExportable> exportables = new List<IExportable>
            {
                alumExport,
                new Profesor("Marta Díaz", "44849473", "Programación"),
                new Materia("PROG1", "Programación I", 128)
            };

            foreach (IExportable item in exportables)
            {
                Console.WriteLine(item.ExportarLinea());
            }
            break;

        case "7":
            salir = true;
            Console.WriteLine("Fin del programa.");
            break;

        default:
            Console.WriteLine("Opción no válida. Intente nuevamente.");
            break;
    }
}