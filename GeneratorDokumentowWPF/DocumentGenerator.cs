namespace GeneratorDokumentowWPF
{
    abstract class DocumentGenerator
    {
        public string DocumentDetails { get; set; }
        public string Header { get; set; }
        public abstract string GenerateHeader();
        public abstract string GenerateBody();
        public string GenerateDocument()
        {
            string document = GenerateHeader();
            document += GenerateBody();

            return document;
        }
    }
}
