using CleanCodeAssignments.Config;
using CleanCodeAssignments.Core.Interfaces;
using CleanCodeAssignments.Exporters;
using CleanCodeAssignments.Implementations.Parsers;
using CleanCodeAssignments.Implementations.Readers;
using CleanCodeAssignments.Implementations.Transformers;
using CleanCodeAssignments.Implementations.Validators;
using CleanCodeAssignments.Implementations.Writers;
using CleanCodeAssignments.Services;
using CleanCodeAssignments.Utilities;

class Program
{
    static void Main()
    {
        var config = new ProcessingConfig();

        var logger = new Logger();

        var processor = new DataProcessor(
            new FileDataReader(),
            new CsvDataParser(),
            new DataValidator(),
            new DataTransformer(),
            new CsvDataWriter(),
            logger,
            config
        );

        var result = processor.Process("input.csv", "output.csv");

        // Export
        var jsonExporter = new JsonExporter();
        jsonExporter.Export("output.json", result);

        var xmlExporter = new XmlExporter();
        xmlExporter.Export("output.xml", result);

        logger.Save("processing.log");

        Console.WriteLine("Done!");
    }
}