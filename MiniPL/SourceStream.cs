using System.Text;
using System.IO;

namespace MiniPL
{
    public sealed class SourceStream
    {
        private readonly string file;
        private int position;

        public SourceStream(string Path)
        {
            file = File.ReadAllText(Path, Encoding.UTF8);
        }

        public bool EndOfStream { get { return file.Length <= position; } }

        public char Current { get { return file[position]; } }

        public void MoveNext()
        {
            position++;
        }
    }
}
