//
// CliTester  Copyright (C) 2024  Aptivi
//
// This file is part of CliTester
//
// CliTester is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// CliTester is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY, without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <https://www.gnu.org/licenses/>.
//

using CliTester.Demo.FixtureData;
using CliTester.Instances;
using CliTester.Tools;
using Terminaux.Colors.Data;
using Terminaux.Writer.ConsoleWriters;

namespace CliTester.Demo
{
    internal class EntryPoint
    {
        private static readonly Fixture[] fixtures =
        [
            new FixtureUnconditional<Action>(nameof(UnconditionalFunctions.TestWrite), "Tests writing to console", UnconditionalFunctions.TestWrite),
            new FixtureUnconditional<Action<string>>(nameof(UnconditionalFunctions.TestWriteArgs), "Tests writing to console with arguments", UnconditionalFunctions.TestWriteArgs),
            new FixtureConditional<Func<int>>(nameof(ConditionalFunctions.TestRead), "Tests writing to console", ConditionalFunctions.TestRead, (int)'A'),
            new FixtureConditional<Func<double, double, double>>(nameof(ConditionalFunctions.TestReadArgs), "Tests writing to console with arguments", ConditionalFunctions.TestReadArgs, 0d),
        ];

        static void Main()
        {
            TextWriterColor.Write("Running fixture 1...");
            bool result = FixtureRunner.RunTest((FixtureUnconditional<Action>?)fixtures[0], out var exc);
            TextWriterColor.WriteColor($"Outcome: {result} [{(exc is not null ? exc.Message : "No error")}]", result ? ConsoleColors.Lime : ConsoleColors.Red);

            TextWriterColor.Write("Running fixture 2...");
            bool result2 = FixtureRunner.RunTest((FixtureUnconditional<Action<string>>?)fixtures[1], out var exc2, "John");
            TextWriterColor.WriteColor($"Outcome: {result2} [{(exc2 is not null ? exc2.Message : "No error")}]", result2 ? ConsoleColors.Lime : ConsoleColors.Red);

            TextWriterColor.Write("Running fixture 3...");
            bool result3 = FixtureRunner.RunTest<Func<int>, int>((FixtureConditional<Func<int>>?)fixtures[2], out var exc3);
            TextWriterColor.WriteColor($"Outcome: {result3} [{(exc3 is not null ? exc3.Message : "No error")}]", result3 ? ConsoleColors.Lime : ConsoleColors.Red);

            TextWriterColor.Write("Running fixture 4...");
            bool result4 = FixtureRunner.RunTest<Func<double, double, double>, double>((FixtureConditional<Func<double, double, double>>?)fixtures[3], out var exc4, 4, 2);
            TextWriterColor.WriteColor($"Outcome: {result4} [{(exc4 is not null ? exc4.Message : "No error")}]", result4 ? ConsoleColors.Lime : ConsoleColors.Red);

            TextWriterColor.Write("Running fixture 4 (expected fail)...");
            bool result5 = FixtureRunner.RunTest<Func<double, double, double>, double>((FixtureConditional<Func<double, double, double>>?)fixtures[3], out var exc5, 5, 2);
            TextWriterColor.WriteColor($"Outcome: {result5} [{(exc5 is not null ? exc5.Message : "No error")}]", result5 ? ConsoleColors.Lime : ConsoleColors.Red);
        }
    }
}
