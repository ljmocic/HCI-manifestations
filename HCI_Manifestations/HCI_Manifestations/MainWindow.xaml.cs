using HCI_Manifestations.dialogs;
using HCI_Manifestations.Dialogs;
using HCI_Manifestations.Help;
using HCI_Manifestations.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HCI_Manifestations
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        #region Attributes
        private ObservableCollection<Manifestation> manifestations;
        public ObservableCollection<Manifestation> Manifestations
        {
            get { return manifestations; }
            set
            {
                if (value != manifestations)
                {
                    manifestations = value;
                    OnPropertyChanged("Manifestations");
                }
            }
        }
        
        private Manifestation ClickedManifestation;

        private Point startPoint = new Point();
        #endregion

        #region PropertyChangedNotifier
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        #endregion

        #region Constructors
        public MainWindow()
        {
            InitializeComponent();
            Database.loadData();

            DataContext = this;
            Manifestations = Database.getInstance().Manifestations;
            ManifestationPins_Draw();

            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }
        #endregion

        #region Commands
        private void AddManifestation_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            AddManifestation addManifestation = new AddManifestation();
            addManifestation.Show();
        }

        private void ShowManifestations_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            ShowManifestations showManifestations = new ShowManifestations();
            showManifestations.Show();
        }

        private void AddType_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            AddType addType = new AddType();
            addType.Show();
        }

        private void ShowTypes_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            ShowTypes showTypes = new ShowTypes();
            showTypes.Show();
        }

        private void AddTag_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            AddTag addTag = new AddTag();
            addTag.Show();
        }

        private void ShowTags_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            ShowTags showTags = new ShowTags();
            showTags.Show();
        }
        #endregion

        #region Drag and Drop
        private void Map_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Point mousePosition = e.GetPosition(Map);
            ClickedManifestation = Manifestation_Click((int)mousePosition.X, (int)mousePosition.Y);
            if (e.ChangedButton == MouseButton.Left && e.ClickCount == 2)
            {
                if (ClickedManifestation != null)
                {
                    EditManifestation edit = new EditManifestation(ClickedManifestation.Id);
                    edit.Show();
                }
            }
        }

        private void Map_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            Point mousePosition = e.GetPosition(Map);
            ClickedManifestation = Manifestation_Click((int)mousePosition.X, (int)mousePosition.Y);

            if (ClickedManifestation != null)
            {
                var Map = sender as Canvas;
                Map.ContextMenu.IsOpen = true;
            }
        }

        private void Map_MouseMove(object sender, MouseEventArgs e)
        {
            Point mousePosition = e.GetPosition(Map);
            Vector diff = startPoint - mousePosition;

            if (e.LeftButton == MouseButtonState.Pressed &&
                (Math.Abs(diff.X) > SystemParameters.MinimumHorizontalDragDistance ||
                Math.Abs(diff.Y) > SystemParameters.MinimumVerticalDragDistance))
            {
                Manifestation manifestation = Manifestation_Click((int)mousePosition.X, (int)mousePosition.Y);

                if (manifestation != null)
                {
                    DataObject dragData = new DataObject("manifestation", manifestation);
                    DragDrop.DoDragDrop(Map, dragData, DragDropEffects.Move);
                }
            }
        }

        private void Map_DragEnter(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent("manifestation") || sender == e.Source)
            {
                e.Effects = DragDropEffects.None;
            }
        }

        private void Map_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("manifestation"))
            {
                Point dropPosition = e.GetPosition(Map);
                Manifestation manifestationPin = e.Data.GetData("manifestation") as Manifestation;

                if (Manifestation_Click((int)dropPosition.X, (int)dropPosition.Y) != null)
                {
                    manifestationPin.X = (int)dropPosition.X - 48;
                    manifestationPin.Y = (int)dropPosition.Y - 48;
                }
                else
                {
                    manifestationPin.X = (int)dropPosition.X - 16;
                    manifestationPin.Y = (int)dropPosition.Y - 16;
                }
                Database.UpdateManifestation(manifestationPin.Id, manifestationPin);
                ManifestationPins_Draw();
            }
        }

        private void ListView_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            startPoint = e.GetPosition(null);
        }

        private void ListView_MouseMove(object sender, MouseEventArgs e)
        {
            Point mousePosition = e.GetPosition(null);
            Vector diff = startPoint - mousePosition;

            if (e.LeftButton == MouseButtonState.Pressed &&
                (Math.Abs(diff.X) > SystemParameters.MinimumHorizontalDragDistance ||
                Math.Abs(diff.Y) > SystemParameters.MinimumVerticalDragDistance))
            {
                ListView listView = sender as ListView;
                ListViewItem listViewItem = FindAncestor<ListViewItem>((DependencyObject)e.OriginalSource);
                
                if (listViewItem != null)
                {
                    Manifestation manifestation = (Manifestation)listView.ItemContainerGenerator.ItemFromContainer(listViewItem);
                    DataObject dragData = new DataObject("manifestation", manifestation);
                    DragDrop.DoDragDrop(listViewItem, dragData, DragDropEffects.Move);
                }
            }
        }

        private static T FindAncestor<T>(DependencyObject current) where T : DependencyObject
        {
            do
            {
                if (current is T)
                {
                    return (T)current;
                }
                current = VisualTreeHelper.GetParent(current);
            }
            while (current != null);
            return null;
        }
        #endregion

        #region Events
        private Manifestation Manifestation_Click(int x, int y)
        {
            foreach (Manifestation manifestation in Manifestations)
            {
                if (manifestation.X != -1 && manifestation.Y != -1)
                {
                    if (Math.Sqrt(Math.Pow((x - manifestation.X - 16), 2) + Math.Pow((y - manifestation.Y - 16), 2)) < 20)
                    {
                        return manifestation;
                    }
                }
            }
            return null;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult messageBoxResult = MessageBox.Show("Da li ste sigurni?", "Potvrda zatvaranja aplikacije", MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.No)
            {
                e.Cancel = true;

            }
        }

        private void Help_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            IInputElement focusedControl = FocusManager.GetFocusedElement(this);
            if (focusedControl is DependencyObject)
            {
                string str = HelpProvider.GetHelpKey((DependencyObject)focusedControl);
                HelpProvider.ShowHelp(str, this);
            }
            else
            {
                HelpProvider.ShowHelp(GetType().Name, this);
            }
        }

        private void ManifestationPins_Draw()
        {
            Map.Children.Clear();
            foreach (Manifestation manifestation in Manifestations)
            {
                if (manifestation.X != -1 && manifestation.Y != -1)
                {
                    Image ManifestationIcon = new Image();
                    ManifestationIcon.Width = 32;
                    ManifestationIcon.Height = 32;
                    ManifestationIcon.Name = manifestation.Id;
                    ManifestationIcon.ToolTip = manifestation.Id + " " + manifestation.Name;
                    ManifestationIcon.Source = new BitmapImage(new Uri(manifestation.IconPath, UriKind.Absolute));

                    Map.Children.Add(ManifestationIcon);

                    Canvas.SetLeft(ManifestationIcon, manifestation.X);
                    Canvas.SetTop(ManifestationIcon, manifestation.Y);
                }
            }
        }
        #endregion

        #region Context Menu Actions
        private void UpdateManifestation_Click(object sender, RoutedEventArgs e)
        {
            EditManifestation edit = new EditManifestation(ClickedManifestation.Id);
            edit.Show();
        }

        private void DeleteManifestation_Click(object sender, RoutedEventArgs e)
        {
            Database.DeleteManifestation(ClickedManifestation);
            ManifestationPins_Draw();
        }

        private void RemoveManifestationIcon_Click(object sender, RoutedEventArgs e)
        {
            ClickedManifestation.X = -1;
            ClickedManifestation.Y = -1;
            Database.SaveManifestations();
            ManifestationPins_Draw();
        }
        #endregion
    }
}
