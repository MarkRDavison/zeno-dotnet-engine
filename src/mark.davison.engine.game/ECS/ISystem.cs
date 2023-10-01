﻿namespace mark.davison.engine.game.ECS;

public interface ISystem
{
    void Update(float delta, IEnumerable<IEntity> entities);
}