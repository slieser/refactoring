using System;
using System.IO;

namespace hexdump.tests
{
    public class ConsoleOutput : IDisposable
    {
        private readonly StringWriter stringWriter;
        private readonly TextWriter originalOutput;

        public ConsoleOutput() {
            stringWriter = new StringWriter();
            originalOutput = Console.Out;
            Console.SetOut(stringWriter);
        }

        public string GetOuput() {
            return stringWriter.ToString();
        }

        public string[] GetOuputLines() {
            return stringWriter.ToString().Split(new[] { Environment.NewLine }, StringSplitOptions.None);
        }

        public void Dispose() {
            Console.SetOut(originalOutput);
            stringWriter.Dispose();
        }
    }
}