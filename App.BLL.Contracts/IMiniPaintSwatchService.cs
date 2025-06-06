﻿using Base.BLL.Contracts;

namespace App.BLL.Contracts;

public interface IMiniPaintSwatchService : IBaseService<App.BLL.DTO.MiniPaintSwatch>
{
    Task<IEnumerable<App.BLL.DTO.MiniPaintSwatch>> AllAsync(Guid userId);
}