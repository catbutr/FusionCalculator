using FusionCalculator.Database.Tables;
using FusionCalculator.Resources.Constants;
using FusionCalculator.Utils;
using SQLite;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FusionCalculator.Database
{
    public class FusionDatabaseRepository:INotifyPropertyChanged
    {
        public SQLiteConnection Database { get; set; }

        private List<string> _skillNames = [];

        private List<string> _skillElements = [];

        private ObservableCollection<Skill> _skills = [];

        public List<string> SkillElements
        {
            get => _skillElements;
            set
            {
                _skillElements = value;
                OnPropertyChanged();
            }
        }

        public List<string> SkillNames
        {
            get => _skillNames;
            set
            {
                _skillNames = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Skill> Skills
        {
            get => _skills;
            set
            {
                _skills = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public FusionDatabaseRepository()
        {
            Database = new SQLiteConnection(Path.Combine(FileSystem.Current.AppDataDirectory, "FusionData.db"));
            Skills = GetSkills();
        }

        public void AddSkil()
        {
            Database.Insert(new Skill()
            {
                Name = "Blood Thief",
                Element = "Death",
                Power = 9,
                Target = "1 Foe"
            });
        }

        private ObservableCollection<Skill> GetSkills()
        {
            var dbSkills = Database.Table<Skill>();
            var skills = new ObservableCollection<Skill>();
            foreach (var skill in dbSkills)
            {
                var newSkill = new Skill
                {
                    Name = skill.Name,
                    Element = skill.Element,
                    Power = skill.Power,
                    Target = skill.Target,
                    Effect = skill.Effect,
                    Cost = skill.Cost
                };
                skills.Add(newSkill);
            }
            return skills;
        }

        public List<string> GetElements()
        {
            var skills = Database.Table<Skill>();
            var elements = new List<string>();
            foreach (var skill in skills)
            {
                elements.Add(skill.Element);
            }
            return elements;
        }

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
