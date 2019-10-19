namespace KbMath.Console.Commands
{
    using System;
    using KbMath.Core.Geometry2D.Extensions;
    using KbMath.Core.Geometry2D.Models;
    using Microsoft.Extensions.CommandLineUtils;
    using Services;

    internal class ScratchCommand
    {
        public ScratchCommand(ISvgService svgService)
        {
            CommandLineApplication command = ApplicationContext.CommandLineApplication
                .Command("scratch", config =>
                {
                    config.Description = "Command for general purpose scratchpad use";
                    config.OnExecute(() => Execute());
                });
        }

        public int Execute()
        {
            double magnitude = Math.Sqrt(2 * Math.Pow(18.1/2, 2));
            
            double topRightTheta = (45 - 10).ToRadians();
            double topLeftTheta = (90 + 45 - 10).ToRadians();
            double botLeftTheta = (180 + 45 - 10).ToRadians();
            double botRightTheta = (270 + 45 - 10).ToRadians();

            Project(-120.1,  -44.983, topLeftTheta,  magnitude, "01"); // r00c00
            Project(-62.429, -42.938, topLeftTheta,  magnitude, "02"); // r00c03
            Project(-62.429, -42.938, topRightTheta, magnitude, "03"); // r00c03
            Project(-26.818, -25.489, topRightTheta, magnitude, "04"); // r00c05
            Project(-133.332, 30.059, botLeftTheta,  magnitude, "05"); // r04c00
            Project(-114.571, 33.367, botRightTheta, magnitude, "06"); // r04c01
            Project(-40.05,   49.554, botLeftTheta,  magnitude, "07"); // r04c05
            Project(-21.289,  52.862, botRightTheta, magnitude, "08"); // r01c06
            
            return 0;
        }

        private void Project(double x, double y, double theta, double magnitude, string name)
        {
            var projection = new Vector(x, -y).Project(theta, magnitude);
            Console.WriteLine($"<Constant Name=\"X{name}\" Value=\"{projection.X}\" />");
            Console.WriteLine($"<Constant Name=\"Y{name}\" Value=\"{-projection.Y}\" />");
        }
    }
}
