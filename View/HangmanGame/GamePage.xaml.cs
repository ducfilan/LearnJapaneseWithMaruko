using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Microsoft.Phone.Controls;
using Microsoft.Xna.Framework.Audio;

namespace Hoc_tieng_Nhat_cung_Maruko.View.HangmanGame
{
    public partial class GamePage : PhoneApplicationPage
    {
        public enum GameStatus { won, lost, progressing };

        Word currentWord = new Word();
        List<LetterBlock> blocks = new List<LetterBlock>();
        GameStatus _gameStatus = GameStatus.progressing;
        int wrongCount = 0;
        List<char> _usedLetters = new List<char>();
        PageOrientation currentOrientation;
        
        // For playing Sound files
        SoundEffect backgroundMusic;
        SoundEffect gameLostMusic;
        SoundEffect gameWonMusic;
        SoundEffectInstance bgInstance;

        public GamePage()
        {
            InitializeComponent();
            currentWord.MaximumWordLength = ChooseWordLengthBasedOnSetting();    

            //// Load the sound file
            //StreamResourceInfo infoGamebackground = Application.GetResourceStream(
            //  new Uri("Audio/GameBackGround.wav", UriKind.Relative));

            //// Create an XNA sound effect from the stream
            //backgroundMusic = SoundEffect.FromStream(infoGamebackground.Stream);
            //bgInstance = backgroundMusic.CreateInstance();
            //bgInstance.IsLooped = true;

            //StreamResourceInfo infoGameWon = Application.GetResourceStream(
            //  new Uri("Audio/GameWon.wav", UriKind.Relative));

            //// Create an XNA sound effect from the stream
            //gameWonMusic = SoundEffect.FromStream(infoGameWon.Stream);

            //StreamResourceInfo infoGameLost = Application.GetResourceStream(
            //  new Uri("Audio/LostGame.wav", UriKind.Relative));

            //// Create an XNA sound effect from the stream
            //gameLostMusic = SoundEffect.FromStream(infoGameLost.Stream);

            //// Subscribe to a per-frame callback
            //CompositionTarget.Rendering += CompositionTarget_Rendering;

            //// Required for XNA sound effects to work
            //Microsoft.Xna.Framework.FrameworkDispatcher.Update();

            AddLettersBlocks();
            UpdateScoreAndLevel();
            currentOrientation = this.Orientation;
        }

        void CompositionTarget_Rendering(object sender, EventArgs e)
        {
            // Required for XNA sound effects to work.
            // Call this every frame.
            Microsoft.Xna.Framework.FrameworkDispatcher.Update();
        }

        void PlayMusic(bool gameWon, bool gameLost, bool backGround)
        {
            if (backGround)
            {
                bgInstance.Play();
            }

            if (gameLost)
            {
                gameLostMusic.Play();
            }

            if (gameWon)
            {
                gameWonMusic.Play();
            }
        }

        void UpdateScoreAndLevel()
        {
            WonGames.Text = AppSettings.gameWon.Value.ToString();
            LostGames.Text = AppSettings.gameLost.Value.ToString();
            Score.Text = AppSettings.totalScore.Value.ToString();
            Level.Text = AppSettings.level.Value;
        }

        public AppSettings.GameLevel AppLevel
        {
            get 
            { 
                if (AppSettings.level.Value == "Easy")
                    return AppSettings.GameLevel.Easy;
                else if (AppSettings.level.Value == "Medium")
                    return AppSettings.GameLevel.Medium;
                else if (AppSettings.level.Value == "Hard")
                    return AppSettings.GameLevel.Hard;

                return AppSettings.GameLevel.Easy;
            }
            set { AppSettings.level.Value = value.ToString(); }
        }

        int ChooseWordLengthBasedOnSetting()
        {
            if (AppSettings.level.Value == "Easy")
                return 3;
            else if (AppSettings.level.Value == "Medium")
                return 6;
            else if (AppSettings.level.Value == "Hard")
                return 8;
            
            return 3;
        }

        /// <summary>
        /// Add blocks
        /// </summary>
        void AddLettersBlocks()
        {
            //PlayMusic(false, false, true);
            BlockHolder.Children.Clear();
            blocks.Clear();

            for (int i = 0; i < currentWord.WordLength; i++)
            {
                LetterBlock block = new LetterBlock();

                if (currentWord.WordLength > 6)
                {
                    // Set the width
                    block.Width = Application.Current.Host.Content.ActualWidth / currentWord.WordLength;
                    // make the block square
                    block.Height = block.Width;
                    // Set rectangle width and height
                    block.OuterEdge.Width = block.Width;
                    block.OuterEdge.Height = block.Width;
                    block.Letter.Width = block.Width * 0.53;
                    block.Letter.Height = block.Width * 0.53;
                }

                BlockHolder.Children.Add(block);
                Grid.SetRow(block, 1);
                blocks.Add(block);
            }
        }

        /// <summary>
        /// Key up event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void KeyLetter(string keyPressed)
        {
            //string keyPressed = e.Key.ToString();
            keyPressed = keyPressed.ToLower();
            if (keyPressed == "unknown") return;

            // Don't process a key which is not a letter
            if (!Char.IsLetter(keyPressed[0]))
                return;
           
            _usedLetters.Add (keyPressed[0]);
            
            AddEnteredLetters();

            int[] positions = new int[currentWord.MaximumWordLength];

            if (currentWord.IsStringInWord(keyPressed, ref positions))
            {
                for (int i = 0; i < positions.Length; i++)
                {
                    if (positions[i] >= 0)
                    {
                        blocks[positions[i]].Letter.Text = keyPressed;
                    }
                }
            }
            else
            {
                DrawHangman(wrongCount++);
            }

            CheckGameStatus();
        }

