using FluentValidation.Results;
using System.ComponentModel.DataAnnotations.Schema;

namespace Qualyteam.Domain.Models
{
    public abstract class ModelBase
    {
        public ModelBase() { }

        protected ModelBase(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }

        [NotMapped]
        public ValidationResult ValidationResult { get; set; }
    }
}
