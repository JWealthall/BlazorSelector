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
        public Task<List<string>> GetNames();
    }
    
    public class PeopleService : IPeopleService
    {
        private readonly HttpClient _http;
        private Person[] _people = null;

        public PeopleService(HttpClient http)
        {
            _http = http;
        }

        private async Task LoadData()
        {
            _people = await _http.GetFromJsonAsync<Person[]>("sample-data/people.json");
        }

        public async Task<List<string>> GetNames()
        {
            if (_people == null) await LoadData();
            var names = _people?.Select(person => person.NickName ?? person.FullName ?? person.Initials).ToList();
            return names;
        }
    }
}
