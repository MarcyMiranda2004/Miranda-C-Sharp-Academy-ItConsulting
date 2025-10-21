using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
// COPIATO DALLA REPO, stavo cercando di capire bene il funzionamento delle setter inj analizzando meglio il primo esercizio
namespace Lezione_W4_D2.EssPrinter
{
    using System;
    using System.IO;
    using System.Text;

    #region Contratti
    public interface IStorageService
    {
        void Save(string fileName, byte[] content);
    }
    #endregion

    #region Implementazioni
    public class DiskStorageService : IStorageService
    {
        private readonly string _basePath;

        public DiskStorageService(string basePath)
        {
            _basePath = basePath;
            Directory.CreateDirectory(_basePath);
        }

        public void Save(string fileName, byte[] content)
        {
            var fullPath = Path.Combine(_basePath, fileName);
            File.WriteAllBytes(fullPath, content);
            Console.WriteLine($"[Disk] Salvato su {fullPath}");
        }
    }

    public class MemoryStorageService : IStorageService
    {
        // Simulazione semplice: non persistiamo su disco
        public void Save(string fileName, byte[] content)
        {
            Console.WriteLine($"[Memory] Ricevuto {fileName} ({content.Length} bytes) — simulazione OK");
        }
    }
    #endregion

    #region Componente che riceve la dipendenza via COSTRUTTORE
    public class FileUploader
    {
        private readonly IStorageService _storage;

        // Constructor Injection: dipendenza obbligatoria
        public FileUploader(IStorageService storage)
        {
            _storage = storage ?? throw new ArgumentNullException(nameof(storage));
        }

        public void Upload(string fileName, byte[] content)
        {
            if (string.IsNullOrWhiteSpace(fileName))
                throw new ArgumentException("Nome file non valido.", nameof(fileName));

            _storage.Save(fileName, content);
        }
    }
    #endregion
}