using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD_MVC5.MetaData
{

    [MetadataType(typeof(TodosMetadata))]
    public partial class Todos
    {
    }

    public class TodosMetadata
    {
        public int Id { get; set; }

        [DisplayName("完成")]
        public Nullable<bool> Done { get; set; }
        [Required(ErrorMessage = "請填寫代辦事項")]
        [DisplayName("代辦事項")]
        public string Event { get; set; }
        [DisplayName("建立時間")]
        public Nullable<System.DateTime> TimeStamp { get; set; }
    }
}