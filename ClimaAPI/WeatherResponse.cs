using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimaAPI
{
    public class WeatherResponse
    {
        public string Name { get; set; }

        public Main Main { get; set; }

        public Weather[] Weather { get; set; }

        public Wind Wind { get; set; }
    }
}
