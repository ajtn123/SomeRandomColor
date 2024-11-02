using Avalonia.Input;
using CPC.Models;
using ReactiveUI;
using System;
using System.Windows.Input;

namespace CPC.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private Color color;
    private string input;
    private bool controlVisiblity = true;

    public MainWindowViewModel()
    {
        RandomCommand = ReactiveCommand.Create(() => { Color = new(); Input = Color.S; });
        CompleteCommand = ReactiveCommand.Create(() => Color = new(Input));
        color = new Color();
        input = Color.S;
    }
    public void SwitchVisiblity()
    {
        ControlVisiblity = !ControlVisiblity;
    }
    public Color Color { get => color; set => this.RaiseAndSetIfChanged(ref color, value); }
    public ICommand RandomCommand { get; }
    public ICommand CompleteCommand { get; }
    public string Input { get => input; set => this.RaiseAndSetIfChanged(ref input, value); }
    public int WindowWidth { get; set; } = 800;
    public int WindowHeight { get; set; } = 400;
    public bool ControlVisiblity { get => controlVisiblity; set => this.RaiseAndSetIfChanged(ref controlVisiblity, value); }
}
