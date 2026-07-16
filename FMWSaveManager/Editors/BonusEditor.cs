using FMWSaveManager.FileFormats;
using System.ComponentModel;
using System.Windows.Forms;

namespace FMWSaveManager.Editors
{
    public partial class BonusEditor : UserControl
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public BonusStats BonusStats { get; set; }
        public BonusEditor()
        {
            InitializeComponent();
        }

        public void init()
        {
            DamageDealtInc.DataBindings.Clear();
            DamageDealtInc.DataBindings.Add("Value", BonusStats, "MaxDamageDealt", false, DataSourceUpdateMode.OnPropertyChanged);

            DamageTakenInc.DataBindings.Clear();
            DamageTakenInc.DataBindings.Add("Value", BonusStats, "MaxDamageTaken", false, DataSourceUpdateMode.OnPropertyChanged);

            DealtTextBox.DataBindings.Clear();
            DealtTextBox.DataBindings.Add("Text", BonusStats, "MaxDamageDealtDetails", false, DataSourceUpdateMode.OnPropertyChanged);

            TakenTextBox.DataBindings.Clear();
            TakenTextBox.DataBindings.Add("Text", BonusStats, "MaxDamageTakenDetails", false, DataSourceUpdateMode.OnPropertyChanged);

            VegetablesInc.DataBindings.Clear();
            VegetablesInc.DataBindings.Add("Text", BonusStats, "Vegetables", false, DataSourceUpdateMode.OnPropertyChanged);

            PhotosInc.DataBindings.Clear();
            PhotosInc.DataBindings.Add("Text", BonusStats, "ShootTheBullet", false, DataSourceUpdateMode.OnPropertyChanged);

            DreamsInc.DataBindings.Clear();
            DreamsInc.DataBindings.Add("Text", BonusStats, "DreamSpirits", false, DataSourceUpdateMode.OnPropertyChanged);

            FansInc.DataBindings.Clear();
            FansInc.DataBindings.Add("Text", BonusStats, "ToyoFan", false, DataSourceUpdateMode.OnPropertyChanged);

            SheepCountersInc.DataBindings.Clear();
            SheepCountersInc.DataBindings.Add("Text", BonusStats, "MeekoSheepCount", false, DataSourceUpdateMode.OnPropertyChanged);

            SweetDreamsInc.DataBindings.Clear();
            SweetDreamsInc.DataBindings.Add("Text", BonusStats, "MakuraSweetDreams", false, DataSourceUpdateMode.OnPropertyChanged);

            AkyuInc.DataBindings.Clear();
            AkyuInc.DataBindings.Add("Text", BonusStats, "AkyuPoints", false, DataSourceUpdateMode.OnPropertyChanged);

            LilyInc.DataBindings.Clear();
            LilyInc.DataBindings.Add("Text", BonusStats, "LilyPoints", false, DataSourceUpdateMode.OnPropertyChanged);
        }
    }
}
