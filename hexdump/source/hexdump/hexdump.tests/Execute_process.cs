using System;
using System.Diagnostics;
using static System.String;

namespace hexdump.tests
{
    public static class Execute_process
    {
        public static Result With_parameters(string program, string[] args) {
            var process = new Process {
                StartInfo = {
                    FileName = program,
                    Arguments = Join(" ", args),
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    WorkingDirectory = Environment.CurrentDirectory,
                    CreateNoWindow = true
                }
            };

            process.Start();
            process.WaitForExit();

            return new Result {
                ConsoleError = process.StandardError.ReadToEnd().Split(new[] { Environment.NewLine }, StringSplitOptions.None),
                ConsoleOut = process.StandardOutput.ReadToEnd().Split(new[] { Environment.NewLine }, StringSplitOptions.None),
                ExitCode = process.ExitCode
            };
        }
    }

    public struct Result
    {
        public string[] ConsoleOut;

        public string[] ConsoleError;

        public int ExitCode;
    }
}