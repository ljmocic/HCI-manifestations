﻿using HCI_Manifestations.Models;
using System;
using System.Collections.Generic;
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
        #endregion

        #region Constructors
        public AddTag()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;

            tag = new ManifestationTag();
            DataContext = tag;
        }
        #endregion

        #region Event handlers
        private void buttonSave_Click(object sender, RoutedEventArgs e)
        {
            // TODO validation later
            bool validated = true;
            if (validated)
            {
                Database.AddTag(mTag);
                Close();
            }
            else
            {
                // If data is not validated
            }

        }

        private void ColorPicker_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            tag.Color = ColorPicker.SelectedColor.ToString();
        }
        #endregion
    }
}
