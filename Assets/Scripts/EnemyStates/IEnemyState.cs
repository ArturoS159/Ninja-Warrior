﻿using UnityEngine;

public interface IEnemyState
{
    void Enter(Enemy enemy);
    void Execute();
    void Exit();
    void OnTriggerEnter(Collider2D other);
}
