using System.Collections.Generic;
using UnityEngine;

namespace Gameplay
{
    public static class GameMode
    {
        public static GameSettings CurrentSettings
        {
            get => _gameSettings;
            set
            {
                _gameSettings = value;
                CombiningGift();
            }
        }

        private static GameSettings _gameSettings;
        private static List<int> _giftVariants;

        static GameMode()
        {
            CurrentSettings =  new GameSettings(15, 1, 10);
        }
        
        public static int GetRandomGiftCode()
        {
            if (_giftVariants == null || _giftVariants.Count == 0)
            {
                Debug.LogWarning("Not fount gift combination.");
                return 0;
            }

            int giftBox = _giftVariants[Random.Range(0, _giftVariants.Count)];
            Debug.Log("Get random GiftCode: " + giftBox);
            return giftBox;
        }

        private static void CombiningGift()
        {
            int[,] combiningMatrix = GetCombiningMatrix();
            List<int> combining = new List<int>();

            for (int i = 0; i <= combiningMatrix.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= combiningMatrix.GetUpperBound(1); j++)
                {
                    if (_gameSettings.BlueBox)
                        CheckState(i, j, 1, combiningMatrix, combining);
                    
                    if (_gameSettings.RedBox)
                        CheckState(i, j, 2, combiningMatrix, combining);
                    
                    if (_gameSettings.GreenBox)
                        CheckState(i, j, 3, combiningMatrix, combining);
                }
            }
            
            _giftVariants = combining;
            Debug.Log($"GameMode -> {_giftVariants.Count} Gift combinations found");
        }

        private static int[,] GetCombiningMatrix()
        {
            int[] bows = new[]
            {
                _gameSettings.BlueBow ? 10 : 0,
                _gameSettings.RedBow ? 20 : 0,
                _gameSettings.GreenBow ? 30 : 0
            };
            
            int[] ornaments = new[]
            {
                _gameSettings.BlueOrnament ? 1 : 0,
                _gameSettings.RedOrnament ? 2 : 0,
                _gameSettings.GreenOrnament ? 3 : 0
            };

            return new int[,]
            {
                { 0,            bows[0],                bows[1],                bows[2] },
                { ornaments[0], bows[0] + ornaments[0], bows[1] + ornaments[0], bows[2] + ornaments[0] },
                { ornaments[1], bows[0] + ornaments[1], bows[1] + ornaments[1], bows[2] + ornaments[1] },
                { ornaments[2], bows[0] + ornaments[2], bows[1] + ornaments[2], bows[2] + ornaments[2] }
            };
        }

        private static void CheckState(int i, int j, int boxCode, int[,] combiningMatrix, List<int> combining)
        {
            if (i == boxCode || j == boxCode || i + j == 0) return;

            if ((combiningMatrix[i, 0] != 0 || i == 0) && (combiningMatrix[0, j] != 0 || j == 0))
            {
                combining.Add(100 * boxCode + combiningMatrix[i, j]);
            }
        }
    }
}