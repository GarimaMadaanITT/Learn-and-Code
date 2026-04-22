using CleanCodeAssignments.Core.Interfaces;
using CleanCodeAssignments.Models;
using CleanCodeAssignments.Config;

namespace CleanCodeAssignments.Services
{
    public class DataProcessor
    {
        private readonly IDataReader reader;
        private readonly IDataParser parser;
        private readonly IDataValidator validator;
        private readonly IDataTransformer transformer;
        private readonly IDataWriter writer;
        private readonly ILogger logger;
        private readonly ProcessingConfig config;

        public List<Record> Process(string input, string output)
        {
            logger.Log("Starting processing");

            var raw = reader.Read(input);
            var parsed = parser.Parse(raw);

            if (config.Validate)
                parsed = validator.Validate(parsed);

            if (config.Transform)
                parsed = transformer.Transform(parsed);

            writer.Write(output, parsed);

            logger.Log("Processing completed");

            return parsed;
        }

        public DataProcessor(
            IDataReader reader,
            IDataParser parser,
            IDataValidator validator,
            IDataTransformer transformer,
            IDataWriter writer,
            ILogger logger,
            ProcessingConfig config)
        {
            this.reader = reader;
            this.parser = parser;
            this.validator = validator;
            this.transformer = transformer;
            this.writer = writer;
            this.logger = logger;
            this.config = config;
        }
    }
}