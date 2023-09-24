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

        private void btnLetters_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            ClearButtons();
            columns = int.Parse(button.Content.ToString()[..1]);
            row = 2;
            AddGrid(columns, row);
            row++;
            ChangeMainText(columns);
            btnGuess.Visibility = Visibility.Visible;
            return;
        }

        private void ChangeMainText(int columns)
        {
            if (columns != 8)
            {
                lblMain.Content = $"Guess a {columns} letter word";
                return;
            }
            lblMain.Content = $"Guess an {columns} letter word";
        }

        private void ChangeMainText(string letter)
        {
            lblMain.Content = $"Guess an {letter} letter word";
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
            gridAll.RowDefinitions[row].Height = new GridLength(1, GridUnitType.Auto);

            grid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Auto) });
            for (int i = 0; i < columns; i++)
            {
                grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });

                TextBox textBox = new TextBox()
                {
                    Text = $"",
                    HorizontalContentAlignment = HorizontalAlignment.Center,
                    Width = gridAll.Width / (columns + 2),
                    Height = gridAll.Height / 6,
                };
                grid.Children.Add(textBox);
                Grid.SetColumn(textBox, i);
                Grid.SetRow(textBox, 0);
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
            ChangeMainText("x");

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
