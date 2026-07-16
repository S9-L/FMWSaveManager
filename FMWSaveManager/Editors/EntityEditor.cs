using FMWSaveManager.FileFormats;
using System.ComponentModel;
using System.Windows.Forms;

namespace FMWSaveManager.Editors
{
    public partial class EntityEditor : UserControl
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public UnitData UnitData { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public CharData CharData { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public UnitEditor UEditor { get { return unitEditor1; } set { unitEditor1 = value; } }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public CharEditor CEditor { get { return charEditor1; } set { charEditor1 = value; } }


        public EntityEditor()
        {
            InitializeComponent();
        }

        public void init()
        {
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.UserPaint, true);
        }
    }
}
