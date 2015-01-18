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
using ElyseGUI.ViewModels;
using System.ComponentModel;

namespace ElyseGUI
{
    /// <summary>
    /// Désolé pour le pattern MVVM :/
    /// </summary>
    public partial class StoryBookWindow : Window
    {
        private OnStoryBookClose _onClose;
        private OnStoryBookChange _onChange;

        public StoryBookWindow(OnStoryBookChange onChange, OnStoryBookClose onClose)
        {
            InitializeComponent();
            _onClose = onClose;
            _onChange = onChange;
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            _onClose();
        }

        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var textBlock = (TextBlock)sender;
            _onChange(textBlock.Text);
        }
    }
}
