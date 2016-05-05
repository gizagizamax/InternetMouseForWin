using InternetMouse.Model;
using System;
using System.Windows;

namespace InternetMouse
{
    public partial class MainWindow : Window
    {
        ModelAws model;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.Coonect();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                this.model.EndReceiveMessage();
            }
            catch (Exception)
            {
            }
        }

        private void btnConnect_Click(object sender, RoutedEventArgs e)
        {
            this.Coonect();
        }

        private void btnDisconnect_Click(object sender, RoutedEventArgs e)
        {
            this.model.EndReceiveMessage();
        }

        void Coonect()
        {
            this.model = new ModelAws()
            {
                TextBoxId = this.TextBoxId,
                PasswordBoxPassword = this.PasswordBoxPassword,
                ButtonConnect = this.ButtonConnect,
                ButtonDisconnect = this.ButtonDisconnect,
                TextBoxLog = this.TextBoxLog
            };

            this.model.CreateQueue();
        }
    }
}
