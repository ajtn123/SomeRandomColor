using Avalonia.Input;
using Avalonia.ReactiveUI;
using CPC.ViewModels;

namespace CPC.Views;

public partial class MainWindow : ReactiveWindow<MainWindowViewModel>
{
    public MainWindow()
    {
        InitializeComponent();
        MWindow.KeyDown += SwitchVisiblityEvent;
        MWindow.PointerPressed += DragEvent;
    }
    public void SwitchVisiblityEvent(object? sender, KeyEventArgs e)
    {
        if (e.Key == Key.Space)
            ViewModel!.SwitchVisiblity();
    }
    public void DragEvent(object? sender, PointerPressedEventArgs e) { MWindow.BeginMoveDrag(e); }
}