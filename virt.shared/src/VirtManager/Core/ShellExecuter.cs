using System.Diagnostics;

namespace VirtManager.Core
{
        /** Class holding the output of a command **/
        public class CommandOutput
        {
                public string StandardOutput { get; set; }
                public string StandardError { get; set; }

                public override string ToString()
                {
                        return "stdout :\n" + StandardOutput + "\nstderr :\n" + StandardError;
                }
        }
        public class ShellExecuter
        {
                /**
                 * Executes a bash command and returns the result
                 */
                public static CommandOutput ExecuteBash(string command)
                {
                        string escapedArgs = command.Replace("\"", "\\\"");
                        Process bashProcess = new Process()
                        {
                                StartInfo = new ProcessStartInfo
                                {
                                        FileName = "/bin/bash",
                                        Arguments = $"-c \"{escapedArgs}\"",
                                        RedirectStandardOutput = true,
                                        RedirectStandardError = true,
                                        UseShellExecute = false,
                                        CreateNoWindow = true,
                                }
                        };
                        bashProcess.Start();
                        CommandOutput output = new CommandOutput()
                        {
                                StandardOutput = bashProcess.StandardOutput.ReadToEnd(),
                                StandardError = bashProcess.StandardError.ReadToEnd()
                        };
                        bashProcess.WaitForExit();
                        return output;
                }
        }
}