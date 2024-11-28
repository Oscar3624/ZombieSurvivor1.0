using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHUD
{
    void UpdateCoins(int amount);
    void UpdateHealth(float health);
    void UpdateTimer(float timer);
    void UpdateKeys(int amount);
}
