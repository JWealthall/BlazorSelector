using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorSelector.Data
{
    public class SelectionData
    {
        public DateTime Updated { get; set; }
        public Person[] People { get; set; }
    }

    public class Person
    {
        public string Initials { get; set; }
        public string FullName { get; set; }
        public string NickName { get; set; }
        public bool? Available { get; set; }
        public bool? AllowSelection { get; set; }
    }

    public static class DataExtensions
    {
        public static string DisplayName(this Person person)
        {
            return person.NickName ?? person.FullName ?? person.Initials;
        }
    }
}
