using System;
using System.Collections.Generic;
using System.Text;

namespace Com.Bateeq.Service.Auth.Lib.ViewModels
{
    public class UnitViewModel
    {
        public int _id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }

        public DivisionViewModel Division { get; set; }
    }
}
