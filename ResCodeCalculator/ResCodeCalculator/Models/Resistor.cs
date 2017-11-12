using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ResCodeCalculator.Models
{
    public class Resistor : IOhmValueCalculator
    {
        [Display(Name = "1st Digit")]
        public DigitColor BandA { get; set; }
        [Display(Name = "2nd Digit")]
        public DigitColor BandB { get; set; }
        [Display(Name = "Multiplier")]
        public MultiplierColor BandC { get; set; }
        [Display(Name = "Tolerance")]
        public ToleranceColor BandD { get; set; }

        // calculate resistance values
        public double CalculateOhmValue(string bandAColor, string bandBColor, string bandCColor, string bandDColor)
        {
            var bandAVal = CalculateDigit(bandAColor);
            var bandBVal = CalculateDigit(bandBColor);
            var bandCVal = CalculateMultiplier(bandCColor);
            var bandDVal = CalculateTolerance(bandDColor);

            double total = (bandAVal*10 + bandBVal)*bandCVal;
            return total;
        }

        // decode 1st, 2nd digit value
        private int CalculateDigit(string bandAColor)
        {
            DigitColor bandAEnum = DigitColor.Black;
            Enum.TryParse(bandAColor, out bandAEnum);

            return (int)bandAEnum;
        }

        // decode multiplier value
        private double CalculateMultiplier(string bandCColor)
        {
            double bandCVal = 0;
            var bandCEnum = MultiplierColor.Black;
            Enum.TryParse(bandCColor, out bandCEnum);
            switch (bandCEnum)
            {
                case (MultiplierColor.Black):
                default:
                    bandCVal = 1;
                    break;
                case (MultiplierColor.Brown):
                    bandCVal = 10;
                    break;
                case (MultiplierColor.Red):
                    bandCVal = 100;
                    break;
                case (MultiplierColor.Orange):
                    bandCVal = 1e3;
                    break;
                case (MultiplierColor.Yellow):
                    bandCVal = 10e3;
                    break;
                case (MultiplierColor.Green):
                    bandCVal = 100e3;
                    break;
                case (MultiplierColor.Blue):
                    bandCVal = 1e6;
                    break;
                case (MultiplierColor.Gold):
                    bandCVal = 0.1;
                    break;
                case (MultiplierColor.Silver):
                    bandCVal = 0.01;
                    break;
            }
            return bandCVal;
        }

        // decode tolerance value
        public int CalculateTolerance(string bandDColor)
        {
            var bandDVal = 0;
            var bandDEnum = ToleranceColor.Brown;
            Enum.TryParse(bandDColor, out bandDEnum);
            switch (bandDEnum)
            {
                case (ToleranceColor.Brown):
                default:
                    bandDVal = 1;
                    break;
                case (ToleranceColor.Red):
                    bandDVal = 2;
                    break;
                case (ToleranceColor.Gold):
                    bandDVal = 5;
                    break;
                case (ToleranceColor.Silver):
                    bandDVal = 10;
                    break;
            }
            return bandDVal;
        }

        // Enum types
        public enum DigitColor
        {
            Black,
            Brown,
            Red,
            Orange,
            Yellow,
            Green,
            Blue,
            Violet,
            Gray,
            White
        }

        public enum MultiplierColor
        {
            Black,
            Brown,
            Red,
            Orange,
            Yellow,
            Green,
            Blue,
            Gold,
            Silver,
        }

        public enum ToleranceColor
        {
            Brown,
            Red,
            Gold,
            Silver
        }
    }
}