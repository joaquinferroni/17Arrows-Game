using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public static class FullGameInformation
    {
        public static readonly float HALF_SCREEN_WITH = (float)Screen.width / 2;
        private static GameState _currentGameState = GameState.STOPED;
        private static readonly Dictionary<GeneralInfo, string> _gameInfo = new Dictionary<GeneralInfo, string>();

        public static void AddKey(GeneralInfo key, string value)
        {
            if (_gameInfo.ContainsKey(key))
            {
                _gameInfo[key] = value;
            }
            else
            {
                _gameInfo.Add(key,value);
            }
        }

        public static string GetValue(GeneralInfo key, string defaultIfNull)
            => _gameInfo.ContainsKey(key) ? _gameInfo[key] : defaultIfNull;

        public static void ChangeState(GameState state)
        {
            _currentGameState = state;
            switch (state)
            {
                case GameState.LOSE:
                {
                    var totalLosses = int.Parse(GetValue(GeneralInfo.TOTAL_LOSSES, "0"));
                    totalLosses++;
                    AddKey(GeneralInfo.TOTAL_LOSSES, totalLosses.ToString());
                    break;
                }
                case GameState.WIN:
                {
                    AddKey(GeneralInfo.TOTAL_LOSSES, "0");
                    break;
                }
            }

        }

        public static GameState GetState() => _currentGameState;
    }
}
