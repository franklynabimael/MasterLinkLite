using System.Text.Json;
using MasterLinkLite.Models;

namespace MasterLinkLite.Services
{
    public class UsuarioService
    {
        private readonly string _path = "Data/usuarios.json";

        public List<Usuario> GetAll()
        {
            if (!File.Exists(_path)) return new List<Usuario>();
            var json = File.ReadAllText(_path);
            return JsonSerializer.Deserialize<List<Usuario>>(json) ?? new();
        }

        public Usuario? ValidarLogin(string username, string password)
        {
            return GetAll().FirstOrDefault(u =>
                u.NombreUsuario.Equals(username, StringComparison.OrdinalIgnoreCase) &&
                u.Password == password);
        }

        public bool Existe(string username)
        {
            return GetAll().Any(u => u.NombreUsuario.Equals(username, StringComparison.OrdinalIgnoreCase));
        }

        public void AgregarUsuario(Usuario nuevo)
        {
            var lista = GetAll();
            nuevo.Id = lista.Any() ? lista.Max(u => u.Id) + 1 : 1;
            lista.Add(nuevo);
            var json = JsonSerializer.Serialize(lista, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_path, json);
        }
    }
}
