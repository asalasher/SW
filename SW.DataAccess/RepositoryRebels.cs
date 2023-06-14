using SW.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SW.DataAccess
{
    public class RepositoryRebels : IRepositoryRebels
    {
        private readonly string _storageFileName = "rebelsStore.txt";
        private readonly string _storageFilePath;

        public RepositoryRebels()
        {
            _storageFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "LocalStorage", _storageFileName);
        }

        public Rebel Create(Rebel rebel)
        {
            List<string> storageRecords = File.ReadAllLines(_storageFilePath).ToList();
            string newRecord = $"rebeld {rebel.Name} on {rebel.PlanetName} at {DateTime.UtcNow}";
            storageRecords.Add(newRecord);
            File.WriteAllLines(_storageFilePath, storageRecords);

            return rebel;
        }

    }
}
