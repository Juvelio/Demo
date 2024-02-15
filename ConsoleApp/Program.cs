
//// Declaración e inicialización de variables de diferentes tipos de datos
//string nombre = "Juan";
//int edad = 25;
//double altura = 1.75;
//bool esEstudiante = true;


//Console.WriteLine("Nombre: " + nombre + "edad :" + Convert.ToInt32(edad) + "altura" + altura);
//Console.WriteLine($"Edad : {edad} - altura : {altura} - esEstudiante: {esEstudiante}");


////lista de numeros
//List<int> numeros = new List<int>() { 1, 2, 3, 4, 5 };

//foreach (var item in numeros)
//{
//    Console.WriteLine(item);
//}


////lista de string
//List<string> frutas = new List<string>() { "manzana", "banana", "naranja" };
//foreach (var futa in frutas)
//{
//    Console.WriteLine(futa);
//}


//////lista de string
//List<Persona> personas = new List<Persona>() {

//    new Persona {Nombre="Juan", Edad=30 },
//    new Persona { Nombre = "Maria", Edad = 25 },
//    new Persona {Nombre = "Pedro", Edad=40}
//};

//foreach (var persona in personas)
//{
//    Console.WriteLine($"Nombre : {persona.Nombre}, Edad : {persona.Edad}");
//}


//LINQ


//// Ejemplo de consulta LINQ sobre una lista de strings
//List<string> nombres = new List<string> { "Juan", "María", "Pedro", "Ana", "Luisa", "Adriel" };

//var nombresConA = from nombre in nombres
//                  where nombre.StartsWith("A")
//                  select nombre;

//foreach (var nombre in nombresConA)
//{
//    Console.WriteLine(nombre);





//// Ejemplo de consulta LINQ sobre una lista de enteros
//List<int> numeros = new List<int> { 1, 5, 9, 2, 7, 3, 8 };
//var numerosPares = from numero in numeros
//                   where numero == 5
//                   select numero;
//Console.WriteLine("Números pares:");
//foreach (var numero in numerosPares)
//{
//    Console.WriteLine(numero);
//}



////Ejemplo de consulta LINQ sobre un array de objetos anónimos
//var personas = new List<Persona>();

//personas.Add(new Persona { Nombre = "Juan", Edad = 25 });
//personas.Add(new Persona { Nombre = "Maria", Edad = 30 });
//personas.Add(new Persona { Nombre = "Pedro", Edad = 35 });
//personas.Add(new Persona { Nombre = "Ana", Edad = 28 });
//personas.Add(new Persona { Nombre = "Luisa", Edad = 40 });

//var personasMenoresDe30 = from persona in personas
//                          where persona.Edad < 30
//                          select persona;

//Console.WriteLine("Personas menores de 30 años:");
//foreach (var persona in personasMenoresDe30)
//{
//    Console.WriteLine($"Nombre: {persona.Nombre}, Edad: {persona.Edad}");
//}



// Esperar hasta que el usuario presione una tecla para salir
Console.ReadKey();



class Persona
{
    public string Nombre { get; set; }
    public int Edad { get; set; }
}
