using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Http;
using Avalonia.Collections;
using DynamicData;
using Breweries.Models;
using Breweries.Views;
using ReactiveUI;
using Tmds.DBus;
using Image = Avalonia.Controls.Image;

namespace Breweries.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        // Стандартные настройки для приложения
        public string NameProgram => "Breweries"; // Название проекта

        public string ThemaProgram => "Dark";
        public string BackgroundProgram => "#3C4041"; // Цвет фона для приложения
        public string ForegroundLetters => "#FFFFFF"; // Цвет текса в программе

        public readonly List<breweries> Results = new List<breweries>();

    }
}