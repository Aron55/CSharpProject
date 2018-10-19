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
    ///     Interaction logic for PrinterUserControl.xaml
    /// </summary>
    public partial class PrinterUserControl : UserControl
    {
        public const double MAX_INK = 100;
        public const double MIN_ADD_INK = MAX_INK / 10.0;
        public const double MAX_PRINT_INK = MAX_INK / 8;

        public const int MAX_PAGES = 400;
        public const int MIN_ADD_PAGES = MAX_PAGES / 10;
        public const int MAX_PRINT_PAGES = MIN_ADD_PAGES / 2;

        /// <summary>
        ///     Variable to set the number of the printer Static because it's not dependent on the object itself
        /// </summary>
        public static int PrinterNum = 1;


        public static Random RPages = new Random();
        public static Random RInk = new Random();

        public double InkToPrint;
        public int PagesToPrint;


        /// <inheritdoc />
        /// <summary>
        ///     Default Ctor Initialize every printer with a different name
        /// </summary>
        public PrinterUserControl()
        {
            InitializeComponent();
            PrinterName += PrinterNum++;
            AddInk();
            AddPages();
        }

        public static double MaxPages => MAX_PAGES;

        public string PrinterName
        {
            get => (string)PrinterNameLabel.Content;
            set => PrinterNameLabel.Content = value;
        }

        public double InkCount
        {
            get => InkCountProgressBar.Value;
            set => InkCountProgressBar.Value = value;
        }

        public int PageCount
        {
            get => (int)PageCountSlider.Value;
            set => PageCountSlider.Value = value;
        }

        public void Print()
        {
            PagesToPrint = RPages.Next(MAX_PRINT_PAGES);
            InkToPrint = RInk.Next((int)MAX_PRINT_INK);
            if (PageCount < PagesToPrint)
                PageCount = 0;

            if (InkCount < InkToPrint)
                InkCount = 0;

            if (PageCount >= PagesToPrint && InkCount >= InkToPrint)
            {
                PageCount -= PagesToPrint;
                InkCount -= InkToPrint;
            }
        }

        public void AddInk()
        {
            double inkToAdd = RInk.Next((int)MIN_ADD_INK, (int)MAX_INK);
            if (inkToAdd + InkCount > MAX_INK)
                InkCount = MAX_INK;
            else
                InkCount += inkToAdd;
        }

        public void AddPages()
        {
            int pagesToAdd = RPages.Next(MIN_ADD_PAGES, MAX_PAGES);
            if (pagesToAdd + PageCount > MAX_PAGES)
                PageCount = MAX_PAGES;
            else
                PageCount += pagesToAdd;
        }

        public event EventHandler<PrintEventArgs> InkEmpty;
        public event EventHandler<PrintEventArgs> PageMissing;

        private void InkCountProgressBar_ValueChanged(object sender,
                                                      RoutedPropertyChangedEventArgs<double> e)
        {
            if (InkCount <= 15 && InkCount >= 10)
            {
                InkLabel.Foreground = Brushes.Yellow;
                if (InkEmpty != null)
                {
                    string errorMessage = "At " + DateTime.Now + "\nMessage from " + PrinterName +
                                          " : Ink only  " + InkCount + " %";
                    var tmp = new PrintEventArgs(false, errorMessage,
                                                 PrinterName); // Create the Event argument
                    InkEmpty(this, tmp); // Call to the event
                }
            }
            if (InkCount <= 10 && InkCount >= 1)
            {
                InkLabel.Foreground = Brushes.Orange;
                if (InkEmpty != null)
                {
                    string errorMessage = "At " + DateTime.Now + "\nMessage from " + PrinterName +
                                          " : Ink only  " + InkCount + " %";
                    var tmp = new PrintEventArgs(false, errorMessage,
                                                 PrinterName); // Create the Event argument
                    InkEmpty(this, tmp); // Call to the event
                }
            }
            if (InkCount < 1)
            {
                InkLabel.Foreground = Brushes.Red;
                if (InkEmpty != null)
                {
                    string errorMessage = "At " + DateTime.Now + "\nMessage from " + PrinterName +
                                          " : Ink " + InkCount + " %";
                    var tmp = new PrintEventArgs(true, errorMessage, PrinterName);
                    InkEmpty(this, tmp); // Call to the event
                }
            }
            if (InkCount > 15)
                InkLabel.Foreground = Brushes.Black;
        }

        private void PageCountSlider_ValueChanged(object sender,
                                                  RoutedPropertyChangedEventArgs<double> e)
        {
            // Declenching the event
            if (PageCount == 0)
            {
                PageLabel.Foreground = Brushes.Red;

                if (PageMissing != null)
                {
                    string errorMessage = "At " + DateTime.Now + "\nMessage from " + PrinterName +
                                          " : Missing " + (PagesToPrint - PageCount) + " pages";
                    var tmp = new PrintEventArgs(true, errorMessage,
                                                 PrinterName); // Create the Event                                                                  argument
                    PageMissing(this, tmp); // Call to the event
                }
            }
            else
            {
                PageLabel.Foreground = Brushes.Black;
            }
        }

        private void PrinterNameLabel_MouseEnter(object sender, MouseEventArgs e)
        {
            PrinterNameLabel.FontSize = 25;
        }

        private void PrinterNameLabel_MouseLeave(object sender, MouseEventArgs e)
        {
            PrinterNameLabel.FontSize = 16;
        }
    }
}