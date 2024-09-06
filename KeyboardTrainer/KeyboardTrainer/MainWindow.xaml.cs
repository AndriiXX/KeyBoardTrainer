using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace KeyboardTrainer
{
    public partial class MainWindow : Window
    {
        private string randomString;
        private DateTime startTime;
        private int mistakes = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            int difficulty = (int)DifficultySlider.Value;
            randomString = GenerateRandomString(difficulty * 10);
            RandomStringTextBlock.Text = randomString;
            startTime = DateTime.Now;
            mistakes = 0;
            InputTextBox.IsEnabled = true;
            InputTextBox.Focus();
            StartButton.IsEnabled = false;
            StopButton.IsEnabled = true;
        }

        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            InputTextBox.IsEnabled = false;
            StartButton.IsEnabled = true;
            StopButton.IsEnabled = false;
        }

        private string GenerateRandomString(int length)
        {
            string chars = CaseSensitiveCheckBox.IsChecked == true ?
                           "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz" :
                           "abcdefghijklmnopqrstuvwxyz";
            Random random = new Random();
            char[] result = new char[length];
            for (int i = 0; i < length; i++)
            {
                result[i] = chars[random.Next(chars.Length)];
            }
            return new string(result);
        }

        private void InputTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            HighlightKey(e.Key);

            if (InputTextBox.Text.Length < randomString.Length)
            {
                char expectedChar = randomString[InputTextBox.Text.Length];
                char typedChar = e.Key.ToString().ToLower()[0];

                if (CaseSensitiveCheckBox.IsChecked == true)
                {
                    typedChar = e.Key.ToString()[0];
                }

                if (typedChar != expectedChar)
                {
                    mistakes++;
                    FailsTextBlock.Text = $"Fails: {mistakes}";
                }
            }

            if (InputTextBox.Text.Length == randomString.Length)
            {
                TimeSpan elapsed = DateTime.Now - startTime;
                double charsPerMinute = (InputTextBox.Text.Length / elapsed.TotalMinutes);
                SpeedTextBlock.Text = $"Speed: {charsPerMinute:F2} chars/min";
                StopButton_Click(null, null);
            }
        }

        private void HighlightKey(Key key)
        {
            ResetKeyColors();

            // Підсвічування клавіш
            switch (key)
            {
                case Key.A: KeyA.Background = Brushes.Yellow; break;
                case Key.S: KeyS.Background = Brushes.Yellow; break;
                case Key.D: KeyD.Background = Brushes.Yellow; break;
                case Key.F: KeyF.Background = Brushes.Yellow; break;
                case Key.G: KeyG.Background = Brushes.Yellow; break;
                case Key.H: KeyH.Background = Brushes.Yellow; break;
                case Key.J: KeyJ.Background = Brushes.Yellow; break;
                case Key.K: KeyK.Background = Brushes.Yellow; break;
                case Key.L: KeyL.Background = Brushes.Yellow; break;
                case Key.Z: KeyZ.Background = Brushes.Yellow; break;
                case Key.X: KeyX.Background = Brushes.Yellow; break;
                case Key.C: KeyC.Background = Brushes.Yellow; break;
                case Key.V: KeyV.Background = Brushes.Yellow; break;
                case Key.B: KeyB.Background = Brushes.Yellow; break;
                case Key.N: KeyN.Background = Brushes.Yellow; break;
                case Key.M: KeyM.Background = Brushes.Yellow; break;
                case Key.OemComma: CommaKey.Background = Brushes.Yellow; break;
                case Key.OemPeriod: PeriodKey.Background = Brushes.Yellow; break;
                case Key.OemQuestion: SlashKey.Background = Brushes.Yellow; break;
                case Key.OemSemicolon: SemicolonKey.Background = Brushes.Yellow; break;
                case Key.OemQuotes: QuoteKey.Background = Brushes.Yellow; break;
                case Key.OemOpenBrackets: LeftBracketKey.Background = Brushes.Yellow; break;
                case Key.OemCloseBrackets: RightBracketKey.Background = Brushes.Yellow; break;
                case Key.OemMinus: MinusKey.Background = Brushes.Yellow; break;
                case Key.OemPlus: EqualKey.Background = Brushes.Yellow; break;
                case Key.Back: BackspaceKey.Background = Brushes.Yellow; break;
                case Key.Tab: TabKey.Background = Brushes.Yellow; break;
                case Key.CapsLock: CapsLockKey.Background = Brushes.Yellow; break;
                case Key.Enter: EnterKey.Background = Brushes.Yellow; break;
                case Key.LeftShift: LeftShiftKey.Background = Brushes.Yellow; break;
                case Key.RightShift: RightShiftKey.Background = Brushes.Yellow; break;
                case Key.LeftCtrl: LeftCtrlKey.Background = Brushes.Yellow; break;
                case Key.RightCtrl: RightCtrlKey.Background = Brushes.Yellow; break;
                case Key.LeftAlt: LeftAltKey.Background = Brushes.Yellow; break;
                case Key.RightAlt: RightAltKey.Background = Brushes.Yellow; break;
                case Key.Space: SpaceKey.Background = Brushes.Yellow; break;
                case Key.D1: Key1.Background = Brushes.Yellow; break;
                case Key.D2: Key2.Background = Brushes.Yellow; break;
                case Key.D3: Key3.Background = Brushes.Yellow; break;
                case Key.D4: Key4.Background = Brushes.Yellow; break;
                case Key.D5: Key5.Background = Brushes.Yellow; break;
                case Key.D6: Key6.Background = Brushes.Yellow; break;
                case Key.D7: Key7.Background = Brushes.Yellow; break;
                case Key.D8: Key8.Background = Brushes.Yellow; break;
                case Key.D9: Key9.Background = Brushes.Yellow; break;
                case Key.D0: Key0.Background = Brushes.Yellow; break;
                case Key.OemTilde: BacktickKey.Background = Brushes.Yellow; break;
                case Key.LWin: LeftWinKey.Background = Brushes.Yellow; break;
                case Key.RWin: RightWinKey.Background = Brushes.Yellow; break;
                case Key.Q: KeyQ.Background = Brushes.Yellow; break;
                case Key.W: KeyW.Background = Brushes.Yellow; break;
                case Key.E: KeyE.Background = Brushes.Yellow; break;
                case Key.R: KeyR.Background = Brushes.Yellow; break;
                case Key.T: KeyT.Background = Brushes.Yellow; break;
                case Key.Y: KeyY.Background = Brushes.Yellow; break;
                case Key.U: KeyU.Background = Brushes.Yellow; break;
                case Key.I: KeyI.Background = Brushes.Yellow; break;
                case Key.O: KeyO.Background = Brushes.Yellow; break;
                case Key.P: KeyP.Background = Brushes.Yellow; break;
            }
        }

        private void ResetKeyColors()
        {
            KeyQ.Background = Brushes.LightGray;
            KeyW.Background = Brushes.LightGray;
            KeyE.Background = Brushes.LightGray;
            KeyR.Background = Brushes.LightGray;
            KeyT.Background = Brushes.LightGray;
            KeyY.Background = Brushes.LightGray;
            KeyU.Background = Brushes.LightGray;
            KeyI.Background = Brushes.LightGray;
            KeyO.Background = Brushes.LightGray;
            KeyP.Background = Brushes.LightGray;
            KeyA.Background = Brushes.LightGray;
            KeyS.Background = Brushes.LightGray;
            KeyD.Background = Brushes.LightGray;
            KeyF.Background = Brushes.LightGray;
            KeyG.Background = Brushes.LightGray;
            KeyH.Background = Brushes.LightGray;
            KeyJ.Background = Brushes.LightGray;
            KeyK.Background = Brushes.LightGray;
            KeyL.Background = Brushes.LightGray;
            KeyZ.Background = Brushes.LightGray;
            KeyX.Background = Brushes.LightGray;
            KeyC.Background = Brushes.LightGray;
            KeyV.Background = Brushes.LightGray;
            KeyB.Background = Brushes.LightGray;
            KeyN.Background = Brushes.LightGray;
            KeyM.Background = Brushes.LightGray;
            CommaKey.Background = Brushes.LightGray;
            PeriodKey.Background = Brushes.LightGray;
            SlashKey.Background = Brushes.LightGray;
            SemicolonKey.Background = Brushes.LightGray;
            QuoteKey.Background = Brushes.LightGray;
            LeftBracketKey.Background = Brushes.LightGray;
            RightBracketKey.Background = Brushes.LightGray;
            MinusKey.Background = Brushes.LightGray;
            EqualKey.Background = Brushes.LightGray;
            BackspaceKey.Background = Brushes.LightGray;
            TabKey.Background = Brushes.LightGray;
            CapsLockKey.Background = Brushes.LightGray;
            EnterKey.Background = Brushes.LightGray;
            LeftShiftKey.Background = Brushes.LightGray;
            RightShiftKey.Background = Brushes.LightGray;
            LeftCtrlKey.Background = Brushes.LightGray;
            RightCtrlKey.Background = Brushes.LightGray;
            LeftAltKey.Background = Brushes.LightGray;
            RightAltKey.Background = Brushes.LightGray;
            SpaceKey.Background = Brushes.LightGray;
            Key1.Background = Brushes.LightGray;
            Key2.Background = Brushes.LightGray;
            Key3.Background = Brushes.LightGray;
            Key4.Background = Brushes.LightGray;
            Key5.Background = Brushes.LightGray;
            Key6.Background = Brushes.LightGray;
            Key7.Background = Brushes.LightGray;
            Key8.Background = Brushes.LightGray;
            Key9.Background = Brushes.LightGray;
            Key0.Background = Brushes.LightGray;
            BacktickKey.Background = Brushes.LightGray;
            LeftWinKey.Background = Brushes.LightGray;
            RightWinKey.Background = Brushes.LightGray;
            
        }
    }
}
