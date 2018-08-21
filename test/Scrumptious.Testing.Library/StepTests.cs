using Scrumptious.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Scrumptious.Testing.Library
{
    public class StepTests
    {
        private Step sut = new Step();
        [Fact]
        public void Test_StepModifyName()
        {
            sut.Name = "billy bob";
            Assert.IsType<string>(sut.Name);
        }

        [Fact]
        public void Test_StepModifyDesc()
        {
            sut.StepDescription = "this is a step.";
            Assert.IsType<string>(sut.StepDescription);
        }
    }
}
