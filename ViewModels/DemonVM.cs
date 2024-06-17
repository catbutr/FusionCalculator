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

        private TableQuery<Demon>? dbDemon { get; set; }

        private TableQuery<Race>? dbRace { get; set; }

        private TableQuery<Skill>? dbSkills { get; set; }

        private TableQuery<DemonStats>? dbDemonStats { get; set; }

        private TableQuery<Resistances>? dbDemonResists { get; set; }

        private string _demonName;

        public string demonRace { get; set; }

        public int demonLevel { get; set; }

        public string demonName
        {
            get => _demonName;
            set
            {
                _demonName = value;
                OnPropertyChanged();
            }
        }

        public int demonHP { get; set; }

        public int demonMP { get; set; }

        public int demonCP { get; set; }

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

        public int demonPAtk { get; set; }
        public int demonPAccuracy { get; set; }
        public int demonDefence { get; set; }
        public int demonEvade { get; set; }
        public int demonMAtk { get; set; }
        public int demonMAccuracy { get; set; }

        public Skill skill1 { get; set; }
        public Skill skill2 { get; set; }
        public Skill skill3 { get; set; }

        public List<FusionPair> FusionPairs { get; set; } = new List<FusionPair>();

        public List<FusionPair> GetFusions(int demonId)
        {
            var fusions = new List<FusionPair>();
            var dbFusionPairs  = Database.Table<RaceFusionPairs>();
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
                        }
                    }
                }
            }
            return fusions;
        }

        public DemonVM(int demonID)
        {
            Database = new SQLiteConnection("E:\\FusionCalculator\\Resources\\Raw\\fusiondata.db");
            dbDemon = Database.Table<Demon>();
            dbRace = Database.Table<Race>();
            dbDemonResists = Database.Table<Resistances>();
            dbDemonStats = Database.Table<DemonStats>();
            dbSkills = Database.Table<Skill>();
            demonRace = GetDemonRace(demonID);
            demonName = GetDemonName(demonID);
            demonLevel = GetDemonLevel(demonID);

            demonHP = GetDemonHP(demonID);
            demonMP = GetDemonMP(demonID);
            demonCP = GetDemonCP(demonID);
            demonStr = GetDemonStr(demonID);
            demonInt = GetDemonInt(demonID);
            demonVit = GetDemonVit(demonID);
            demonMag = GetDemonMag(demonID);
            demonAgi = GetDemonAgi(demonID);
            demonLck = GetDemonLck(demonID);

            demonPAtk = GetDemonPAtk(demonID);
            demonPAccuracy = GetDemonPAccuracy(demonID);
            demonEvade = GetDemonEvasion(demonID);
            demonDefence = GetDemonDefence(demonID);
            demonMAtk = GetDemonMAtk(demonID);
            demonMAccuracy = GetDemonMAccuracy(demonID);

            physResist = GetDemonPhysResistance(demonID);
            gunResist = GetDemonGunResistance(demonID);

            fireResist = GetDemonFireResistance(demonID);
            iceResist = GetDemonIceResistance(demonID);
            elecResist = GetDemonElecResistance(demonID);
            forceResist = GetDemonForceResistance(demonID);

            expelResist = GetDemonExpelResistance(demonID);
            curseResist = GetDemonCurseResistance(demonID);
            FusionPairs = GetFusions(demonID);

            skill1 = GetSkill1(demonID);
            skill2 = GetSkill2(demonID);
            skill3 = GetSkill3(demonID);

        }

        private Skill GetSkill1(int demonID)
        {
            var demonEntry = dbDemon.Single(n => n.Id == demonID);
            var skillID = demonEntry.Skill1;
            return dbSkills.Single(n => n.Id == skillID);
        }

        private Skill GetSkill2(int demonID)
        {
            var demonEntry = dbDemon.Single(n => n.Id == demonID);
            var skillID = demonEntry.Skill2;
            return dbSkills.Single(n => n.Id == skillID);
        }

        private Skill GetSkill3(int demonID)
        {
            var demonEntry = dbDemon.Single(n => n.Id == demonID);
            var skillID = demonEntry.Skill3;
            return dbSkills.Single(n => n.Id == skillID);
        }

        private string GetDemonRace(int demonID)
        {
            var demonEntry = dbDemon.Single(n => n.Id == demonID);
            var demonRaceId = demonEntry.Race;
            var demonRace = dbRace.Single(n => n.Id == demonRaceId);
            return demonRace.Name;
        }

        private int GetDemonLevel(int demonID)
        {
            var demonEntry = dbDemon.Single(n => n.Id == demonID);
            return demonEntry.Level;
        }

        private string GetDemonName(int demonID)
        {
            var demonEntry = dbDemon.Single(n => n.Id == demonID);
            return demonEntry.Name;
        }

        private int GetDemonHP(int demonID)
        {
            var demonEntry = dbDemonStats.Single(n => n.DemonID == demonID);
            return demonEntry.HP;
        }

        private int GetDemonMP(int demonID)
        {
            var demonEntry = dbDemonStats.Single(n => n.DemonID == demonID);
            return demonEntry.MP;
        }

        private int GetDemonCP(int demonID)
        {
            var demonEntry = dbDemonStats.Single(n => n.DemonID == demonID);
            return demonEntry.CP;
        }

        private int GetDemonStr(int demonID)
        {
            var demonEntry = dbDemonStats.Single(n => n.DemonID == demonID);
            return demonEntry.Strength;
        }

        private int GetDemonInt(int demonID)
        {
            var demonEntry = dbDemonStats.Single(n => n.DemonID == demonID);
            return demonEntry.Intelligence;
        }

        private int GetDemonMag(int demonID)
        {
            var demonEntry = dbDemonStats.Single(n => n.DemonID == demonID);
            return demonEntry.Magic;
        }

        private int GetDemonVit(int demonID)
        {
            var demonEntry = dbDemonStats.Single(n => n.DemonID == demonID);
            return demonEntry.Vitality;
        }

        private int GetDemonAgi(int demonID)
        {
            var demonEntry = dbDemonStats.Single(n => n.DemonID == demonID);
            return demonEntry.Agility;
        }

        private int GetDemonLck(int demonID)
        {
            var demonEntry = dbDemonStats.Single(n => n.DemonID == demonID);
            return demonEntry.Luck;
        }

        private int GetDemonPAtk(int demonID)
        {
            var demonEntry = dbDemonStats.Single(n => n.DemonID == demonID);
            return demonEntry.PAtk;
        }

        private int GetDemonPAccuracy(int demonID)
        {
            var demonEntry = dbDemonStats.Single(n => n.DemonID == demonID);
            return demonEntry.PHit;
        }

        private int GetDemonDefence(int demonID)
        {
            var demonEntry = dbDemonStats.Single(n => n.DemonID == demonID);
            return demonEntry.Defence;
        }

        private int GetDemonEvasion(int demonID)
        {
            var demonEntry = dbDemonStats.Single(n => n.DemonID == demonID);
            return demonEntry.Evasion;
        }

        private int GetDemonMAtk(int demonID)
        {
            var demonEntry = dbDemonStats.Single(n => n.DemonID == demonID);
            return demonEntry.MAtk;
        }

        private int GetDemonMAccuracy(int demonID)
        {
            var demonEntry = dbDemonStats.Single(n => n.DemonID == demonID);
            return demonEntry.MHit;
        }

        private string GetDemonPhysResistance(int demonID)
        {
            var demonEntry = dbDemonResists.Single(n => n.DemonID == demonID);
            return demonEntry.Phys;
        }

        private string GetDemonGunResistance(int demonID)
        {
            var demonEntry = dbDemonResists.Single(n => n.DemonID == demonID);
            return demonEntry.Gun;
        }


        private string GetDemonFireResistance(int demonID)
        {
            var demonEntry = dbDemonResists.Single(n => n.DemonID == demonID);
            return demonEntry.Fire;
        }

        private string GetDemonIceResistance(int demonID)
        {
            var demonEntry = dbDemonResists.Single(n => n.DemonID == demonID);
            return demonEntry.Ice;
        }

        private string GetDemonElecResistance(int demonID)
        {
            var demonEntry = dbDemonResists.Single(n => n.DemonID == demonID);
            return demonEntry.Elec;
        }

        private string GetDemonForceResistance(int demonID)
        {
            var demonEntry = dbDemonResists.Single(n => n.DemonID == demonID);
            return demonEntry.Force;
        }

        private string GetDemonExpelResistance(int demonID)
        {
            var demonEntry = dbDemonResists.Single(n => n.DemonID == demonID);
            return demonEntry.Expel;
        }

        private string GetDemonCurseResistance(int demonID)
        {
            var demonEntry = dbDemonResists.Single(n => n.DemonID == demonID);
            return demonEntry.Curse;
        }




    }
}
