using EntityFrameworkConsola.Modelo;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkConsola
{
    internal class Program
    {
        /* Usando EF 
         * 1. Agrego los paquetes:
         *  - EntityFrameworkCore.SQLServer
         *  - EntityFrameworkCoreTools
         * 
         * 2. Creo una carpeta para mis modelos (Models, Modelo, etc). Acá van a ir las clases mapeadas de la base de datos.
         * 
         * 3. Por consola genero la conexión a la base de datos:
         * Scaffold-DbContext "Server=ENZO\SQLEXPRESS; Database=BDTiendaDigital; Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Modelo
         *
         * 4. Se genera una clase "Context" que vamos a utilizar como contexto (conexión a nuestra base de datos)
         * 
         * 5. Instancio un nuevo contexto de mi Context class generada a partír de EF
         * 
         * 6. Recorro los productos y utilizo el método ToList de LINQ para poder mostrarlos
         * 
         * 7. La base de datos cambió? Idem al punto 3:
         * Scaffold-DbContext "Server=ENZO\SQLEXPRESS; Database=BDTiendaDigital; Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Modelo -force
         * 
         * 
         */
        static void Main(string[] args)
        {
            using (var context = new BDTiendaDigitalContext())
            {
                //Traigo los productos de la base de datos
                foreach (var item in context.Productos.ToList())
                {
                    Console.WriteLine(item.Descripcion);
                }

                Console.WriteLine("------------------");

                //Creo un nuevo producto
                var p = new Producto();
                p.Descripcion = "Silla222";
                context.Productos.Add(p);
                context.SaveChanges();

                foreach (var item in context.Productos.ToList())
                {
                    Console.WriteLine(item.Descripcion);
                }

                Console.WriteLine("------------------");

                //Modifico un producto
                //var product = context.Productos.Find(1); //Busco por Id
                //product.Descripcion = "Moxila";
                //context.Entry(product).State = EntityState.Modified;
                //context.SaveChanges();

                //foreach (var item in context.Productos.ToList())
                //{
                //    Console.WriteLine(item.Descripcion);
                //}

                //Console.WriteLine("------------------");

                //Elimino un producto
                //var productDeleted = context.Productos.Find(1);
                //context.Remove(productDeleted);
                //context.SaveChanges();

                //foreach (var item in context.Productos.ToList())
                //{
                //    Console.WriteLine(item.Descripcion);
                //}

                //Console.WriteLine("------------------");
            }
        }
    }
}