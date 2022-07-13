using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace w3schools_API.Models
{
    public class ContentTypes
    {
		public int? ContentTypeId { get; set; }
		public string ContentTypeName { get; set; }
		public string Descriptions { get; set; }
		public DateTime? DateCreated { get; set; }
		public DateTime? DateModified { get; set; }
		public string CreatedBy { get; set; }
		public string ModifiedBy { get; set; }
	}
}
