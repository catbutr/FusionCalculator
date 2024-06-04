using FusionCalculator.Database.Tables;
using FusionCalculator.Resources.Constants;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }

        private string GetDemonRace(int demonID)
        {
            var dbRace = Database.Table<Race>();
            var demonRace = dbRace.Single(n => n.Id == demonID);
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




    }
}
