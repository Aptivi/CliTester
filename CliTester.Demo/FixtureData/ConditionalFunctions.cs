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

namespace CliTester.Demo.FixtureData
{
    internal static class ConditionalFunctions
    {
        internal static int TestRead()
        {
            Console.WriteLine("Console.Read is called. Write 'A' in uppercase");
            int charNum = Console.Read();
            return charNum;
        }

        internal static double TestReadArgs(double dividend, double divisor) =>
            dividend % divisor;
    }
}
