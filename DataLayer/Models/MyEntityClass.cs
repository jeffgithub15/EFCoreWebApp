using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataLayer.Models
{
    public class MyEntityClass
    {
        public int MyEntityClassId { get; set; }
        public string NormalProp { get; set; }
        [NotMapped]
        public string LocalString { get; set; }
        public ExcludeClass LocalClass { get; set; }
    }


    [NotMapped]
    public class ExcludeClass
    {
        public int LocalInt { get; set; }
    }

    public class ValueConversionExample
    {
        public DateTime DateTimeUtcUtcOnReturn { get; set; }
    }

    public class SomeEntity
    {
        public int NonStandardKeyName { get; set; }
    }
}
