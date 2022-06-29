using System;
using System.Threading;
using System.Windows;
using System.Windows.Input;

namespace FibonachiMultithread;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        BoxDelay.Text = _delay.ToString();
    }

    private static int _delay = 1000;
    private CancellationTokenSource? _calculateAndDisplayFibonacciCancellationTokenSource;

    private void Delay_OnKeyDown(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Enter && int.TryParse(BoxDelay.Text, out var nextDelay) && nextDelay != _delay)
        {
            Interlocked.Exchange(ref _delay, nextDelay);
        }
    }

    private void BtnStart_OnClick(object sender, RoutedEventArgs e)
    {
        Output.Text = string.Empty;
        if (!int.TryParse(BoxNumber.Text, out var number) && number < 0) return;

        if (_calculateAndDisplayFibonacciCancellationTokenSource?.IsCancellationRequested is false)
        {
            _calculateAndDisplayFibonacciCancellationTokenSource.Dispose();
        }
        _calculateAndDisplayFibonacciCancellationTokenSource = new CancellationTokenSource();

        var dto = new FibonacciDTO(number, _calculateAndDisplayFibonacciCancellationTokenSource.Token);
        Thread fibonacciThread = new(obj =>
        {
            if (obj is not FibonacciDTO fibonacciDTO) return;

            try
            {
                CalculateAndSequentiallyDisplayPositiveFibonacciNumber(fibonacciDTO.FibonacciIndex, fibonacciDTO.CancellationToken);
            }
            catch (OperationCanceledException)
            {
                Display("Calculation of fibonacci sequence was cancelled", false);
            }
        });
        fibonacciThread.Start(dto);
    }

    private void CalculateAndSequentiallyDisplayPositiveFibonacciNumber(int number, CancellationToken cancellationToken)
    {
        int num1 = 0;
        int num2 = 1;
        for (int i = 0; i <= number; i++)
        {
            int fibonacci = i;
            if (i > 1)
            {
                fibonacci = num1 + num2;
                num1 = num2;
                num2 = fibonacci;
            }

            cancellationToken.ThrowIfCancellationRequested();

            Display(fibonacci.ToString());
            Thread.Sleep(_delay);
        }
    }

    private void Display(string toDisplay, bool increment = true)
    {
        if (increment)
        {
            Application.Current.Dispatcher.Invoke(() => Output.Text += $"{toDisplay} ");
            return;
        }

        Application.Current.Dispatcher.Invoke(() => Output.Text = toDisplay);
    }

    private void BtnStop_OnClick(object sender, RoutedEventArgs e)
    {
        if (_calculateAndDisplayFibonacciCancellationTokenSource?.IsCancellationRequested is not false) return;

        _calculateAndDisplayFibonacciCancellationTokenSource.Cancel();
        _calculateAndDisplayFibonacciCancellationTokenSource.Dispose();
        _calculateAndDisplayFibonacciCancellationTokenSource = null;
    }

    private readonly struct FibonacciDTO
    {
        public FibonacciDTO(int fibonacciIndex, CancellationToken cancellationToken)
        {
            FibonacciIndex = fibonacciIndex;
            CancellationToken = cancellationToken;
        }

        public int FibonacciIndex { get; }

        public CancellationToken CancellationToken { get; }
    }
}