using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace FitnessConsole.Infrastructure.Storage
{
    public class JsonStorage<T> 
    {
        private readonly string _filePath;
        private readonly JsonSerializerOptions _jsonSerializerOptions;
        private readonly List<T> _context;
        private readonly JsonStorageOptions _options;
        public IEnumerable<T> Context => _context;
        public JsonStorage()
        {
            _options = new JsonStorageOptions();
            _filePath = Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar + _options.FilePath;
            _jsonSerializerOptions = new JsonSerializerOptions()
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                WriteIndented = true
            };
            _context = ReadFile().ToList();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return _context;
        }


        public async Task SaveAsync()
        {
            try
            {
                if (!FileExists())
                    File.Create(_filePath).Close();

                await File.WriteAllTextAsync(
                    _filePath,
                    JsonSerializer.Serialize(_context, _jsonSerializerOptions),
                    Encoding.UTF8
                );
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private IEnumerable<T> ReadFile()
        {
            if (!FileExists())
                File.Create(_filePath).Close();

            var result = File.ReadAllText(_filePath);

            if (string.IsNullOrEmpty(result))
                return new List<T>();

            try
            {
                return JsonSerializer.Deserialize<IEnumerable<T>>(result);
            }
            catch (JsonException ex)
            {
                throw new FileLoadException($"Erro ao iniciar arquivo: ${ex}");
            }
        }

        private bool FileExists()
        {
            return File.Exists(_filePath);
        }
    }
}