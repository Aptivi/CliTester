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

using System;

namespace CliTester.Exceptions
{
    /// <summary>
    /// This is an exception that gets thrown when there are no fixtures
    /// </summary>
    [Serializable]
    public class NoFixturesException : Exception
    {
        /// <summary>
        /// Creates a new exception
        /// </summary>
        public NoFixturesException()
        { }

        /// <summary>
        /// Creates a new exception
        /// </summary>
        /// <param name="message">Message to describe the reason</param>
        public NoFixturesException(string message) :
            base(message)
        { }

        /// <summary>
        /// Creates a new exception
        /// </summary>
        /// <param name="message">Message to describe the reason</param>
        /// <param name="inner">Inner exception</param>
        public NoFixturesException(string message, Exception inner) :
            base(message, inner)
        { }
    }
}
