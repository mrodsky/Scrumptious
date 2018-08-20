using Scrumptious.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Scrumptious.Testing.Data
{
    public class SprintTest
    {

        private Sprint sut;

        public SprintTest()
        {
            sut = new Sprint()
            {
                FkProject = new Project(),

            };
        }
    }
}
