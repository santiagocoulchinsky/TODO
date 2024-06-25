using Microsoft.EntityFrameworkCore;
using TODO.Entidades;
using TODO.Repositorio;


namespace TODO.Vistas
{
    public class Menu
    {
        public void MostrarMenu()
        {
            var repo = new RepositorioGenerico<Tarea>();
            //var repo2 = new RepositorioGenerico<Asigna>();
            var repo3 = new RepositorioGenerico<Operario>();

            int opcion;
            Console.WriteLine("1- Crear Tarea. ");
            Console.WriteLine("2- Crear Operario. ");
            Console.WriteLine("3- Asignar tareas. ");
            Console.WriteLine("4- Eliminar Tarea. ");
            Console.WriteLine("5- Marcar Tarea. ");
            Console.WriteLine("6- Desmarcar Tarea. ");
            Console.WriteLine("7- Ver Tareas. ");
            Console.WriteLine("8- Salir. ");
            Console.Write("\nOpción: ");
            opcion = int.Parse(Console.ReadLine());
            Console.WriteLine("-----------------");

            switch (opcion)
            {
                case 1:
                    Console.Write("Titulo: ");
                    string title = Console.ReadLine();
                    Console.Write("Descripción: ");
                    string desc = Console.ReadLine();
                    Console.WriteLine();
                    
                    var tarea = new Tarea() {Title = title, Description = desc};
                    repo.Crear(tarea);  

                    break;

                case 2:
                    Console.Write("Nombre: ");
                    string nombre = Console.ReadLine();
                    Console.WriteLine();

                    var operario = new Operario() { Nombre = nombre };
                    repo3.Crear(operario);

                    break;

                case 3:
                    Console.Write("Tarea nro: ");
                    int i = int.Parse(Console.ReadLine());
                    Console.Write("Se asigna a: ");
                    int j = int.Parse(Console.ReadLine());
                    Console.WriteLine();
                    using (var context = new AppDbContext())
                    {
                        var tar = context.Tareas
                            .Where(x => x.Id == i)
                            //.Include(x => x.Operarios)
                            .Single();
                        Asigna asigna = new Asigna(); 
                        asigna.OperarioId = j;
                        tar.Operarios.Add(asigna);

                        context.SaveChanges();
                    }
                       
                    break;

                case 4:
                    Console.Write("Tarea Nro: ");
                    int id = int.Parse(Console.ReadLine());
                    var del = repo.Obtener(id);
                    repo.Eliminar(del);
                    break;

                case 5:
                    Console.Write("Tarea Nro: ");
                    int k = int.Parse(Console.ReadLine());
                    var marca = repo.Obtener(k);
                    marca.Fin();
                    repo.Actualizar(marca);
                    Console.WriteLine();
                    break;

                case 6:
                    Console.Write("Tarea Nro: ");
                    int h = int.Parse(Console.ReadLine());
                    var desmarca = repo.Obtener(h);
                    desmarca.Desmarcar();
                    repo.Actualizar(desmarca);
                    Console.WriteLine();
                    break;

                case 7:
                    var lista = repo.VerTodos();
                    //var asign = repo2.VerTodos();
                    foreach (var item in lista)
                    {
                        if (item.Estado == Enumeraciones.EstadoTarea.Pendiente)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"Tarea: {item.Title}\nDescripción: {item.Description}\nId: {item.Id}");
                            //foreach (var item2 in asign)
                            //{

                            //}
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine("-----------------");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"Tarea: {item.Title}\nDescripción: {item.Description}\nId: {item.Id}");
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine("-----------------");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                    }
                    break;

                case 8:
                    Environment.Exit(0);
                    break;
            }
            MostrarMenu();
        }
    }
}
