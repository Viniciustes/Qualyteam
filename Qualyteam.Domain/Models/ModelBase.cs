using FluentValidation.Results;
using System.ComponentModel.DataAnnotations.Schema;

namespace Qualyteam.Domain.Models
{
    public abstract class ModelBase
    {
        public int Id { get; private set; }

        [NotMapped]
        public ValidationResult ValidationResult { get; set; }

        public abstract bool IsValid();
    }
}
