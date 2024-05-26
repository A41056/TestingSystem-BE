using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingSystem.Data.Entities
{
    public class QuestionTranslation
    {
        public Guid Id { get; set; }
        public string LanguageCode { get; set; }

        public Guid QuestionId { get; set; }

        public string Content { get; set; }

        public virtual Question Question { get; set; }

        public virtual LanguageTag Language { get; set; }
    }
}
