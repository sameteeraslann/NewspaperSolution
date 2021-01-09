using NewspaperSolution.EntityLayer.Entites.Interfaces;
using NewspaperSolution.EntityLayer.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewspaperSolution.EntityLayer.Entites.Concrete
{
    public class BaseEntity : IBaseEntity<int>
    {
        public int Id { get; set; }

        private DateTime _createDate = DateTime.Now;
        public DateTime CreateDate { get => _createDate; set => _createDate=value; }

        public DateTime? UpdateDate { get; set; }
        public DateTime? PassiveDate { get; set; }

       

        private Status _status = Status.Active;
        public Status Status { get => _status; set => _status=value; }

    }
}
