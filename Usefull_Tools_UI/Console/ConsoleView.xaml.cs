﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Usefull_Tools_UI.Console
{
    public sealed partial class ConsoleView : UserControl
    {

        const int maxLenght = 800;
        public string Text { get; set; }
        public ConsoleView()
        {
            this.InitializeComponent();
            ConsoleManager.consoles.Add(this);
        }

        public void WriteLine(string text)
        {
            this.Text += text + Environment.NewLine;
            if (this.Text.Length > maxLenght)
            {
                this.Text = this.Text.Substring(this.Text.Length - maxLenght);
            }

            try
            {

                ConsoleUItextBox.Text = this.Text;
                //  ConsoleUITextBoxScroll.ChangeView(ConsoleUITextBoxScroll.ScrollableHeight, 0, ConsoleUITextBoxScroll.ZoomFactor);

            }
            catch (Exception ex)
            {
                ex.Source = "ConsoleView.WriteLine (Console)";
                ErrorManager.printOut(ex);
            }
        }
        private void ConsoleUIbtReturn_Click(object sender, RoutedEventArgs e)
        {
            string comm = ConsoleUIReadBox.Text;
            Console.setNewLine(comm);
            ConsoleUIReadBox.Text = "";
        }
        public void Clear()
        {
            ConsoleUItextBox.Text = "";
        }
    }
}
