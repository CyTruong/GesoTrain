using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace web.Models
{
    public partial class UserModel
    {  
        public web.Models.STUDENT student { get; set; }
        public List<web.Models.STUDENT_EXPERIENCE> studenEXP { get; set; }
        public List<web.Models.SKILL> skillList { get; set; }
        public web.Models.CV_STUDENT cvStudent { get; set; }
        public web.Models.SCHOOL school { get; set; }    
      
    }

    public partial class SKILL
    {
        public bool isChecked { get; set; }
    }
}
