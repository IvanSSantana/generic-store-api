using GenericStore.API.Models;
using Microsoft.EntityFrameworkCore;

namespace GenericStore.API.Data.Seeds;

public class SeedCategoria
{
    public SeedCategoria(ModelBuilder modelBuilder)
    {
        List<Categoria> categorias = [
            new() { Id = 1, Nome = "Memórias RAM" },
            new() { Id = 2, Nome = "Processadores" },
            new() { Id = 3, Nome = "HDs e SSDs" },
            new() { Id = 4, Nome = "Coolers" },
            new() { Id = 5, Nome = "Periféricos" },
        ];

        modelBuilder.Entity<Categoria>().HasData(categorias);
    }
}