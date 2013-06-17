using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XnaGame.Objects.Character {
    class MinMaxStat {
        private int currentValue;
        private int maximumValue;

        public int Current {
            get { return currentValue; }
            set {
                currentValue += value;

                if (currentValue < 0)
                    currentValue = 0;
                else if (currentValue > maximumValue)
                    currentValue = maximumValue;
            }
        }

        public int Maximum {
            get { return maximumValue; }
            set {
                maximumValue += value;
                if (maximumValue <= 0)
                    maximumValue = 1;
            }
        }

        public MinMaxStat(int value) {
            SetCurrent(value);
            SetMaximum(value);
        }

        public void SetCurrent(int value) {
            if (value < 0)
                currentValue = 0;
            else
                currentValue = value;
        }

        public void SetMaximum(int value) {
            if (value < 1)
                maximumValue = 1;
            else
                maximumValue = value;
        }
    }
}
