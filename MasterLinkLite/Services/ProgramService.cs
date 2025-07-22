using MasterLinkLite.Models;
using System.Text.Json;

namespace MasterLinkLite.Services
{
    public class ProgramService
    {
        private readonly string _path = "Data/programs.json";

        public List<Programs> GetAll()
        {
            if (!File.Exists(_path)) return new List<Programs>();
            var json = File.ReadAllText(_path);
            return JsonSerializer.Deserialize<List<Programs>>(json) ?? new();
        }

        public void Crear(Programs nuevo)
        {
            var lista = GetAll();
            nuevo.Id = lista.Any() ? lista.Max(p => p.Id) + 1 : 1;
            lista.Add(nuevo);
            Guardar(lista);
        }

        public void Eliminar(int id)
        {
            var lista = GetAll();
            var prog = lista.FirstOrDefault(p => p.Id == id);
            if (prog != null)
            {
                lista.Remove(prog);
                Guardar(lista);
            }
        }

        public void Actualizar(Programs actualizado)
        {
            var lista = GetAll();
            var index = lista.FindIndex(p => p.Id == actualizado.Id);
            if (index != -1)
            {
                lista[index] = actualizado;
                Guardar(lista);
            }
        }

        private void Guardar(List<Programs> lista)
        {
            var json = JsonSerializer.Serialize(lista, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_path, json);
        }
    }
}