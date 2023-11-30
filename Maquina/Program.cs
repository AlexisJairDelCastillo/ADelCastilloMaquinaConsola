namespace Maquina
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Compras> compras = new List<Compras>();
            int cantidadCompras = 1;

            Console.WriteLine("Ingresa tu nombre: ");
            string nombre = Console.ReadLine();

            while (true)
            {
                

                Console.WriteLine();

                Console.WriteLine("Elige el producto (A, B, C): ");
                char producto = char.ToUpper(Console.ReadKey().KeyChar);

                Console.WriteLine();

                int precio = 0;

                switch (producto)
                {
                    case 'A':
                        precio = 270;
                        break;

                    case 'B':
                        precio = 340;
                        break;

                    case 'C':
                        precio = 390;
                        break;

                    default:
                        Console.WriteLine("El producto no existe. Elige nuevamente un producto.");
                        continue;
                }

                Console.WriteLine();

                Console.WriteLine("Ingresa las monedas: ");

                int montoIngresado = 0;

                while (montoIngresado < precio)
                {
                    if (int.TryParse(Console.ReadLine(), out int moneda))
                    {
                        if (moneda == 10 || moneda == 50 || moneda == 100)
                        {
                            montoIngresado += moneda;
                        }
                        else
                        {
                            Console.WriteLine("La maquina no acepta esa moneda. Intenta con otra moneda.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("La maquina no acepta esa moneda. Ingresa solo monedas validas.");
                    }
                }

                Console.WriteLine();

                int cambio = montoIngresado - precio;

                Console.WriteLine("Su cambio es: ");

                int[] maquina = { 100, 50, 10 };

                foreach (int cambioMaquina in maquina)
                {
                    while (cambio >= cambioMaquina)
                    {
                        Console.WriteLine(cambioMaquina);
                        cambio -= cambioMaquina;
                    }
                }

                Console.WriteLine();

                compras.Add(new Compras(nombre, producto, montoIngresado, precio, cambio));
                Console.WriteLine($"Compra #{cantidadCompras} finalizada.");
                Console.WriteLine("¿Deseas realizar otra compra? S/N");

                if (char.ToUpper(Console.ReadKey().KeyChar) != 'S')
                {
                    break;
                }

                cantidadCompras++;

                Console.WriteLine();
            }

            Console.WriteLine();

            Console.WriteLine("-----Resumen de Compras-----");

            foreach (Compras compra in compras)
            {
                Console.WriteLine(compra.ToString());
            }

            Console.ReadKey();
        }

        public class Compras
        {
            public string Nombre { get; set; }

            public char Producto { get; set; }

            public int MontoIngresado { get; set; }

            public int Precio { get; set; }

            public int Cambio { get; set; }

            public Compras(string nombre, char producto, int montoIngresado, int precio, int cambio)
            {
                Nombre = nombre;
                Producto = producto;
                MontoIngresado = montoIngresado;
                Precio = precio;
                Cambio = cambio;
            }

            public string ToString()
            {
                return $"Cliente: {Nombre}, Producto: {Producto}, Monto Ingresado: {MontoIngresado}, Precio: {Precio}, Cambio: {Cambio}";
            }
        }
    }
}