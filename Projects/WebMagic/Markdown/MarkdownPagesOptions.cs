using System.Collections.Generic;
using MarkdownSharp;

namespace WebMagic.Markdown
{
    public class MarkdownPagesOptions
    {
        public MarkdownPagesOptions()
        {
            MarkdownExtensions = new[] {".md", ".markdown"};
            MarkdownSharpOptions = new MarkdownOptions();
        }

        public IEnumerable<string> MarkdownExtensions { get; set; }
        public IMarkdownOptions MarkdownSharpOptions { get; set; }
    }
}