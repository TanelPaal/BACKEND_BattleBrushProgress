﻿using System.ComponentModel.DataAnnotations;
using Base.Contracts;

namespace App.DAL.DTO;

public class MiniatureCollection : IDomainId
{
    public Guid Id { get; set; }
    
    [MaxLength(256, ErrorMessageResourceType = typeof(Base.Resources.Common), ErrorMessageResourceName = "MaxLength")]
    [Display(Name = nameof(CollectionName), Prompt = nameof(CollectionName), ResourceType = typeof(App.Resources.Domain.MiniatureCollection))]
    public string CollectionName { get; set; } = default!;
    
    [Display(Name = nameof(CollectionDesc), Prompt = nameof(CollectionDesc), ResourceType = typeof(App.Resources.Domain.MiniatureCollection))]
    public string CollectionDesc { get; set; } = default!;
    
    private DateTime _acquisitionDate = DateTime.UtcNow;

    [Display(Name = nameof(AcquisitionDate), Prompt = nameof(AcquisitionDate),
        ResourceType = typeof(App.Resources.Domain.MiniatureCollection))]
    public DateTime AcquisitionDate
    {
        get => _acquisitionDate; 
        set => _acquisitionDate = DateTime.SpecifyKind(value, DateTimeKind.Utc);
    }
    
    private DateTime _completionDate = DateTime.UtcNow;

    [Display(Name = nameof(CompletionDate), Prompt = nameof(CompletionDate),
        ResourceType = typeof(App.Resources.Domain.MiniatureCollection))]
    public DateTime CompletionDate
    {
        get => _completionDate; 
        set => _completionDate = DateTime.SpecifyKind(value, DateTimeKind.Utc);
    }
    
    // Relationships
    [Display(Name = nameof(Miniature), Prompt = nameof(Miniature), ResourceType = typeof(App.Resources.Domain.MiniatureCollection))]
    public Guid MiniatureId { get; set; }
    [Display(Name = nameof(Miniature), Prompt = nameof(Miniature), ResourceType = typeof(App.Resources.Domain.MiniatureCollection))]
    public Miniature? Miniature { get; set; }
    
    [Display(Name = nameof(MiniState), Prompt = nameof(MiniState), ResourceType = typeof(App.Resources.Domain.MiniatureCollection))]
    public Guid MiniStateId { get; set; }
    [Display(Name = nameof(MiniState), Prompt = nameof(MiniState), ResourceType = typeof(App.Resources.Domain.MiniatureCollection))]
    public MiniState? MiniState { get; set; }
    
    [Display(Name = nameof(Person), Prompt = nameof(Person), ResourceType = typeof(App.Resources.Domain.MiniatureCollection))]
    public Guid PersonId { get; set; }
    [Display(Name = nameof(Person), Prompt = nameof(Person), ResourceType = typeof(App.Resources.Domain.MiniatureCollection))]
    public Person? Person { get; set; }
    
    [Display(Name = nameof(MiniPaintSwatches), Prompt = nameof(MiniPaintSwatches), ResourceType = typeof(App.Resources.Domain.MiniatureCollection))]
    public ICollection<MiniPaintSwatch>? MiniPaintSwatches { get; set; }
}