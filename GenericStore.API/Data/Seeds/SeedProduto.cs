using GenericStore.API.Models;
using Microsoft.EntityFrameworkCore;

namespace GenericStore.API.Data.Seeds;

public  class SeedProduto
{
    public SeedProduto(ModelBuilder modelBuilder)
    {
        List<Produto> produtos = [
            new() { 
                Id = 1,
                Nome = "Memória RAM Corsair",
                CategoriaId = 1,
                Descricao = "Memória RAM Corsair DDR4 16GB (2x8GB) 3200MHz",
                ValorCusto = 350.00m,
                ValorVenda = 499.99m,
                Qtde = 15,
                Destaque = false,
                Foto = "/img/produtos/1.png"
            },
            new() { 
                Id = 2,
                Nome = "Memória RAM Kingston",
                CategoriaId = 1,
                Descricao = "Memória RAM Kingston DDR5 16GB (1x16GB) 3200MHz",
                ValorCusto = 499.99m,
                ValorVenda = 750.00m,
                Qtde = 45,
                Destaque = true,
                Foto = "/img/produtos/2.png"
            },
            new() { 
                Id = 3, 
                Nome = "Processador Intel Core i5-12400F",
                CategoriaId = 2,
                Descricao = "Processador Intel Core i5-12400F 12ª geração, 6 núcleos, 12 threads, clock base de 2.5GHz até 4.4GHz",
                ValorCusto = 800.00m,
                ValorVenda = 1200.00m,
                Qtde = 30,
                Destaque = false,
                Foto = "/img/produtos/3.png"
            },
            new() { 
                Id = 4, 
                Nome = "Processador AMD Ryzen 5 5600X",
                CategoriaId = 2,
                Descricao = "Processador AMD Ryzen 5 5600X 12ª geração, 6 núcleos, 12 threads, clock base de 3.7GHz até 4.5GHz",
                ValorCusto = 1200.00m,
                ValorVenda = 1800.00m,
                Qtde = 45,
                Destaque = true,
                Foto = "/img/produtos/4.png"
            },
            new() { 
                Id = 5, 
                Nome = "SSD NVMe M.2 500GB",
                CategoriaId = 3,
                Descricao = "SSD NVMe M.2 500GB",
                Qtde = 27,
                Destaque = true,
                Foto = "/img/produtos/5.png"

            },
            new() { 
                Id = 6, 
                Nome = "HD Western 1TB",
                CategoriaId = 3,
                Descricao = "HD Western 1TB Preto SATA 3.0",
                Qtde = 15,
                Destaque = false,
                Foto = "/img/produtos/6.png"
            },
            new() { 
                Id = 7, 
                Nome = "Cooler DeepCool Gammaxx 400",
                CategoriaId = 4,
                Descricao = "Cooler CPU DeepCool Gammaxx 400, 4 heatpipes, compatível com Intel e AMD",
                Qtde = 25,
                Destaque = false,
                Foto = "/img/produtos/7.png"

            },
            new() {
                Id = 8, 
                Nome = "Air Cooler DeepCool AS500 Plus",
                CategoriaId = 4,
                Descricao = "Air Cooler DeepCool AS500 Plus, 4 heatpipes, compatível com Intel e AMD",
                Qtde = 40,
                Destaque = true,
                Foto = "/img/produtos/8.png"  
            },
            new() { 
                Id = 9, 
                Nome = "Teclado Mecânico Redragon Kumara K552",
                CategoriaId = 5,
                Descricao = "Teclado Mecânico Redragon Kumara K552, Switch Outemu Blue, RGB, ABNT2",
                Qtde = 34,
                Destaque = false,
                Foto = "/img/produtos/9.png"
            },
            new() { 
                Id = 10, 
                Nome = "Teclado Magnético Redragon K585 DITI",
                CategoriaId = 5,
                Descricao = "Teclado Magnético Redragon K585 DITI, Switch Outemu Blue, RGB, ABNT2",
                Qtde = 40,
                Destaque = true,
                Foto = "/img/produtos/10.png"
            },
        ];

        modelBuilder.Entity<Produto>().HasData(produtos);
    }
}