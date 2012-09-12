using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace AutoMapperReaderExample
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create map once
            Mapper.CreateMap<IDataReader, Person>();

            //Setup a DataTable with Data
            var dataTable = new DataTable();
            
            dataTable.Columns.Add(new DataColumn("Name", typeof (string)));
            dataTable.Columns.Add(new DataColumn("Age", typeof (int)));

            dataTable.Rows.Add("Phillip", "26");
            dataTable.Rows.Add("jchannon", "3");

            //Create a reader from the DataTable
            //This part could be from SQL or where ever
            var reader = dataTable.CreateDataReader();

            //Convert the contents of the IDataReader to a collection
            var result = Mapper.Map<IDataReader, IEnumerable<Person>>(reader);

            foreach (var person in result)
            {
                Console.WriteLine(string.Format("{0} is {1} years old", person.Name, person.Age));
            }

            Console.ReadKey();
        }
    }

    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
