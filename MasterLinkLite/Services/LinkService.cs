using MasterLinkLite.Models;
using System.Text.Json;

namespace MasterLinkLite.Services
{
    public class LinkService
    {
        private readonly string _path = "Data/links.json";

        public List<Link> GetAll()
        {
            if (!File.Exists(_path)) return new List<Link>();
            var json = File.ReadAllText(_path);
            return JsonSerializer.Deserialize<List<Link>>(json) ?? new();
        }

        public void Crear(Link nuevo)
        {
            var lista = GetAll();
            nuevo.Id = lista.Any() ? lista.Max(l => l.Id) + 1 : 1;
            lista.Add(nuevo);
            Guardar(lista);
        }

        public void Eliminar(int id)
        {
            var lista = GetAll();
            var link = lista.FirstOrDefault(l => l.Id == id);
            if (link != null)
            {
                lista.Remove(link);
                Guardar(lista);
            }
        }

        public void Actualizar(Link linkActualizado)
        {
            var lista = GetAll();
            var index = lista.FindIndex(l => l.Id == linkActualizado.Id);
            if (index != -1)
            {
                lista[index] = linkActualizado;
                Guardar(lista);
            }
        }

        private void Guardar(List<Link> lista)
        {
            var json = JsonSerializer.Serialize(lista, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_path, json);
        }
    }
}
