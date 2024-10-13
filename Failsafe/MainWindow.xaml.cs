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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Failsafe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Switch switch_;
        /// <summary>
        /// инициализация
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            switch_ = new Switch();
        }
        /// <summary>
        /// Обработчик для кнопки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TxtBox.Text = "";
            // отключение генератора
            try
            {
                switch_.DisconnectPowerGenerator();
            }
            catch (Exception ex)
            {
                TxtBox.Text += $"Ошибка связи с генератором: {ex}\n";
            }
            // проверка основнйо системы охлаждения
            try
            {
                switch_.VerifyBackupCoolantSystem();
            }
            catch (CoolantTemperatureReadException ex)
            {
                TxtBox.Text += $"Ошибка чтения температуры: {ex}\n";
            }
            catch (CoolantPressureReadException ex) 
            {
                TxtBox.Text += $"Ошибка чтения давления: {ex}\n";
            }
            // Втавка управляющих стержней
            try
            {
                switch_.InsertRodCluster();
            }
            catch (RodClusterReleaseException ex)
            {
                TxtBox.Text += $"Ошибка освобождения стержней: {ex}\n";
            }
            // Завершенение отключение
            try
            {
                switch_.SignalShutdownComplete();
            }
            catch (Exception ex)
            {
                TxtBox.Text += $"Ошибка завершающего сигнала: {ex}\n";
            }
        }
    }
}
