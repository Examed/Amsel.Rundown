using System;
using System.ComponentModel.DataAnnotations;
using Amsel.Framework.Utilities.Extensions.Guids;

namespace Amsel.DTO.Rundown.Models
{
    public class GuidEntityDTO
    {
        [Key] [Display(Name = nameof(Id))] public Guid Id { get; set; } = SequentialGuid.NewMySqlGuid();
    }
}