using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameReferenceManager : MonoBehaviour
{
    [SerializeField] private UIManager _uimanager;
    public UIManager uiManager {get{ return _uimanager;}}

    [SerializeField] private Player _player;
    public Player player {get{ return _player;}}

    [SerializeField] private PlayerStats _playerStats;
    public PlayerStats playerStats {get{ return _playerStats;}}

    [SerializeField] private BattleManager _battleManager;
    public BattleManager battleManager {get{return _battleManager;}}

    [SerializeField] private ChangeCameraTarget _battleCamera;
    public ChangeCameraTarget battleCamera {get{return _battleCamera;}}

    private void Awake() {
        _playerStats = player.GetComponent<PlayerStats>();
    }
}
