using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingSystem.Data.Entities
{
    public class AnswerTranslation
    {
        public Guid Id { get; set; }
        public string LanguageCode { get; set; }

        public Guid AnswerId { get; set; }

        public string Content { get; set; }

        public virtual Answer Answer { get; set; }

        public virtual LanguageTag Language { get; set; }
    }
}
