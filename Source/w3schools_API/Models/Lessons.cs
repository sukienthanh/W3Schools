using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace w3schools_API.Models
{
    public class Lessons
    {
		public int? LessonId { get; set; }
		public int? LessonCateId { get; set; }
		public string LessonName { get; set; }
		public DateTime? DateCreated { get; set; }
		public DateTime? DateModified { get; set; }
		public string CreatedBy { get; set; }
		public string ModifiedBy { get; set; }
	}
}
