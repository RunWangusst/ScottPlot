﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScottPlotTests.UnitTests
{
    internal static class TickMaker
    {
        private static string LabelsMajor(this ScottPlot.Tick[] ticks) =>
            string.Join(", ", ticks.Where(x => !string.IsNullOrWhiteSpace(x.Label)).Select(x => x.Label));

        private static string PositionsMajor(this ScottPlot.Tick[] ticks) =>
            string.Join(", ", ticks.Where(x => !string.IsNullOrWhiteSpace(x.Label)).Select(x => x.Position.ToString()));

        [Test]
        public static void Test_DefaultTickMaker_AlwaysMakesTicks()
        {
            var tickFactory = new ScottPlot.TickFactories.SimpleNumericTickFactory();

            ScottPlot.Tick[] ticks = tickFactory.GenerateTicks(ScottPlot.PlotInfo.Default, ScottPlot.Edge.Bottom);

            Console.WriteLine(ticks.LabelsMajor());
            Console.WriteLine(ticks.PositionsMajor());

            Assert.IsNotNull(ticks);
            Assert.IsNotEmpty(ticks);
        }
    }
}
