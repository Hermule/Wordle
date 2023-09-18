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

namespace Wordle
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private int columns;
        private int row;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void btn4Letters_Click(object sender, RoutedEventArgs e)
        {
            ClearButtons();
            columns = 4;
            row = 2;
            AddGrid(columns, row);
            row++;
            btnGuess.Visibility = Visibility.Visible;
            return;
        }

        private void btn5Letters_Click(object sender, RoutedEventArgs e)
        {
            ClearButtons();
            columns = 5;
            row = 2;
            AddGrid(columns, row);
            row++;
            btnGuess.Visibility = Visibility.Visible;
            return;
        }

        private void btn6Letters_Click(object sender, RoutedEventArgs e)
        {
            ClearButtons();
            columns = 6;
            row = 2;
            AddGrid(columns, row);
            row++;
            btnGuess.Visibility = Visibility.Visible;
            return;
        }

        private void btn7Letters_Click(object sender, RoutedEventArgs e)
        {
            ClearButtons();
            columns = 7;
            row = 2;
            AddGrid(columns, row);
            row++;
            btnGuess.Visibility = Visibility.Visible;

            return;
        }

        private void btn8Letters_Click(object sender, RoutedEventArgs e)
        {
            ClearButtons();
            columns = 8;
            row = 2;
            AddGrid(columns, row);
            row++;
            btnGuess.Visibility = Visibility.Visible;

            return;
        }

        private void AddGrid(int columns, int row)
        {
            Grid grid = new Grid()
            {
                Name = $"grid{row}"
            };
            gridAll.Children.Add(grid);
            Grid.SetRow(grid, row);
            Grid.SetColumn(grid, 1);
            Grid.SetColumnSpan(grid, 3);
            gridAll.RowDefinitions[row].Height = new GridLength(1, GridUnitType.Star);

            grid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) });
            for (int i = 0; i < columns; i++)
            {
                grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
                Viewbox viewbox = new Viewbox();
                grid.Children.Add(viewbox);
                Grid.SetColumn(viewbox, i);
                Grid.SetRow(viewbox, 0);

                TextBox textBox = new TextBox()
                {
                    Text = $"",
                    HorizontalContentAlignment = HorizontalAlignment.Center,
                    Width = 15
                };
                viewbox.Child = textBox;
            }

            
            
        }

        private void ClearLabels()
        {
            List<Grid> gridsToDelete = new List<Grid>();
            foreach (Grid grid in gridAll.Children.OfType<Grid>())
            {
                if (grid.Name != "gridButtons")
                {
                    gridsToDelete.Add(grid);
                }
            }
            foreach (Grid grid in gridsToDelete)
            {
                gridAll.Children.Remove(grid);
            }
            ShowButtons();

            for (int i = 3; i < 7; i++) { gridAll.RowDefinitions[i].Height = new GridLength(1, GridUnitType.Auto); }
            btnGuess.Visibility = Visibility.Hidden;

        }

        private void ClearButtons()
        {
            foreach (UIElement element in gridButtons.Children)
            {
                element.Visibility = Visibility.Collapsed;
            }
            btnGuess.Visibility = Visibility.Hidden;
        }

        private void ShowButtons()
        {
            foreach (UIElement element in gridButtons.Children)
            {
                element.Visibility = Visibility.Visible;
            }
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            ClearLabels();
        }

        private void btnGuess_Click(object sender, RoutedEventArgs e)
        {
            AddGrid(columns, row);
            row++;
        }
    }
}
