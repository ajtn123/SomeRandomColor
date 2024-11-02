using System;
using System.Collections.Generic;
using System.Linq;

namespace CPC.Models;

public class Color
{
    public int A { get; }
    public int R { get; }
    public int G { get; }
    public int B { get; }
    public string SA => hex[A / 16] + hex[A % 16];
    public string SR => hex[R / 16] + hex[R % 16];
    public string SG => hex[G / 16] + hex[G % 16];
    public string SB => hex[B / 16] + hex[B % 16];
    public string SS => $"#{SA}{SR}{SG}{SB}";
    public string S => $"{SA}{SR}{SG}{SB}";
    private readonly List<string> hex = ["0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F"];

    public Color()
    {
        A = 255;
        R = Random.Next(0, 256);
        G = Random.Next(0, 256);
        B = Random.Next(0, 256);
    }
    public Color(string value)
    {
        var s = value.ToUpper();
        if (s.All(a => hex.Any(b => b == a.ToString())))
            switch (s.Length)
            {
                case 3:
                    A = 255;
                    R = hex.IndexOf(s[0].ToString()) * 17;
                    G = hex.IndexOf(s[1].ToString()) * 17;
                    B = hex.IndexOf(s[2].ToString()) * 17;
                    break;
                case 4:
                    A = hex.IndexOf(s[0].ToString()) * 17;
                    R = hex.IndexOf(s[1].ToString()) * 17;
                    G = hex.IndexOf(s[2].ToString()) * 17;
                    B = hex.IndexOf(s[3].ToString()) * 17;
                    break;
                case 6:
                    A = 255;
                    R = hex.IndexOf(s[0].ToString()) * 16 + hex.IndexOf(s[1].ToString());
                    G = hex.IndexOf(s[2].ToString()) * 16 + hex.IndexOf(s[3].ToString());
                    B = hex.IndexOf(s[4].ToString()) * 16 + hex.IndexOf(s[5].ToString());
                    break;
                case 8:
                    A = hex.IndexOf(s[0].ToString()) * 16 + hex.IndexOf(s[1].ToString());
                    R = hex.IndexOf(s[2].ToString()) * 16 + hex.IndexOf(s[3].ToString());
                    G = hex.IndexOf(s[4].ToString()) * 16 + hex.IndexOf(s[5].ToString());
                    B = hex.IndexOf(s[6].ToString()) * 16 + hex.IndexOf(s[7].ToString());
                    break;
                default:
                    A = 255;
                    R = 255;
                    G = 255;
                    B = 255;
                    break;
            }
        else
        {
            A = 255;
            R = 255;
            G = 255;
            B = 255;
        }
    }

    private Random Random { get; } = new();
}