        /// <summary>
        /// Add entered letters to game message
        /// </summary>
        void AddEnteredLetters()
        {
            string letters = "";
            foreach (char c in _usedLetters)
            {
                letters += Char.ToString(c) + " ";
            }
            GameMessage.Text = "Entered letters: " + letters;
        }
        /// <summary>
        /// Key down event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        void CheckGameStatus()
        {
            if (wrongCount >= 8 || _gameStatus == GameStatus.lost)
            {
                _gameStatus = GameStatus.lost;
            //    PlayMusic(false, true, false);

                GameMessage.Text = "You lost!";
                this.Play.Visibility = System.Windows.Visibility.Visible;
//                DrawHangman(-1);
                AppSettings.gameLost.Value++;
                AppSettings.totalScore.Value = (AppSettings.gameWon.Value - AppSettings.gameLost.Value) * 1000;
                ShowWordInBlocks();
                return;
            }

            if (GameWon())
            {
                //PlayMusic(true, false, false);
                GameMessage.Text = "You won!";
                this.Play.Visibility = System.Windows.Visibility.Visible;
//                DrawHangman(-1);
                AppSettings.gameWon.Value++;
                AppSettings.totalScore.Value = (AppSettings.gameWon.Value - AppSettings.gameLost.Value) * 1000;
                ShowWordInBlocks();
                return;
            }
        }

        void StartGame()
        {
            // Force to generate the new word
            currentWord.CurrentWord = "";
            AddLettersBlocks();

            GameMessage.Text = "";
            _gameStatus = GameStatus.progressing;

            DrawHangman(-1);
            wrongCount = 0;
            this.Play.Visibility = System.Windows.Visibility.Collapsed;

            _usedLetters.Clear();

            UpdateScoreAndLevel();
        }

        /// <summary>
        /// Check the game status
        /// </summary>
        /// <returns></returns>
        bool GameWon()
        {
            foreach (LetterBlock block in blocks)
            {
                if (String.IsNullOrEmpty(block.Letter.Text))
                    return false;
            }

            _gameStatus = GameStatus.won;
            return true;
        }

        /// <summary>
        /// Draw the hang man in steps
        /// </summary>
        /// <param name="index"></param>
        void DrawHangman(int index)
        {
            ImageSource img = null;
            switch (index)
            {
                case 0:
                    {
                        Uri uri = new Uri("Images/Hangman_Floor1.png", UriKind.Relative);
                        img = new System.Windows.Media.Imaging.BitmapImage(uri);
                        break;
                    }
                case 1:
                    {
                        Uri uri = new Uri("Images/Hangman_S2.png", UriKind.Relative);
                        img = new System.Windows.Media.Imaging.BitmapImage(uri);
                        break;
                    }
                case 2:
                    {
                        Uri uri = new Uri("Images/Hangman_S3.png", UriKind.Relative);
                        img = new System.Windows.Media.Imaging.BitmapImage(uri);
                        break;
                    }
                case 3:
                    {
                        Uri uri = new Uri("Images/Hangman_S4.png", UriKind.Relative);
                        img = new System.Windows.Media.Imaging.BitmapImage(uri);
                        break;
                    }
                case 4:
                    {
                        Uri uri = new Uri("Images/Hangman_S5.png", UriKind.Relative);
                        img = new System.Windows.Media.Imaging.BitmapImage(uri);
                        break;
                    }
                case 5:
                    {
                        Uri uri = new Uri("Images/Hangman_S6.png", UriKind.Relative);
                        img = new System.Windows.Media.Imaging.BitmapImage(uri);
                        break;
                    }
                case 6:
                    {
                        Uri uri = new Uri("Images/Hangman_S7.png", UriKind.Relative);
                        img = new System.Windows.Media.Imaging.BitmapImage(uri);
                        break;
                    }
                case 7:
                    {
                        Uri uri = new Uri("Images/Hangman_S8.png", UriKind.Relative);
                        img = new System.Windows.Media.Imaging.BitmapImage(uri);
                        break;
                    }
            }

            Hangman.Source = img;
            Hangman.InvalidateMeasure();
        }

        /// <summary>
        /// Exception to handle image load event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Hangman_ImageFailed(object sender, ExceptionRoutedEventArgs e)
        {
            GameMessage.Text = e.ErrorException.Message;
        }

        /// <summary>
        /// A trick to show the keyboard visible all the time
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void Play_Click(object sender, RoutedEventArgs e)
        {
            //Restart the game with a new set of data
            StartGame();
            foreach (var ctrl in LayoutButton.Children)
            {
                if (ctrl is Button)
                    ((Button)ctrl).IsEnabled = true;
            }

        }

        private void PhoneApplicationPage_OrientationChanged(object sender, OrientationChangedEventArgs e)
        {
            currentOrientation = e.Orientation;
        }

        void ShowWordInBlocks()
        {
            if (true == AppSettings.showWord.Value)
            {
                // Show the word
                for (int i = 0; i < currentWord.CurrentWord.Length; i++)
                {
                    blocks[i].Letter.Text = Char.ToString(this.currentWord.CurrentWord[i]);
                }
            }

        }

        private void Button_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            var button = (sender as Button);
            var key = button.Tag; 
            KeyLetter(key.ToString());
            button.IsEnabled = false;
        }
    }
}