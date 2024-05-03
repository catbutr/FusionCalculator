using FusionCalculator.Database.Tables;
using FusionCalculator.Resources.Constants;
using SQLite;

namespace FusionCalculator.Database
{
    public class FusionDatabaseRepository
    {
        public SQLiteConnection Database { get; set; }

        public FusionDatabaseRepository()
        {
            Database = new SQLiteConnection(Constants.DatabasePath);
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

    }
}
