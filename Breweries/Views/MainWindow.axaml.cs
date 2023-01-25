using Avalonia.Controls;
using Avalonia.Interactivity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices.ObjectiveC;
using Avalonia.Themes.Default;
using Avalonia.Themes.Fluent;
using Avalonia.Themes.Fluent.Controls;
using Breweries.Models;
using Breweries.ViewModels;
using Newtonsoft.Json;
using ReactiveUI;
using Tmds.DBus;
using System.Drawing;
using Microsoft.Win32;
using Image = System.Drawing.Image;

namespace Breweries.Views
{
    public partial class MainWindow : Window
    {
        public List<breweries> breweries1 = new List<breweries>(8);

        public void GetApiRequest(string urlPath)
        {
            try
            {
                DataGridBreweries.Items = null; // Производится очистка DataGrid на тот случай если там что то есть.
                breweries1.Clear(); // Чищу класс Результатов на тот случай если оно заполнен
                using (var client = new HttpClient())
                {
                    var endpoint = new Uri(urlPath);
                    var result = client.GetAsync(endpoint).Result;
                    var json = result.Content.ReadAsStringAsync().Result;
                    // Тут я запрос выполил и получил JSON 

                    var result1 = JsonConvert.DeserializeObject<List<breweries>>(json); // Десериалезую JSON в классы

                    var status = result1;

                    foreach (var item in result1) // Перебираю всю информацию
                    {
                        if (item.address_2 == null || item.address_2 == "")
                        {
                            item.address_2 = "Отсутствует";
                        } // Если поля пусты то заменяю их тексом 

                        if (item.address_3 == null || item.address_3 == "")
                        {
                            item.address_3 = "Отсутствует";
                        } // Если поля пусты то заменяю их тексом 

                        if (item.phone == null || item.phone == "")
                        {
                            item.phone = "Отсутствует";
                        } // Если поля пусты то заменяю их тексом 

                        if (item.website_url == null || item.website_url == "")
                        {
                            item.website_url = "Отсутствует";
                        } // Если поля пусты то заменяю их тексом 
                        
                        else
                        {
                            Debug.Write("-> Увы, Нечего не найдено. ✘\n");
                        }
                    }

                    DataGridBreweries.Items = result1; // В итоге привязываю калекцию к DataGrid
                    Debug.WriteLine($"Запрос к API выполнен успешно!");

                }
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Произошла критическая ошибка при выволнении запроса к API!!\n" +
                                $"Инофрмация об ощибке в блоке ниже:\n{e}\n////////////////////////////////////////////////////");
            }
        } // Метод созданный для обращения к API. Принимает URL запрос и запрлняет DataGrid
                                                        
        
        public MainWindow()
        {
            InitializeComponent();
            
            string url = "https://api.openbrewerydb.org/breweries";
            GetApiRequest(url);
        }
        
        private void SearchBtn(object? sender, RoutedEventArgs e)
        {
            string url = $"https://api.openbrewerydb.org/breweries/search?query={SearchRequest.Text}";
            GetApiRequest(url);
        }
        
        private void SortDist(object? sender, RoutedEventArgs e)
        {
            string url = $"https://api.openbrewerydb.org/breweries?by_dist={latitude.Text},{longitude.Text}&per_page=3";
            GetApiRequest(url);
        }
        
        private void RandomBrewerie(object? sender, RoutedEventArgs e)
        {
            string url = "https://api.openbrewerydb.org/breweries/random";
            GetApiRequest(url);
        }
        
        private void Main(object? sender, RoutedEventArgs e)
        {
            string url = "https://api.openbrewerydb.org/breweries";
            GetApiRequest(url);
        }
    }
}