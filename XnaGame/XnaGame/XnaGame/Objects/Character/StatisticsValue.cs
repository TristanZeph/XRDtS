using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XnaGame.Objects.Character {
    class StatisticsValue {
        public string Name;
        public MinMaxStat Health;
        public MinMaxStat Stamina;
        public int Strength;
        public int Speed;

        public StatisticsValue() {
            Name = "BattleUnit Class";
            Health = new MinMaxStat(100);
            Stamina = new MinMaxStat(100);
            Strength = 10;
            Speed = 10;
        }

        public StatisticsValue(string name, int hp, int sta, int str, int spd) {
            Name = name;
            Health = new MinMaxStat(hp);
            Stamina = new MinMaxStat(sta);
            Strength = str;
            Speed = spd;
        }
    }
}
