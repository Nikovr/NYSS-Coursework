using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace Vigenere_Cipher
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Save_Text_Button_Click(object sender, RoutedEventArgs e)
        {
            waitmessage.Visibility = Visibility.Visible;
            FileManagement.Save(text.Text);
            waitmessage.Visibility = Visibility.Hidden;
        }
        private void Upload_Text_Button_Click(object sender, RoutedEventArgs e)
        {
            waitmessage.Visibility = Visibility.Visible;
            text.Text = FileManagement.Upload();
            hasBeenClicked = true;
            waitmessage.Visibility = Visibility.Hidden;
        }
        private void Return_Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Preview_Key_Input(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !KeyIsValid(((TextBox)sender).Text + e.Text);
        }
        private static bool KeyIsValid(string str)
        {
            return Regex.IsMatch(str, "^[А-Яа-яЁё]+$");
        }

        bool hasBeenClicked = false;

        private void TextBox_Focus(object sender, RoutedEventArgs e)
        {
            if (!hasBeenClicked)
            {
                TextBox box = sender as TextBox;
                box.Text = String.Empty;
                hasBeenClicked = true;
            }
        }

        private void Encrypt_Button_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(key.Text))
            {
                text.Text = VigenereCipher.Encrypt(text.Text, key.Text);
            }
        }

        private void Decrypt_Button_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(key.Text))
            {
                text.Text = VigenereCipher.Decrypt(text.Text, key.Text);
            }
        }

        private void Key_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }
    }
}
