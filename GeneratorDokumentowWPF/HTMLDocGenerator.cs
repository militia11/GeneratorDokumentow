namespace GeneratorDokumentowWPF
{
    class HTMLDocGenerator : DocumentGenerator
    {
        public string Result { get; set; }
        public override string GenerateHeader()
        {
            string header = "<head>\n" + Header + "\n</head>";
            
            return header;
        }
        public override string GenerateBody()
        {
            string body = "\n\n<header>\n</header>\n\n<body>\n" + DocumentDetails + "\n</body>\n\n<footer>\n\n</footer>\n\n";

            return body;
        }
    }
}
