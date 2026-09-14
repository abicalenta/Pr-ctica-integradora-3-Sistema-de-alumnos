public class Alumno
{
    public string Nombre { get; set; }
    public int Legajo { get; set; }
    public double Nota1 { get; set; }
    public double Nota2 { get; set; }
}

Alumno alumno1 = new Alumno();
alumno1.Nombre = "Ana";
alumno1.Legajo = 1001;
alumno1.Nota1 = 8.5;
alumno1.Nota2 = 9.0;

Alumno alumno2 = new Alumno();
alumno2.Nombre = "juan";
alumno2.Legajo = 1002;
alumno2.Nota1 = 6.0;
alumno2.Nota2 = 7.0;

Console.WriteLine($"Alumno 1: {alumno1.Nombre} - Legajo: {alumno1.Legajo}");
Console.WriteLine($"Alumno 2: {alumno1.Nombre} - Legajo: {alumno2.Legajo}");

alumno1.Nombre = "ana maria";

Console.WriteLine("\nDespués de modificar alumno1:");
Console.WriteLine($"Alumno 1: {alumno1.Nombre}");
Console.WriteLine($"Alumno 2: {alumno2.Nombre}");

Console.ReadLine();
