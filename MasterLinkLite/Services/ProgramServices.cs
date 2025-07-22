using System.Text.Json;
using MasterLinkLite.Models;

namespace MasterLinkLite.Services
{
    public class ProgramServices
    {
        private readonly string _path = "Data/programs.json";
        public List<Programs> GetAll()
        {
            if (!File.Exists(_path)) return new List<Programs>();
            var json = File.ReadAllText(_path);
            return JsonSerializer.Deserialize<List<Programs>>(json) ?? new();
        }
        public void AgregarPrograma(Programs nuevo)
        {
            var lista = GetAll();
            nuevo.Id = lista.Any() ? lista.Max(p => p.Id) + 1 : 1;
            lista.Add(nuevo);
            var json = JsonSerializer.Serialize(lista, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_path, json);
        }
    }
}