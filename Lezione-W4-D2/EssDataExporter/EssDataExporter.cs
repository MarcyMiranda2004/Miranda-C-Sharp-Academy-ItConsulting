using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lezione_W4_D2.EssDataExporter
{

    #region DATA - EXPORTER
    public class Data
    {
        public string Nome { get; set; }
        public string Contenuto { get; set; }
    }

    public class DataExporter
    {
        public void Export(Data data, IExportFormatter formatter)
        {
            string risultato = formatter.Format(data);
            Console.WriteLine($"Esportazione in corso...");
            Console.WriteLine(risultato);
        }
    }
    #endregion

    #region INTERFACCE
    public interface IExportFormatter
    {
        string Format(Data file);
    }

    #endregion

    #region STRATEGY
    public class ExportJSONStrategy : IExportFormatter
    {
        public string Format(Data file) => $"Nome File: {file.Nome} Contenuto Del File: {file.Contenuto} esportato in JSON";
    }

    public class ExportXMLStrategy : IExportFormatter
    {
        public string Format(Data file) => $"Nome File: {file.Nome} Contenuto Del File: {file.Contenuto} esportato in XML";
    }
    #endregion
}