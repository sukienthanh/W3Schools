using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace w3schools_API.Models
{
	public class Example
	{
		public int? ExampleId { get; set; }
		public string Content { get; set; }
		public int? LessonContentId { get; set; }		
		public DateTime? DateCreated { get; set; }
		public DateTime? DateModified { get; set; }
		public string CreatedBy { get; set; }
		public string ModifiedBy { get; set; }
	}
}
