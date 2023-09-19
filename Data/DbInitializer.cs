using MVC_ComponenteCodeFirst.Models;

namespace MVC_ComponenteCodeFirst.Data
{
    public static class DbInitializer
    {
        public static void Initialize(TiendaContext context)
        {
            if (context.Componentes.Any()&&context.Ordenadores.Any()) 
                return;

            var ordenadores = new Ordenador[]
            {
                new Ordenador{Id = 1,Precio = 480, Name = "Ordenador 1"},
                new Ordenador{Id = 2,Precio = 370, Name = "Ordenador 2"},
                new Ordenador{Id = 3,Name = "Ordenador 3"},
                new Ordenador{Id = 4,Name = "Ordenador 4"},
            };

            var componentes = new Componente[]
            {
                new Componente {Serie = "567-KKK", Calor = 20, TipoComponente = 0, Descripcion="Procesador intel i7", Cores = 13, Almacenamiento = 0, Precio = 150, OrdenadorId=1},
                new Componente {Serie = "587-KOO", Calor = 24, TipoComponente = 0, Descripcion="Procesador intel i5",Cores = 12, Almacenamiento = 0, Precio = 250, OrdenadorId = 2},
                new Componente {Serie = "569-JKL", Calor = 28, TipoComponente = 0, Descripcion="Procesador AMD Ryzen ",Cores = 16, Almacenamiento = 0, Precio = 50},
                new Componente {Serie = "564-KKK", Calor = 12, TipoComponente = 0,Descripcion="Procesador AMD Ryzen 23", Cores = 18, Almacenamiento = 0, Precio = 150},
                new Componente {Serie = "5345-KKK", Calor = 23, TipoComponente = 1, Descripcion="Disco Duro SanDisk", Cores = 0, Almacenamiento = 500, Precio = 250, OrdenadorId = 1},
                new Componente {Serie = "598-PYK", Calor = 10, TipoComponente = 1, Descripcion="Disco Duro Myzen", Cores = 0, Almacenamiento = 500000, Precio = 50, OrdenadorId = 2},
                new Componente {Serie = "567-PUK", Calor = 20, TipoComponente = 1, Descripcion="Disco Duro SanDisk 9", Cores = 0, Almacenamiento = 12000, Precio = 150},
                new Componente {Serie = "545-BSR", Calor = 19, TipoComponente = 1, Descripcion="Disco Mecanico ", Cores = 0, Almacenamiento = 1485, Precio = 250},
                new Componente {Serie = "999-KKJD", Calor = 14, TipoComponente = 2, Descripcion="Memorizador SDRAM", Cores = 0, Almacenamiento = 6000, Precio = 80, OrdenadorId = 1},
                new Componente {Serie = "309-LCD", Calor = 12, TipoComponente = 2,Descripcion="Memorizador SDRAM 19", Cores = 0, Almacenamiento = 7000, Precio = 70, OrdenadorId = 2},
                new Componente {Serie = "787-MXF", Calor = 23, TipoComponente = 2, Descripcion="Memoria DDR", Cores = 0, Almacenamiento = 7500, Precio = 40},
                new Componente {Serie = "456-KCD", Calor = 14, TipoComponente = 2, Descripcion="Memoria SDR3",Cores = 0, Almacenamiento = 400, Precio = 60},

            };

            context.AddRange(ordenadores);
            context.AddRange(componentes);
            context.SaveChanges();
        }
    }
}
