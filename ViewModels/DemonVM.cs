using FusionCalculator.Database.Tables;
using FusionCalculator.Models;
using FusionCalculator.Resources.Constants;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FusionCalculator.ViewModels
{
    public class DemonVM:ViewModelBase
    {
        public SQLiteConnection Database { get; set; }

        public string demonRace { get; set; }

        public int demonLevel { get; set; }

        public string demonName { get; set; }

        public int demonHP { get; set; }

        public int demonMP { get; set; }

        public int demonStr { get; set; }

        public int demonInt { get; set; }

        public int demonVit { get; set; }

        public int demonMag { get; set; }

        public int demonAgi { get; set; }

        public int demonLck { get; set; }

        public string physResist { get; set; }
        public string gunResist { get; set; }
        public string fireResist { get; set; }
        public string iceResist { get; set; }
        public string elecResist { get; set; }

        public string forceResist { get; set; }
        public string expelResist { get; set; }
        public string curseResist { get; set; }

        public List<FusionPair> FusionPairs { get; set; } = new List<FusionPair>();

        public List<FusionPair> GetFusions(int demonId)
        {
            var fusions = new List<FusionPair>();
            var dbDemon = Database.Table<Demon>();
            var dbFusionPairs  = Database.Table<RaceFusionPairs>();
            var dbRace = Database.Table<Race>();
            var demonEntry = dbDemon.Single(n => n.Id == demonId);
            var demonRaceList = dbDemon.Where(n => n.Race == demonEntry.Race);
            var fusionPairs = dbFusionPairs.Where(n => n.RaceID == demonEntry.Race);
            if (fusionPairs != null)
            {
                foreach(var fusionPair in fusionPairs)
                {
                    var firstRace = dbRace.Single(n => n.Id == fusionPair.First);
                    var secondRace = dbRace.Single(n => n.Id == fusionPair.Second);
                    foreach (var firstRaceDemon in dbDemon.Where(n => n.Race == fusionPair.First))
                    {
                        foreach (var secondRaceDemon in dbDemon.Where(n => n.Race == fusionPair.Second))
                        {
                            var averageLevel = (firstRaceDemon.Level + secondRaceDemon.Level) / 2;
                            var closestFusion = demonRaceList.Aggregate((x, y) => Math.Abs(x.Level - averageLevel) < Math.Abs(y.Level - averageLevel) ? x : y);
                            if (closestFusion.Level == demonEntry.Level)
                            {
                                fusions.Add(new FusionPair(firstRaceDemon, secondRaceDemon));
                            }
                            //if (averageLevel < demonEntry.Level+3 && averageLevel > demonEntry.Level - 3)
                            //{
                            //    fusions.Add(new FusionPair(firstRaceDemon, secondRaceDemon));
                            //}
                        }
                    }
                }
            }
            return fusions;
        }

        public DemonVM(int demonID)
        {
            Database = new SQLiteConnection(Constants.DatabasePath);
            demonRace = GetDemonRace(demonID);
            demonName = GetDemonName(demonID);
            demonLevel = GetDemonLevel(demonID);

            demonHP = GetDemonHP(demonID);
            demonMP = GetDemonMP(demonID);
            demonStr = GetDemonStr(demonID);
            demonInt = GetDemonInt(demonID);
            demonVit = GetDemonVit(demonID);
            demonMag = GetDemonMag(demonID);
            demonAgi = GetDemonAgi(demonID);
            demonLck = GetDemonStr(demonID);

            physResist = GetDemonPhysResistance(demonID);
            gunResist = GetDemonGunResistance(demonID);

            fireResist = GetDemonFireResistance(demonID);
            iceResist = GetDemonIceResistance(demonID);
            elecResist = GetDemonElecResistance(demonID);
            forceResist = GetDemonForceResistance(demonID);

            expelResist = GetDemonExpelResistance(demonID);
            curseResist = GetDemonCurseResistance(demonID);
            FusionPairs = GetFusions(74);

        }

        private string GetDemonRace(int demonID)
        {
            var dbRace = Database.Table<Race>();
            var dbDemon = Database.Table<Demon>();
            var demonEntry = dbDemon.Single(n => n.Id == demonID);
            var demonRaceId = demonEntry.Race;
            var demonRace = dbRace.Single(n => n.Id == demonRaceId);
            return demonRace.Name;
        }

        private int GetDemonLevel(int demonID)
        {
            var dbDemon = Database.Table<Demon>();
            var demonEntry = dbDemon.Single(n => n.Id == demonID);
            return demonEntry.Level;
        }

        private string GetDemonName(int demonID)
        {
            var dbDemon = Database.Table<Demon>();
            var demonEntry = dbDemon.Single(n => n.Id == demonID);
            return demonEntry.Name;
        }

        private int GetDemonHP(int demonID)
        {
            var dbDemon = Database.Table<DemonStats>();
            var demonEntry = dbDemon.Single(n => n.DemonID == demonID);
            return demonEntry.HP;
        }

        private int GetDemonMP(int demonID)
        {
            var dbDemon = Database.Table<DemonStats>();
            var demonEntry = dbDemon.Single(n => n.DemonID == demonID);
            return demonEntry.MP;
        }

        private int GetDemonStr(int demonID)
        {
            var dbDemon = Database.Table<DemonStats>();
            var demonEntry = dbDemon.Single(n => n.DemonID == demonID);
            return demonEntry.Strength;
        }

        private int GetDemonInt(int demonID)
        {
            var dbDemon = Database.Table<DemonStats>();
            var demonEntry = dbDemon.Single(n => n.DemonID == demonID);
            return demonEntry.Intelligence;
        }

        private int GetDemonMag(int demonID)
        {
            var dbDemon = Database.Table<DemonStats>();
            var demonEntry = dbDemon.Single(n => n.DemonID == demonID);
            return demonEntry.Magic;
        }

        private int GetDemonVit(int demonID)
        {
            var dbDemon = Database.Table<DemonStats>();
            var demonEntry = dbDemon.Single(n => n.DemonID == demonID);
            return demonEntry.Vitality;
        }

        private int GetDemonAgi(int demonID)
        {
            var dbDemon = Database.Table<DemonStats>();
            var demonEntry = dbDemon.Single(n => n.DemonID == demonID);
            return demonEntry.Agility;
        }

        private int GetDemonLck(int demonID)
        {
            var dbDemon = Database.Table<DemonStats>();
            var demonEntry = dbDemon.Single(n => n.DemonID == demonID);
            return demonEntry.Luck;
        }

        private string GetDemonPhysResistance(int demonID)
        {
            var dbResist = Database.Table<Resistances>();
            var demonEntry = dbResist.Single(n => n.DemonID == demonID);
            return demonEntry.Phys;
        }

        private string GetDemonGunResistance(int demonID)
        {
            var dbResist = Database.Table<Resistances>();
            var demonEntry = dbResist.Single(n => n.DemonID == demonID);
            return demonEntry.Gun;
        }


        private string GetDemonFireResistance(int demonID)
        {
            var dbResist = Database.Table<Resistances>();
            var demonEntry = dbResist.Single(n => n.DemonID == demonID);
            return demonEntry.Fire;
        }

        private string GetDemonIceResistance(int demonID)
        {
            var dbResist = Database.Table<Resistances>();
            var demonEntry = dbResist.Single(n => n.DemonID == demonID);
            return demonEntry.Ice;
        }

        private string GetDemonElecResistance(int demonID)
        {
            var dbResist = Database.Table<Resistances>();
            var demonEntry = dbResist.Single(n => n.DemonID == demonID);
            return demonEntry.Elec;
        }

        private string GetDemonForceResistance(int demonID)
        {
            var dbResist = Database.Table<Resistances>();
            var demonEntry = dbResist.Single(n => n.DemonID == demonID);
            return demonEntry.Force;
        }

        private string GetDemonExpelResistance(int demonID)
        {
            var dbResist = Database.Table<Resistances>();
            var demonEntry = dbResist.Single(n => n.DemonID == demonID);
            return demonEntry.Expel;
        }

        private string GetDemonCurseResistance(int demonID)
        {
            var dbResist = Database.Table<Resistances>();
            var demonEntry = dbResist.Single(n => n.DemonID == demonID);
            return demonEntry.Curse;
        }




    }
}
