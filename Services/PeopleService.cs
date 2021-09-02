using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using BlazorSelector.Data;

namespace BlazorSelector.Services
{
    public interface IPeopleService
    {
        public Task<List<string>> GetAvailable();
        public Task<List<string>> GetNames();
        public Task<Person[]> GetPeople();
        public Task<List<string>> GetUnavailable();
        public Task SavePeople();
    }

    public class PeopleService : IPeopleService
    {
        private readonly HttpClient _http;
        private readonly ILocalStorageService _localStorage;
        private SelectionData _data = null;
        private Person[] _people = null;

        public PeopleService(HttpClient http, ILocalStorageService localStorage)
        {
            _http = http;
            _localStorage = localStorage;
        }

        private async Task LoadData()
        {
            if (await _localStorage.ContainKeyAsync("SelectionData")) _data = await _localStorage.GetItemAsync<SelectionData>("SelectionData");
            var selection = await _http.GetFromJsonAsync<SelectionData>("sample-data/people.json");
            if (_data == null || _data.Updated < selection.Updated)
            {
                _data = selection;
                if (_data != null)
                {
                    foreach (var person in _data.People)
                    {
                        person.Available = true;
                        person.AllowSelection = true;
                    }
                    await SavePeople();
                }
            }
            _people = _data?.People;
        }

        public async Task<List<string>> GetAvailable()
        {
            if (_people == null) await LoadData();
            var names = _people?.Where(p => p.Available.GetValueOrDefault()).Select(person => person.DisplayName()).ToList();
            return names;
        }

        public async Task<List<string>> GetNames()
        {
            if (_people == null) await LoadData();
            var names = _people?.Where(p => p.AllowSelection.GetValueOrDefault()).Select(person => person.DisplayName()).ToList();
            return names;
        }

        public async Task<Person[]> GetPeople()
        {
            if (_people == null) await LoadData();
            return _people;
        }

        public async Task<List<string>> GetUnavailable()
        {
            if (_people == null) await LoadData();
            var names = _people?.Where(p => !p.Available.GetValueOrDefault()).Select(person => person.DisplayName()).ToList();
            return names;
        }

        public async Task SavePeople()
        {
            await _localStorage.SetItemAsync("SelectionData", _data);
        }
    }
}
