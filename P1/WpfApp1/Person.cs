using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class Person
    {
        private string _name;
        private string _age;
        private string _address;

        public Person()
        {

        }
        public Person(string name, string age, string address)
        {
            _name = name;
            _age = age;
            _address = address;
        }

        public String Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public String Age
        {
            get { return _age; }
            set { _age = value; }
        }
        public String Address
        {
            get { return _address; }
            set { _address = value; }
        }
    }
}
