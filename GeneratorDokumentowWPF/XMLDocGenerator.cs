namespace GeneratorDokumentowWPF
{
    class XMLDocGenerator : DocumentGenerator
    {
        public override string GenerateHeader()
        {
            string header = "<?xml version= " + 1.0 + " ?>\n" + Header;

            return header;
        }
        public override string GenerateBody()
        {
            string body = "\n<product>\n" + DocumentDetails + "\n</product>";

            return body;
        }
    }
}
