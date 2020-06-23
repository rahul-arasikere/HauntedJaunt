using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState: Singleton<GameState>{
    public bool _isDetected = false;

    public void PlayerDetected(){
        _isDetected = true;
    }

    public void PlayerEscaped(){
        _isDetected = false;
    }
}