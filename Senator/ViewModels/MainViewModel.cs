    using System;
    using System.Collections.ObjectModel;
    using System.Windows;
    using System.Windows.Threading;
    using Newtonsoft.Json;
    using Senator.Models;
    using CefSharp;
    using System.Linq;
    using Senator.Services;
    using System.Threading.Tasks;

    namespace Senator.ViewModels
    {
        public class MainViewModel : BaseViewModel
        {
            public ObservableCollection<Soldier> Soldiers { get; set; }
            private DispatcherTimer _timer;
            private SoldierService _soldierService;

            public MainViewModel()
            {
                _soldierService = new SoldierService();
                Soldiers = new ObservableCollection<Soldier>();

                LoadSoldiersFromDatabase();

                _timer = new DispatcherTimer();
                _timer.Interval = TimeSpan.FromSeconds(5);
                _timer.Tick += UpdateSoldierPositions;
                _timer.Start();
            }

            private async void LoadSoldiersFromDatabase()
            {
                var soldiersFromDb = await Task.Run(() => _soldierService.GetAllSoldiers());

                Application.Current.Dispatcher.Invoke(() =>
                {
                    foreach (var soldier in soldiersFromDb)
                    {
                        Soldiers.Add(soldier);
                    }

                    UpdateMapWithSoldiers();
                });
            }

            private void UpdateSoldierPositions(object sender, EventArgs e)
            {
                foreach (var soldier in Soldiers)
                {
                    soldier.Latitude += 0.01;
                    soldier.Longitude += 0.01;
                }

                UpdateMapWithSoldiers();
            }

            private void UpdateMapWithSoldiers()
            {
                var soldiersData = JsonConvert.SerializeObject(Soldiers.Select(s => new { s.SoldierId, s.Name, s.Latitude, s.Longitude, Country = s.Country.Name, Rank = s.Rank.Name, Training = s.Training.Name }));

                string script = $"updateSoldiersPositions({soldiersData})";

                Application.Current.Dispatcher.Invoke(() =>
                {
                    var window = Application.Current.Windows[0] as Views.MainWindow;
                    if (window != null && window.MapBrowser != null)
                    {
                        window.MapBrowser.EvaluateScriptAsync(script);
                    }
                });
            }
        }
    }