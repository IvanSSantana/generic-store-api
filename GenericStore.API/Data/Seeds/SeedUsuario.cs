using GenericStore.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace GenericStore.API.Data.Seeds;

public class SeedUsuario
{
    public SeedUsuario(ModelBuilder builder)
    {
        #region Perfis de Usuário
        List<IdentityRole> perfis = [
            new() {
                Id = "980aa9cb-773b-465f-8dfe-f2d8861b536a",
                Name = "Admin",
                NormalizedName = "ADMIN"
            },
            new() {
                Id = "bf44ae04-b358-49cc-97ff-5ad1313d82cc",
                Name = "Cliente",
                NormalizedName = "CLIENTE"
            },
        ];

        builder.Entity<IdentityRole>().HasData(perfis);
        #endregion

        #region Usuário
        List<Usuario> usuarios = [
            new() {
                Id = "3dff3bc1-5936-4b79-abbe-0c8fb51d6845",
                Email = "jorgejr@gstore.com.br",
                NormalizedEmail = "ADMIN@GSTORE.COM.BR",
                UserName = "jorgejr@gstore.com.br",
                NormalizedUserName = "ADMIN@GSTORE.COM.BR",
                LockoutEnabled = true,
                EmailConfirmed = true,
                Nome = "Jorge Henrique Antunes",
                DataNascimento = DateTime.Parse("19/08/2000"),
                Foto = "/img/usuarios/3dff3bc1-5936-4b79-abbe-0c8fb51d6845.png"
            }
        ];

        foreach (var usuario in usuarios)
        {
            PasswordHasher<Usuario> pass = new();
            usuario.PasswordHash = pass.HashPassword(usuario, "123456");
        }

        builder.Entity<Usuario>().HasData(usuarios);   
        #endregion

        #region Usuário-Perfil
        List<IdentityUserRole<string>> userRoles = [
            new() {
                RoleId = "980aa9cb-773b-465f-8dfe-f2d8861b536a",
                UserId = "3dff3bc1-5936-4b79-abbe-0c8fb51d6845"
            }
        ];
        
        builder.Entity<IdentityUserRole<string>>().HasData(userRoles);
        #endregion
    }
}