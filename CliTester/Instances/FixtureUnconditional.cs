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
using System.Diagnostics;

namespace CliTester.Instances
{
    /// <summary>
    /// Test fixture class (routines that return <see langword="void"/>)
    /// </summary>
    [DebuggerDisplay("[U: {fixtureDelegate.GetType().Name}] {Name}: {Description}")]
    public class FixtureUnconditional<TDelegate> : Fixture
        where TDelegate : Delegate
    {
        internal TDelegate fixtureDelegate;

        /// <summary>
        /// Makes a new test fixture class
        /// </summary>
        /// <param name="fixtureName">Fixture name</param>
        /// <param name="fixtureDesc">Fixture description</param>
        /// <param name="fixtureDelegate">Delegate that executes this test fixture</param>
        public FixtureUnconditional(string fixtureName, string fixtureDesc, TDelegate? fixtureDelegate) :
            base(fixtureName, fixtureDesc)
        {
            // Check for delegate type
            if (fixtureDelegate is null)
                throw new ArgumentNullException(nameof(fixtureDelegate));
            if (fixtureDelegate.Method.ReturnType != typeof(void))
                throw new ArgumentException("Method in this delegate needs to return void");

            // Install values
            this.fixtureName = fixtureName ?? "Untitled fixture";
            this.fixtureDesc = fixtureDesc ?? "";
            this.fixtureDelegate = fixtureDelegate;
        }
    }
}
