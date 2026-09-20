using System.Xml;

public class Alumno
{
    public string Nombre { get; set; }
    public int Legajo { get; private set; }
    public double Nota1 { get; set; }
    public double Nota2 { get; set; }

    public Alumno(string nombre, int legajo, double Nota1, double Nota2)
    {
        Nombre = nombre;
        Legajo = legajo;
        Nota1 = Nota1;
        Nota2 = Nota2;
    }

    public bool CargarNotas(double nota1, double nota2)
    {
        if (nota1 >= 0 && nota1 <= 10 && nota2 >= 0 && nota2 <= 10)
        {
            Nota1 = nota1;
            Nota2 = nota2;
            return true;
        }
        return false;
    }
    public double Promedio()
    {
        return (Nota1 + Nota2) / 2.0;
    }

    public bool EstaAprobado()
    {
        return Promedio() >= 6.0;
    }
    public void SubirNota()
    {
        if (Nota1 + 1 <= 10)
        {
            Nota1 += 1;
        }
        else
        {
            Nota1 = 10;
        }

        if (Nota2 + 1 <= 10)
        {
            Nota2 += 1;
        }
        else
        {
            Nota2 = 10;
        }
    }

    public override string ToString()
    {
        return $"{Legajo} {Nombre} (promedio: {Promedio()}";
    }
}



Alumno alumno1 = new Alumno("ana", 1001, 8.5, 9.0);
Alumno alumno2 = new Alumno("juan", 1002, 6.0, 7.0);


Console.WriteLine($"Alumno 1: {alumno1.Nombre} - Legajo: {alumno1.Legajo}");
Console.WriteLine($"Alumno 2: {alumno1.Nombre} - Legajo: {alumno2.Legajo}");

alumno1.Nombre = "ana maria";

Console.WriteLine("\nDespués de modificar alumno1:");
Console.WriteLine($"Alumno 1: {alumno1.Nombre}");
Console.WriteLine($"Alumno 2: {alumno2.Nombre}");


Alumno alumno1 = new Alumno("Ana Pérez", 1234, 8.0, 6.0);
Alumno alumno2 = new Alumno("Juan López", 5678, 4.0, 5.0);

Console.WriteLine($"Promedio Ana: {alumno1.Promedio()} - ¿Aprobada?: {alumno1.EstaAprobado()}");
Console.WriteLine($"Promedio Juan: {alumno2.Promedio()} - ¿Aprobado?: {alumno2.EstaAprobado()}");

alumno2.SubirNota();
Console.WriteLine($"Juan tras subir nota -> Promedio: {alumno2.Promedio()} - ¿Aprobado?: {alumno2.EstaAprobado()}");

Alumno alumno = new Alumno("Ana pérez", 1234);

if (!alumno.CargarNotas(47.0, 8.0))
{
    Console.WriteLine("Aviso: Notas invalidas. No se registraron.");
}

if (alumno.CargarNotas(8.0, 6.0))
{
    Console.WriteLine($"Notas cargadas con exito: {alumno}");
}

List<Alumno> alumnos = new List<Alumno>();
bool salir = false;

while (!salir)
{
    Console.WriteLine("\n---MENÚ DE ALUMNOS---");
    Console.WriteLine("1. agregar un alumno");
    Console.WriteLine("2. lista de todos los alumnos");
    Console.WriteLine("3. buscar un alumno por su legajo");
    Console.WriteLine("4. mostrar el promedio general del curso");
    Console.WriteLine("5. mostra cuantos alumnos estan aprobados");
    Console.WriteLine("6. salir");
    Console.Write("opcion: ");
}

string opcion = Console.ReadLine();

switch (opcion)
{
    case "1":
        Console.Write("Nombre: ");
        string nombre = Console.ReadLine();

        Console.Write("Legajo: ");
        if (!int.TryParse(Console.ReadLine(), out int legajo))
        {
            Console.WriteLine("El legajo debe ser un numero entero. ");
            break;
        }

        Alumno nuevo = new Alumno(nombre, legajo);

        Console.Write("Nota 1: ");
        double.TryParse(Console.ReadLine(), out double n1);

        Console.Write("Nota 2: ");
        double.TryParse(Console.ReadLine(), out double n2);

        if (nuevo.CargarNotas(n1, n2))
        {
            alumno.Add(nuevo);
            Console.WriteLine("Alumno agregado correctamente.");

        }
        else
        {
            Console.WriteLine("error; las notas deben ser entre 0 y 10.");

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
        Console.Write("Ingrese legajo a buscar:");
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
        salir = true;
        Console.WriteLine("fin del programa.");
        break;

    default:
        Console.WriteLine("opcion no valida. Intente nuevamente.");
        break;

}

public class Persona
{
    public string Nombre { get; set; }
    public string Documento { get; set; }

    public Persona(string Nombre, string Documento)
    {
        Nombre = nombre;
        Documento = documento;
    }

    public virtual string Presentarse()
    {
        return $"Hola, soy {Nombre}.";
    }

    public override string Presentarse()
    {
        return $"Hola, soy {Nombre}, alumno con legajo {Legajo}.";
    }

    public override string Presentarse()
    {
        return $"Hola, soy {Nombre}, y dicto {Materia}.";
    }
}


public class Alumno : Persona
{
    public int Legajo { get; private set; }
    public double Nota1 { get; private set; }
    public double Nota2 { get; private set; }

    public Alumno(string nombre, string documento, int legajo) : base(nombre, documento)
    {
        Legajo = legajo;
    }

    public bool CargarNotas(double nota1, double nota2)
    {
        if (nota1 >= 0 && nota1 <= 10 && nota2 >= 0 && nota2 <= 10)
        {
            Nota1 = nota1;
            Nota2 = nota2;
            return true;
        }
        return false;
    }

    public double Promedio() => (Nota1 + Nota2) / 2.0;
    public bool EstaAprobado() => Promedio() >= 6.0;

    public override string ToString()
    {
        return $"{Legajo} {Nombre} (promedio: {Promedio()})";
    }
}

public class Profesor : Persona
{
    public string Materia { get; set; }

    public Profesor(string nombre, string documento, string materia) : base(nombre, documento)
    {
        Materia = materia;
    }
}

public class Preceptor : Persona
{
    public string turno { get; set; }

    public Preceptor(string nombre, string documento, string turno) : base(nombre, documento)
    {
        Turno = turno;
    }

    public override string Presentarse()
    {
        return $"Hola, soy {Nombre}, preceptor del turno {Turno}.";
    }
}

List<Persona> persona = new List<Persona>
{
    new Alumno("Ana Perez", "46652014", 1234),
    new Profesor("marta dias", "44849473", "Programacion"),
    new Preceptor("carla gomez", "22807866", "mañana")
};

foreach (Persona p in personas)
{
    Console.WriteLine(p.Presentarse());
}
