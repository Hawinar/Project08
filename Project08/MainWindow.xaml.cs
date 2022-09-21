using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Project08
{
    /// <summary>
    /// 3.4	Лабораторная работа № 4. Тема: «Отладка и тестирование ПС» Вариант №22 https://github.com/Hawinar
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataGridTextColumn c1 = new DataGridTextColumn();
            c1.Header = "λ";
            c1.Width = 50;
            c1.Binding = new Binding("Lambda");
            dgResult.Columns.Add(c1);
            DataGridTextColumn c2 = new DataGridTextColumn();
            c2.Header = "Интеграл н/п";
            c2.Width = 150;
            c2.Binding = new Binding("IntegralPi");
            dgResult.Columns.Add(c2);
            DataGridTextColumn c3 = new DataGridTextColumn();
            c3.Header = "Интеграл в/п";
            c3.Width = 150;
            c3.Binding = new Binding("IntegralInfinity");
            dgResult.Columns.Add(c3);
        }

        private void btCompute_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int lambda = int.Parse(tbLambda1.Text);
                int limit = int.Parse(tbLambda2.Text);
                if (lambda >= 0 && limit >= 0)
                {
                    int pi = 0;
                    int infinity = 1;
                    int x = pi;
                
                    double toNegative = -1;

                    string integralSTR = string.Empty;
                    string integralPi = string.Empty;
                    string integralInfinity = string.Empty;

                    double half = 0.5;

                    double upper = 1 - lambda;

                    double lower = 1 + lambda;

                    int step = int.Parse(tbStep.Text);

                    for (double j = lambda; j <= limit; j += step)
                    {
                        upper = 1 - j;
                        lower = 1 + j;
                        string upperSTR = Math.Sqrt(upper * toNegative).ToString();
                        string lowerSTR = Math.Sqrt(lower).ToString();

                        if (lowerSTR.Contains(",") == false)
                        {
                            integralSTR = "√(" + Math.Abs(upper) + ")" + " * i * " + $"x/{Math.Sqrt(lower)}";
                            integralPi = $"F({x}) = √(" + Math.Abs(upper) + ")" + " * i * " + $"{x}/{Math.Sqrt(lower)}";
                            if (x == 0)
                                integralPi = $"F({x}) = 0";
                            x = infinity;
                            integralInfinity = $"F({x}) = √(" + Math.Abs(upper) + ")" + " * i * " + $"{x}/{Math.Sqrt(lower)}";
                            if (x == 0)
                                integralInfinity = $"F({x}) = 0";
                            x = pi;

                            dgResult.Items.Add(new Data { Lambda = j.ToString(), IntegralPi = integralPi, IntegralInfinity = integralInfinity });
                        }
                        if (upperSTR.Contains(",") == false)
                        {
                            integralSTR = $"{Math.Sqrt(upper * toNegative)}√{lower}" + " * i * " + $"x/{lower}";
                            integralPi = $"F({x}) = √({lower} * i * x/{lower * half}";
                            if (x == 0)
                                integralPi = $"F({x}) = 0";
                            x = infinity;
                            integralInfinity = $"F({x}) = √({lower} * i * x/{lower * half}";
                            if (x == 0)
                                integralInfinity = $"F({x}) = 0";
                            x = pi;

                            dgResult.Items.Add(new Data { Lambda = j.ToString(), IntegralPi = integralPi, IntegralInfinity = integralInfinity });
                        }
                        else
                        {
                            integralSTR = "√(" + Math.Abs(upper * lower) + $") * i * x/{lower}";
                            integralPi = "√(" + Math.Abs(upper * lower) + $") * i * {x}/{lower}"; ;
                            if (x == 0)
                                integralPi = $"F({x}) = 0";
                            x = infinity;
                            integralInfinity = "√(" + Math.Abs(upper * lower) + $") * i * {x}/{lower}";
                            if (x == 0)
                                integralInfinity = $"F({x}) = 0";
                            x = pi;

                            dgResult.Items.Add(new Data { Lambda = j.ToString(), IntegralPi = integralPi, IntegralInfinity = integralInfinity });
                        }

                    }
                }
                else
                {
                    MessageBox.Show("Убедитесь что все поля заполнены, а числа в них целочисленны и положительны");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Убедитесь что все поля заполнены, а числа в них целочисленны и положительны");
            }


        }
    }
    public class Data
    {
        public string Lambda { get; set; }
        public string IntegralPi { get; set; }
        public string IntegralInfinity { get; set; }
    }
}
