using System.Xml;

public class Alumno
{
    public string Nombre { get; set; }
    public int Legajo { get; set; }
    public double Nota1 { get; set; }
    public double Nota2 { get; set; }

    public Alumno(string nombre, int legajo, double Nota1, double Nota2)
    {
        Nombre = nombre;
        Legajo = legajo;
        Nota1 = Nota1;
        Nota2 = Nota2;
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

