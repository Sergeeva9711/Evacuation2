using System;
using System.ComponentModel.DataAnnotations;

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

        public bool IsDeleted { get; set; }

    }
}