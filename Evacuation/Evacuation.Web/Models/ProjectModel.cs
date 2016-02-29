using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Evacuation.Web.Models
{
    public class ProjectModel
    {
        private DateTime data_time = DateTime.Now;

        public int ProjectID { get; set; }
        public string Name { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime DataCreation
        {
            get
            {
                return data_time;
            }
            set
            {
                data_time = value;
            }
        }

        public int UserID { get; set; }
        public UserModel User { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataStrart { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataEnd { get; set; }

        public byte[] Image { get; set; }        

    }
}