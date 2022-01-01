using System.Windows;
using System.Windows.Controls;

namespace WPF_APP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        protected override void OnRenderSizeChanged(SizeChangedInfo sizeInfo)
        {
            base.OnRenderSizeChanged(sizeInfo);
            if(this.Width >500)
            {
                _inputStack.Orientation = Orientation.Horizontal;
            }
            else
            {
                _inputStack.Orientation = Orientation.Vertical;
            }
        }

    }
}
