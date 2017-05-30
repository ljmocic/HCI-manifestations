using HCI_Manifestations.Help;
using HCI_Manifestations.Models;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace HCI_Manifestations.dialogs
{
    public partial class AddTag : Window
    {
        #region Attributes
        private ManifestationTag tag;
        public ManifestationTag mTag // Tag name Overshadows Tag from .NET library
        {
            get { return tag; }
            set { tag = value; }
        }

        private bool idError;
        private bool descriptionError;
        #endregion

        #region Constructors
        public AddTag()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;

            tag = new ManifestationTag();
            DataContext = tag;

            idError = false;
            descriptionError = false;
        }

        public AddTag(string id)
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;

            tag = new ManifestationTag();
            tag.Id = id;
            DataContext = tag;

            idError = false;
            descriptionError = false;
        }
        #endregion

        #region Event handlers
        private void ColorPicker_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            tag.Color = ColorPicker.SelectedColor.ToString();
        }

        private void buttonSave_Click(object sender, RoutedEventArgs e)
        {
            idError = false; descriptionError = false;
            textBoxId.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            textBoxDescription.GetBindingExpression(TextBox.TextProperty).UpdateSource();

            if (idError == false && descriptionError == false)
            {
                Database.AddTag(mTag);
                DialogResult = true;
                Close();
            }
        }

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void textBoxId_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
                idError = true;
        }

        private void textBoxDescription_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
                descriptionError = true;
        }

        private void textBoxId_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (textBoxId.Text.Length > 0)
                buttonSave.IsEnabled = true;
            else
                buttonSave.IsEnabled = false;
        }

        private void Help_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            HelpProvider.ShowHelp("Tag", this);
        }
        #endregion
    }
}
