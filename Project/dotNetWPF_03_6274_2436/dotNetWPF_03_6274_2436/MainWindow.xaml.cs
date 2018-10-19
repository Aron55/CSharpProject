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

namespace dotNetWPF_03_6274_2436
{
    /// <inheritdoc>
    ///     <cref></cref>
    /// </inheritdoc>
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public PrinterUserControl CurrentPrinter;
        public Queue<PrinterUserControl> Queue;

        public MainWindow()
        {
            InitializeComponent();
            InitializeQueue();
            EventSubscribe();
        }

        public void InitializeQueue()
        {
            Queue = new Queue<PrinterUserControl>();
            foreach (Control p in PrintersGrid.Children)
                if (p is PrinterUserControl)
                {
                    var printer = p as PrinterUserControl;
                    Queue.Enqueue(printer);
                }

            CurrentPrinter = Queue.Dequeue();
        }

        private void EventSubscribe()
        {
            foreach (Control p in PrintersGrid.Children)
                if (p is PrinterUserControl)
                {
                    var printer = p as PrinterUserControl;
                    printer.PageMissing += CurrentPrinter_PagesEmpty;
                    printer.InkEmpty += CurrentPrinter_InkEmpty;
                }
        }

        private void PrintButton_Click(object sender, RoutedEventArgs e)
        {
            CurrentPrinter.Print();
        }

        public void CurrentPrinter_InkEmpty(object sender, PrintEventArgs e)
        {
            if (e.CriticalEvent)
            {
                MessageBox.Show(e.MessageEvent, "Critical Error from : " + CurrentPrinter.PrinterName, MessageBoxButton.OK,MessageBoxImage.Error);
                CurrentPrinter.AddInk();
                Queue.Enqueue(CurrentPrinter);
                CurrentPrinter = Queue.Dequeue();
            }

            else
            {
                MessageBox.Show(e.MessageEvent, "Warning from : "+CurrentPrinter.PrinterName, MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        public void CurrentPrinter_PagesEmpty(object sender, PrintEventArgs e)
        {
            MessageBox.Show(e.MessageEvent, "Critical Error from : " + CurrentPrinter.PrinterName,
                            MessageBoxButton.OK, MessageBoxImage.Error);
            CurrentPrinter.AddPages();
            Queue.Enqueue(CurrentPrinter);
            CurrentPrinter = Queue.Dequeue();
        }
    }
}