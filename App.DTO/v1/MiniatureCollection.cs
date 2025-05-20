using System.ComponentModel.DataAnnotations;
using Base.Contracts;

namespace App.DTO.v1;

public class MiniatureCollection : IDomainId
{
    public Guid Id { get; set; }

    [MaxLength(256)] 
    public string CollectionName { get; set; } = default!;

    public string CollectionDesc { get; set; } = default!;

    private DateTime _acquisitionDate = DateTime.UtcNow;

    public DateTime AcquisitionDate
    {
        get => _acquisitionDate;
        set => _acquisitionDate = DateTime.SpecifyKind(value, DateTimeKind.Utc);
    }

    private DateTime _completionDate = DateTime.UtcNow;

    public DateTime CompletionDate
    {
        get => _completionDate;
        set => _completionDate = DateTime.SpecifyKind(value, DateTimeKind.Utc);
    }

    // Relationships
    public Guid MiniatureId { get; set; }
    public Miniature? Miniature { get; set; }

    public Guid MiniStateId { get; set; }
    public MiniState? MiniState { get; set; }

    public Guid PersonId { get; set; }
    public Person? Person { get; set; }

}