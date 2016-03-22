using System;
using NUnit.Framework;

namespace hexdump.tests
{
    [TestFixture]
    public class IntegrationsTests
    {
        [SetUp]
        public void Setup() {
            Environment.CurrentDirectory = TestContext.CurrentContext.TestDirectory;
        }

        [Test]
        public void Keine_Kommandozeilen_Parameter() {
            var result = Execute_process.With_parameters("hexdump.exe", new string[] { });

            Assert.That(result.ExitCode, Is.EqualTo(1));
            Assert.That(result.ConsoleError[0], Is.EqualTo("Usage: hexdump <dateiname>"));
        }

        [Test]
        public void Datei_nicht_gefunden() {
            var result = Execute_process.With_parameters("hexdump.exe", new[] { "file-not-found.txt" });

            Assert.That(result.ExitCode, Is.EqualTo(2));
            Assert.That(result.ConsoleError[0], Is.EqualTo("No such file: file-not-found.txt"));
        }

        [Test]
        public void Datei_wird_ausgegeben() {
            using (var consoleOutput = new ConsoleOutput()) {
                MainClass.Main(new[] { "testdata\\hexdump.pdb" });
                var ouput = consoleOutput.GetOuputLines();
                Assert.That(ouput[0], Is.EqualTo("0000: 4d 69 63 72 6f 73 6f 66 -- 74 20 43 2f 43 2b 2b 20   Microsoft C/C++ "));
                Assert.That(ouput[1], Is.EqualTo("0010: 4d 53 46 20 37 2e 30 30 -- 0d 0a 1a 44 53 00 00 00   MSF 7.00...DS..."));
                Assert.That(ouput[2], Is.EqualTo("0020: 00 02 00 00 02 00 00 00 -- 1b 00 00 00 80 00 00 00   ............?..."));
            }
        }

        [Test]
        public void Kurze_Datei_letzte_Zeile_keine_16_Byte_lang() {
            using (var consoleOutput = new ConsoleOutput()) {
                MainClass.Main(new[] { "testdata\\kurze-datei.txt" });
                var ouput = consoleOutput.GetOuputLines();
                Assert.That(ouput[0], Is.EqualTo("0000: ef bb bf 31 32 33 34 35 -- 36 37 38 39 30 31 32 33   ???1234567890123"));
                Assert.That(ouput[1], Is.EqualTo("0010: 34 35 36 0d 0a 31 32 33 -- 34 35 36 0d 0a         456..123456.."));
            }
        }
    }
}